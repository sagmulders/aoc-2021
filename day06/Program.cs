// See https://aka.ms/new-console-template for more information

var path = Path.Combine(Environment.CurrentDirectory, "data");

var school = new List<Fish>();
File.ReadAllText(path).Split(",", StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(x => school.Add(new Fish(int.Parse(x))));


for (var i = 0; i < 80; i++)
{
    Console.WriteLine($"After {i} days: {string.Join(',', school)}");

    school.ToList().ForEach(x =>
    {
        var newFish = x.DayPassed();
        if (newFish != null)
            school.Add(newFish);
    });

    Console.WriteLine($"{school.Count} of fish in our school");
}

class Fish
{
    public Fish(int age)
    {
        this.age = age;
    }

    private int age;

    internal Fish DayPassed()
    {
        age--;

        if (age < 0)
        {
            age = 6;
            return new Fish(8);
        }

        return null;
    }

    public override string ToString()
    {
        return age.ToString();
    }
}