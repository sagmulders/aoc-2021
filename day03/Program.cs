// See https://aka.ms/new-console-template for more information

var path = Path.Combine(Environment.CurrentDirectory, "data");
var lines = File.ReadAllLines(path);

// sizing 
var x = lines.First().Length;
var y = lines.Count();

Console.WriteLine($"width {x} length {y}");

var data = new int[y, x];
int row = 0;

// parse matrix
foreach (var line in lines)
{
    int pos = 0;
    foreach (var c in line.ToCharArray())
    {
        data[row, pos] = int.Parse(c.ToString());
        pos++;
    }

    row++;
}

//var gamma = Enumerable.Range(0, x).ToArray();
string gamma = "", epsilon = "";
for (var i = 0; i < x; i++)
{
    var t = Enumerable.Range(0, y).Select(x => data[x, i]).ToArray();
    var zeros = t.Where(x => x == 0).Count();
    var ones = t.Where(x => x == 1).Count();

    //gamma[i] = zeros > ones ? 0 : 1;
    gamma += (zeros > ones ? "0" : "1");
    epsilon += (zeros < ones ? "0" : "1");
}

var gammaValue = Convert.ToInt32(gamma, 2);
var epsilonValue = Convert.ToInt32(epsilon, 2);

Console.WriteLine($"Gamma: {gammaValue}, Epsilon: {epsilonValue}. Power: {gammaValue * epsilonValue}");
