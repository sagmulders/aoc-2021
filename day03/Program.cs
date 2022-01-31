// See https://aka.ms/new-console-template for more information

var path = Path.Combine(Environment.CurrentDirectory, "data");
var lines = File.ReadAllLines(path);

var diagnostics = lines.Select(x => Convert.ToInt32(x, 2));
var count = diagnostics.Count();
var width = 12;

int gamma = 0, epsilon = 0;

for (var i = width - 1; i >= 0; i--)
{
    var d = diagnostics.Where(x => (x & (1 << i)) == (1 << i)).Count();

    gamma += ((d / Convert.ToDouble(count)) > .5) ? 1 << i : 0;
    epsilon += ((d / Convert.ToDouble(count)) < .5) ? 1 << i : 0;
}
var powerConsumption = gamma * epsilon;

Console.WriteLine($"Gamma {gamma} epsilon {epsilon} power {powerConsumption}");