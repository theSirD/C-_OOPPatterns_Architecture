using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class ConsoleCommandParser : IParse
{
    private readonly string _input;
    private int _currentPosition;

    public ConsoleCommandParser(string input)
    {
        if (input is null)
            throw new ArgumentException("Given command is null. A string required");
        _input = input;
        _currentPosition = 0;
    }

    public string SearchForCommand()
    {
        string decipheredCommand = string.Empty;
        while (_currentPosition < _input.Length)
        {
            if (char.IsWhiteSpace(_input[_currentPosition]))
            {
                _currentPosition++;
                return decipheredCommand;
            }

            decipheredCommand += _input[_currentPosition];
            _currentPosition++;
        }

        return decipheredCommand;
    }

    public string SearchForPath()
    {
        string decipheredPath = string.Empty;
        char typeOfQuotationMarks = _input[_currentPosition];
        decipheredPath += _input[_currentPosition];
        _currentPosition++;
        while (_currentPosition < _input.Length)
        {
            if (_input[_currentPosition] == typeOfQuotationMarks)
            {
                decipheredPath += _input[_currentPosition];
                if (_currentPosition + 2 < _input.Length)
                    _currentPosition += 2;
                return decipheredPath;
            }

            decipheredPath += _input[_currentPosition];
            _currentPosition++;
        }

        // validation
        return decipheredPath;
    }

    public string SearchForFlag()
    {
        string decipheredFlag = string.Empty;
        while (_currentPosition < _input.Length)
        {
            if (char.IsWhiteSpace(_input[_currentPosition]))
            {
                _currentPosition++;
                return decipheredFlag;
            }

            decipheredFlag += _input[_currentPosition];
            _currentPosition++;
        }

        return decipheredFlag;
    }

    public string SearchForFlagArgument()
    {
        string decipheredFlagArgument = string.Empty;
        while (_currentPosition < _input.Length)
        {
            if (char.IsWhiteSpace(_input[_currentPosition]))
            {
                _currentPosition++;
                return decipheredFlagArgument;
            }

            decipheredFlagArgument += _input[_currentPosition];
            _currentPosition++;
        }

        return decipheredFlagArgument;
    }
}