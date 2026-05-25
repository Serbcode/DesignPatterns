using ResultPattern;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<CreateUserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/users", (CreateUserRequest request, CreateUserService service) =>
{
    Result result = service.CreateUser(request);

    return result.Match(
        onSuccess: () => Results.Created($"/users/{request.Username}", null),
        onFailure: error => error.Code switch
        {
            "InvalidUsername" => Results.BadRequest(new { error.Code, error.Description }),
            "WeakEmail" => Results.BadRequest(new { error.Code, error.Description }),
            _ => Results.StatusCode(500)
        });

}).WithName("CreateUser");


app.Run();


/* CreateUserService and related classes */

public static class CreateUserErrors
{
    public static Error InvalidUsername(string username) => new(
            Code: "InvalidUsername",
            Description: $"The username '{username}' is invalid.");

    public static Error WeakEmail(string email) => new(
            Code: "WeakEmail",
            Description: $"The email '{email}' is invalid.");
}

// How data is transformed during the creation of a user
// 1. CreateUserRequest is received from the client (DTO)
// 2. This request needs to be validated by CreateUserRequest Validator
// 3. Then validated data is processed by CreateUserService
// 4. CreateUserService tries to create a user domain entity (check for email uniqueness...)
// 5. If successful, returns Result.Success(), otherwise returns Result.Failure(Error) 


public sealed class CreateUserService
{
    public Result CreateUser(CreateUserRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Username))
        {
            return Result.Failure(CreateUserErrors.InvalidUsername(request.Username));
        }

        if (!isValidEmail(request.Email))
        {
            return Result.Failure(CreateUserErrors.WeakEmail(request.Email));
        }

        // Assume user creation logic here

        return Result.Success();
    }

    private bool isValidEmail(string email)
    {
        return email.Contains("@"); // for test purposes only 
    }
}

public class Result
{
    private Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
        {
            throw new InvalidOperationException("A successful result cannot have an error.");
        }

        if (!isSuccess && error == Error.None)
        {
            throw new InvalidOperationException("A failed result must have an error.");
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new(true, Error.None);
    public static Result Failure(Error error) => new(false, error);

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }
}

public sealed record Error(string Code, string Description)
{
    public static readonly Error None = new Error(string.Empty, string.Empty);
}

public sealed record CreateUserRequest(string Username, string Email);