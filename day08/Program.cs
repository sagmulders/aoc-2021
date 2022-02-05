// See https://aka.ms/new-console-template for more information

var lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "data"));
var outputs = lines.Select(x=> x.Split('|')[1].Split(' ')).SelectMany(x=> x);

var answer = outputs.Where(x=> new int[] { 2,3,4,7}.Contains(x.Length) ).Count();

Console.WriteLine(answer);