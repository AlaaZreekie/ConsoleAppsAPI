
if (args.Length < 2)
{
    Console.WriteLine("Please provide 2 integers.");
    return;
}

if (!int.TryParse(args[0], out int left))
{
    Console.WriteLine("Please provide integer value in the first argument.");
    return;
}


if (!int.TryParse(args[1], out int right))
{
    Console.WriteLine("Please provide an integer value in the second.");
    return;
}

Console.WriteLine($"{left} + {right} = {left + right}");