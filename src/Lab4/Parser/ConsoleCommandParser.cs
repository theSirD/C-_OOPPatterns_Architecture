using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class ConsoleCommandParser : IParse
{
    private string _input;
    private int _currentPosition;
    private bool _betweenSameQuotationMarks;

    public ConsoleCommandParser()
    {
        _input = string.Empty;
        _currentPosition = 0;
        _betweenSameQuotationMarks = false;
    }

    public string Current { get; set; } = string.Empty;

    public void SetInput(string input)
    {
        if (input is null)
            throw new ArgumentException("input is null");
        _input = input;
        _currentPosition = 0;
        _betweenSameQuotationMarks = false;
    }

    public void MoveForward()
    {
        Current = string.Empty;
        while (_currentPosition < _input.Length)
        {
            if (char.IsWhiteSpace(_input[_currentPosition]))
            {
                if (!_betweenSameQuotationMarks)
                {
                    _currentPosition++;
                    return;
                }

                Current += _input[_currentPosition];
                _currentPosition++;
            }

            if (_input[_currentPosition] == '"')
                _betweenSameQuotationMarks = !_betweenSameQuotationMarks;

            Current += _input[_currentPosition];
            _currentPosition++;
        }
    }
}