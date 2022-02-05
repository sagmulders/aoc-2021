// See https://aka.ms/new-console-template for more information

var data = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "data"));
var positions = data.Split(',').ToArray().Select(x => int.Parse(x));

int[] fuels = new int[positions.Count()];
var costs = Enumerable.Range(1, positions.Max()+1).ToArray();

for (int i = 0; i < positions.Count(); i++)
{
    positions.ToList().ForEach(X =>
    {
        var diff = Math.Abs(X - (i + 1));
        fuels[i] += costs.Take(diff).Sum();
    });
}

Console.WriteLine(fuels.OrderBy(x => x).First());