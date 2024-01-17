namespace Algorithms;

public class FuncComparer<T>(Func<T?, T?, int> inner) : IComparer<T> where T : struct
{
	Func<T?, T?, int> _inner = inner;

    public int Compare(T x, T y) => _inner(x, y);
}
