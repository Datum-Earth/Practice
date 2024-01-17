namespace Algorithms;

public class OrderedStreamMerger<T> where T : struct
{
    private readonly OrderedStreamEnumerator<T> _le;
	private readonly OrderedStreamEnumerator<T> _re;
	private readonly IComparer<T> _comparer;
	
	public bool HasMore => _le.HasMore || _re.HasMore;
	
	public OrderedStreamMerger(IEnumerable<T> leftStream, IEnumerable<T> rightStream, IComparer<T> comparer)
	{
		_le = new OrderedStreamEnumerator<T>(leftStream.GetEnumerator());
		_re = new OrderedStreamEnumerator<T>(rightStream.GetEnumerator());
		
		_comparer = comparer;
	}
	
	public OrderedStreamMerger(IEnumerable<T> leftStream, IEnumerable<T> rightStream, Func<T?, T?, int> comparer)
	{
		_le = new OrderedStreamEnumerator<T>(leftStream.GetEnumerator());
		_re = new OrderedStreamEnumerator<T>(rightStream.GetEnumerator());

		_comparer = new FuncComparer<T>(comparer);
	}

    private void Initialize()
    {
        if (!_le.Initialized)
			_le.MoveNext();
			
		if (!_re.Initialized)
			_re.MoveNext();
    }

	public IEnumerable<T> Merge()
	{
		Initialize();
		
		while (HasMore)
		{
			var compareResult = _comparer.Compare(_le.Current, _re.Current);

			// left < right, yield left and advance left enumerator
			if (compareResult < 0 && _le.HasMore)
			{
				yield return _le.Current;
				_le.MoveNext();

				continue;
			}
			else if (compareResult == 0 && _le.HasMore && _re.HasMore) // equal, yield left but advance both
			{
				yield return _le.Current;
				_le.MoveNext();
				_re.MoveNext();

				continue;
			}
			else if (_re.HasMore)// right < left, yield right and advance right enumerator
			{
				yield return _re.Current;
				_re.MoveNext();

				continue;
			}

			throw new Exception("Comparer did not return expected results");
		}
	}
}
