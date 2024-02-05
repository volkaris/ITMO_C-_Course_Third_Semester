using System;
using System.Collections;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParsersEnumerator;

public class ParserEnumerator : IEnumerator<string>
{
    private readonly string[] _request;
    private bool _isDisposed;
    private int _currentIndex = -1;

    public ParserEnumerator(string[] request)
    {
        _request = request;
    }

    public string Current => _request[_currentIndex];

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        _currentIndex++;
        return _currentIndex < _request.Length;
    }

    public void Reset()
    {
        _currentIndex = -1;
    }

    // I dont know why I need this,but without dispose it won't compile
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_isDisposed) return;

        if (disposing)
        {
        }

        _isDisposed = true;
    }
}