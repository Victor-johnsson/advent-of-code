using System.Reflection;

var executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
var projectDirectory = Path.GetFullPath(Path.Combine(executableLocation, @"..\..\.."));
var filePath = Path.Combine(projectDirectory, "races.txt");
var file = File.ReadAllLines(filePath);


PartOne(file);
PartTwo(file);





void PartOne(string[] file)
{

    var times = file[0]
    .Split(" ")[1..]
    .Where(x => !x.Equals(string.Empty))
    .Select(x => int.Parse(x))
    .ToList();

    var distances = file[1]
        .Split(" ")[1..]
        .Where(x => !x.Equals(string.Empty))
        .Select(x => int.Parse(x))
        .ToList();
    var total = 1;
    for (int i = 0; i < times.Count; i++)
    {
        total *= CalculateAmountOfRaces(times[i], distances[i]);
    }
    Console.WriteLine("Part one: {0}", total);
}


void PartTwo(string[] file)
{


    var times = file[0]
    .Split(" ")[1..]
    .Where(x => !x.Equals(string.Empty))
    .ToList();

    var distances = file[1]
        .Split(" ")[1..]
        .Where(x => !x.Equals(string.Empty))

        .ToList();

    var time = "";
    var distance = "";  
    for (int i = 0; i < times.Count; i++)
    {
        time+= times[i];
        distance += distances[i];
    }
    




    var total = CalculateAmountOfRacesLong(long.Parse(time), long.Parse(distance));

    Console.WriteLine("Part Two: {0}", total);

}

int CalculateAmountOfRaces(int time, int distance)
{
    int total = 0;
    for (int i = 0; i < time; i++)
    {
        if (i * (time - i) > distance)
        {
            total++;
        }
    }
    return total;
}

long CalculateAmountOfRacesLong(long time, long distance)
{
    long total = 0;
    for (long i = 0; i < time; i++)
    {
        if (i * (time - i) > distance)
        {
            total++;
        }
    }
    return total;
}