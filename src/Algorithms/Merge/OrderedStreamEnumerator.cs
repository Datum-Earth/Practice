using System.Collections;

namespace Algorithms;

public class OrderedStreamEnumerator<T>(IEnumerator<T> inner) : IEnumerator<T> where T : struct
{
    private readonly IEnumerator<T> _inner = inner;
	public bool HasMore { get; set; }
	public bool Initialized { get; set; }

    object IEnumerator.Current => Current as object;

	public T Current => _inner.Current;

	public bool MoveNext()
	{
		if (!Initialized)
			Initialized = true;
		
		HasMore = _inner.MoveNext();
		
		return HasMore;
	}

	public void Reset()
	{
		Initialized = false;
		
		_inner.Reset();
		HasMore = false;
	}

	public void Dispose() => _inner.Dispose();
}
