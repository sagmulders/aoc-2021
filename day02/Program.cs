// See https://aka.ms/new-console-template for more information

var path = Path.Combine(Environment.CurrentDirectory, "data");
var commands = File.ReadAllLines(path).Select(x => Command.Parse(x));

var state = new State();

commands.ToList().ForEach(x => x.Apply(state));

Console.WriteLine($"Final pos {state.Pos} and depth {state.Depth}, result {state.Pos * state.Depth}");

class State
{
    public int Pos { get; set; }
    public int Depth { get; set; }
    public int Aim { get; set; }
}


class Command
{
    public string Cmd { get; set; }
    public int Value { get; set; }

    public void Apply(State state)
    {
        switch (Cmd)
        {
            case "up":
                {
                    state.Aim -= Value;
                    break;
                }
            case "down":
                {
                    state.Aim += Value;
                    break;
                }
            case "forward":
                {
                    state.Pos += Value;
                    state.Depth += state.Aim * Value;
                    break;
                }
            default:
                break;
        }
    }

    public static Command Parse(string value)
    {
        var p = value.Split(' ');
        return new Command() { Cmd = p[0], Value = int.Parse(p[1]) };
    }
}
