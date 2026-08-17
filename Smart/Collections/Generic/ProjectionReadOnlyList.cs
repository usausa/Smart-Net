namespace Smart.Collections.Generic;

using System.Collections;

public sealed class ProjectionReadOnlyList<TSource, TResult> : IReadOnlyList<TResult>
{
    private readonly IReadOnlyList<TSource> source;

    private readonly Func<TSource, TResult> selector;

    public int Count => source.Count;

    public TResult this[int index] => selector(source[index]);

    public ProjectionReadOnlyList(IReadOnlyList<TSource> source, Func<TSource, TResult> selector)
    {
        this.source = source;
        this.selector = selector;
    }

    public IEnumerator<TResult> GetEnumerator()
    {
        foreach (var item in source)
        {
            yield return selector(item);
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public static class ProjectionReadOnlyListExtensions
{
    public static ProjectionReadOnlyList<TSource, TResult> AsProjection<TSource, TResult>(this IReadOnlyList<TSource> source, Func<TSource, TResult> selector) =>
        [with(source, selector)];
}
