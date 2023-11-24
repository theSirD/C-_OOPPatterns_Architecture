using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class ConsoleCommandParser : IParse
{
    private readonly string _input;
    private int _currentPosition;
    private bool _betweenSameQuotationMarks;

    public ConsoleCommandParser(string input)
    {
        if (input is null)
            throw new ArgumentException("Given command is null. A string required");
        _input = input;
        _currentPosition = 0;
        _betweenSameQuotationMarks = false;
    }

    public string Current { get; private set; } = string.Empty;

    public void MoveForward()
    {
        Current = string.Empty;
        while (_currentPosition < _input.Length)
        {
            if (char.IsWhiteSpace(_input[_currentPosition]))
            {
                if (_betweenSameQuotationMarks)
                {
                    Current += _input[_currentPosition];
                    _currentPosition++;
                }

                _currentPosition++;
                return;
            }

            if (_input[_currentPosition] == '"')
                _betweenSameQuotationMarks = !_betweenSameQuotationMarks;

            Current += _input[_currentPosition];
            _currentPosition++;
        }
    }
}