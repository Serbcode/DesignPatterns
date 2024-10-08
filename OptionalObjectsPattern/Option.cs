public class Option<T> where T : class
{
    private T? content = null;

    private Option() { }

    public static Option<T> Some(T content) => new Option<T> { content = content };

    public static Option<T> None() => new Option<T>();

    public bool HasValue => content is not null;

    /// <summary>
    /// Additional method for transforming the value if it is presented
    /// </summary>
    public Option<TResult> Apply<TResult>(Func<T, TResult> map) where TResult : class
        => HasValue ? Option<TResult>.Some(map(content!)) : Option<TResult>.None();

    /// <summary>
    /// Additional method where client code can specify what to return 
    /// if content was not presented
    /// </summary>
    public T GetValueOrDefault(T WhenNone) => HasValue ? content! : WhenNone;
}
