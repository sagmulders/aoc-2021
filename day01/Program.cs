// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var path = Path.Combine(Environment.CurrentDirectory, "data");
Console.WriteLine(path);

var data = File.ReadAllLines(path);
Console.WriteLine($"Numbre of lines: {data.Length}");

var prev = 0;
var increments = 0;

foreach (var line in data)
{
    int value = int.Parse(line);

    if (prev != 0)
    {
        if (value>prev) increments++;
    }

    prev = value;
}

Console.WriteLine($"Increments: {increments}");