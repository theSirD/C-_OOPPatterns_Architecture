using System;
using Itmo.ObjectOrientedProgramming.Lab3.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Message
{
    public Message(string header, string body, ConfidentialityLevels confidentialityLevel)
    {
        if (header is null || body is null)
            throw new ArgumentException("Either header or body is null");
        Header = header;
        Body = body;
        ConfidentialityLevel = confidentialityLevel;
    }

    public string Header { get; private set; }
    public string Body { get; private set; }
    public ConfidentialityLevels ConfidentialityLevel { get; private set; }
}