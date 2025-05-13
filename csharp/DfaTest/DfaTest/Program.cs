// See https://aka.ms/new-console-template for more information


using DfaTest;

Console.WriteLine("Let's test the DFA (Deterministic Finite Automata):");

string[] cases = ["123", "-123", "123.456", "-123.456", ".123", "123.", "123.456.789"];

foreach (string c in cases)
{
    if (DfaMatcher.IsMatch(c))
    {
        Console.WriteLine($"  '{c}' is accepted by the DFA");
    }
    else
    {
        Console.WriteLine($"  '{c}' is rejected by the DFA");
    }
}

