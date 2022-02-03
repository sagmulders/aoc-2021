// See https://aka.ms/new-console-template for more information

var numbersPath = Path.Combine(Environment.CurrentDirectory, "numbers");
var dataPath = Path.Combine(Environment.CurrentDirectory, "data");

var numbers = File.ReadAllText(numbersPath).Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x));
var data = File.ReadAllText(dataPath).Replace('\n', ' ').Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x));

List<BingoCard> cards = new List<BingoCard>();

int count = 0;
while (true)
{
    var items = data.Skip(count * 25).Take(25).ToArray();

    if (!items.Any())
        break;

    cards.Add(new BingoCard(count + 1, 5, items));
    count++;
}

Console.WriteLine($"{cards.Count()} cards");

BingoCard lastCard = null;
foreach (var number in numbers)
{
    Console.WriteLine($"Number drawn {number}");
    cards.ForEach(x => x.Drawn(number));

    var left = cards.Where(x => !x.HasBingo());
    Console.WriteLine($"{left.Count()} left");

    if (left.Count() == 1)
    {
        lastCard = left.Single();
    }

    if (lastCard != null && lastCard.HasBingo())
    {
        // we have a winner!
        Console.WriteLine($"Last winner {lastCard.Id} with score {lastCard.CalculateScore(number)}");

        break;
    }
}


Console.WriteLine("done");

class BingoCard
{
    int size;
    int id;

    bool hasBingo;

    public BingoCard(int id, int size, int[] numbers)
    {
        this.id = id;
        this.size = size;
        Card = new Cell[size, size];

        var counter = 0;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Card[i, j] = new Cell() { Value = numbers[counter] };

                counter++;
            }
        }
    }

    public int Id
    {
        get
        {
            return this.id;
        }
    }

    public Cell[,] Card { get; set; }

    public bool HasBingo()
    {
        if (hasBingo)
            return true;

        for (int i = 0; i < size; i++)
        {
            // check row
            var row = Enumerable.Range(0, size)
                            .Select(x => Card[i, x])
                            .ToArray();

            var fullrow = row.All(x => x.Checked);

            // check column
            var col = Enumerable.Range(0, size)
                            .Select(x => Card[x, i])
                            .ToArray();

            var fullcol = col.All(x => x.Checked);

            if (fullrow || fullcol)
            {
                hasBingo = true;
                return true;
            }
            else
                continue;
        }

        return false;
    }

    public void Drawn(int number)
    {
        if (hasBingo)
            return;

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (Card[i, j].Value == number)
                {
                    //yes, we have the number
                    Console.WriteLine($"Card {id} contains {number}");
                    Card[i, j].Checked = true;
                }
            }
        }
    }

    internal object CalculateScore(int number)
    {
        var score = 0;

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (!Card[i, j].Checked)
                {
                    score += Card[i, j].Value;
                }
            }
        }

        return score * number;
    }
}

class Cell
{
    public int Value { get; set; }
    public bool Checked { get; set; }
}