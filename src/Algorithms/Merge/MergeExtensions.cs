namespace Algorithms;

public static class MergeExtensions
{
    public static IEnumerable<T> Merge<T>(this IEnumerable<T> source, IEnumerable<T> target) where T : struct
        => new OrderedStreamMerger<T>(source, target, Comparer<T>.Default).Merge();

    public static IEnumerable<T> Merge<T>(this IEnumerable<T> source, IEnumerable<T> target, IComparer<T> comparer) where T : struct
        => new OrderedStreamMerger<T>(source, target, comparer).Merge();
}
