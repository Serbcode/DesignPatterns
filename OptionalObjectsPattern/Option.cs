public class Option<T> where T : class
{
    private T? content = null;

    private Option() { }

    public static Option<T> Some(T content) => new Option<T> { content = content };

    public static Option<T> None() => new Option<T>();

    public bool HasValue => content is not null;

    public Option<TResult> Map<TResult>(Func<T, TResult> map) where TResult : class
        => HasValue ? Option<TResult>.Some(map(content!)) : Option<TResult>.None();

    public T Reduce(T WhenNone) => HasValue ? content! : WhenNone;
}
