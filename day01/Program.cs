// See https://aka.ms/new-console-template for more information

var path = Path.Combine(Environment.CurrentDirectory, "data");
var data = File.ReadAllLines(path).Select(x => int.Parse(x));

var prev = 0;
var increments = 0;

foreach (var value in data)
{
    if (prev != 0)
    {
        if (value > prev) increments++;
    }

    prev = value;
}

Console.WriteLine($"Increments: {increments}");

Console.WriteLine("## three-measure sliding window ##");

var tm = new List<int>();

for (int i = 0; i < data.Count(); i++)
{
    var v = data.Skip(i).Take(3).Sum();
    Console.WriteLine($"Sum {i+1} is {v}");
    tm.Add(v);
}

prev=0;
increments=0;

foreach (var value in tm)
{
    if (prev != 0)
    {
        if (value > prev) increments++;
    }

    prev = value;
}

Console.WriteLine($"Three-measure increments: {increments}");