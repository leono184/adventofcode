// See https://aka.ms/new-console-template for more information

// Read a text file line by line.
using LNGTestingConsoleApp;
const string START = "AAA";
const string END = "ZZZ";

int steps = 0;
char nextStep;
string tempSequence;
string sequence;
var directions = new Dictionary<string, Direction>();

string[] lines = File.ReadAllLines("C:\\Users\\leono\\Downloads\\AoC 2023 Day 8 input.txt");

sequence = lines[0];

foreach(string line in lines.Skip(2)) {
    directions.Add(line.Substring(0, 3),
                   Direction.New(line));
}

var startPosition = directions[START];
var endPosition = directions[END];
var currentPosition = startPosition;

tempSequence = sequence;

while(currentPosition != endPosition){

    steps++;
    nextStep = tempSequence[0];

    tempSequence = tempSequence.Length == 1 ? sequence : tempSequence.Substring(1);

    currentPosition = directions[currentPosition.GetNewPoint(nextStep)];
}

Console.WriteLine(steps);
