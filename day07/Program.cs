// See https://aka.ms/new-console-template for more information

var data = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "data"));
var positions = data.Split(',').ToArray().Select(x=>int.Parse(x));

int[] fuels = new int[positions.Count()];

for (int i = 0; i < positions.Count(); i++)
{
    positions.ToList().ForEach(X=> fuels[i] += Math.Abs(X-(i+1)));
}

Console.WriteLine(fuels.OrderBy(x=>x).First());