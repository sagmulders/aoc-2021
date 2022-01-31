// See https://aka.ms/new-console-template for more information

// part 1

var path = Path.Combine(Environment.CurrentDirectory, "data");
var lines = File.ReadAllLines(path);

var diagnostics = lines.Select(x => Convert.ToInt32(x, 2));
var count = diagnostics.Count();
var width = 12;

/*

int gamma = 0, epsilon = 0;

for (var i = width - 1; i >= 0; i--)
{
    var d = diagnostics.Where(x => (x & (1 << i)) == (1 << i)).Count();

    gamma += ((d / Convert.ToDouble(count)) > .5) ? 1 << i : 0;
    epsilon += ((d / Convert.ToDouble(count)) < .5) ? 1 << i : 0;
}
var powerConsumption = gamma * epsilon;

Console.WriteLine($"Gamma {gamma} epsilon {epsilon} power {powerConsumption}");
*/

// part 2

var oxygenRatings = diagnostics.ToList();
var co2ratings = diagnostics.ToList();

for (var i = width - 1; i >= 0; i--)
{
    var ones = oxygenRatings.Where(x => (x & (1 << i)) == (1 << i)).ToList();
    var zeroes = oxygenRatings.Where(x => (x & (1 << i)) != (1 << i)).ToList();

    if (zeroes.Count() == ones.Count() || ones.Count() > zeroes.Count())
        oxygenRatings.RemoveAll(l => zeroes.Contains(l));
    else
        oxygenRatings.RemoveAll(l => ones.Contains(l));

    // break if only one left
    if (oxygenRatings.Count() == 1)
        break;
}
var oxygenGeneratorRating = oxygenRatings.Single();

for (var i = width - 1; i >= 0; i--)
{
    var ones = co2ratings.Where(x => (x & (1 << i)) == (1 << i));
    var zeroes = co2ratings.Where(x => (x & (1 << i)) != (1 << i));

    if (zeroes.Count() == ones.Count() || ones.Count() > zeroes.Count())
        co2ratings.RemoveAll(l => ones.Contains(l));
    else
        co2ratings.RemoveAll(l => zeroes.Contains(l));

    // break if only one left
    if (co2ratings.Count() == 1)
        break;
}

var co2ScrubberRating= co2ratings.Single();

var lifeSupportRating = oxygenGeneratorRating * co2ScrubberRating;


Console.WriteLine($"oxygen {oxygenGeneratorRating} co2 {co2ScrubberRating} life support rating {lifeSupportRating}");
