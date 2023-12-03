

using System.Reflection;

var executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
var projectDirectory = Path.GetFullPath(Path.Combine(executableLocation, @"..\..\.."));
var filePath = Path.Combine(projectDirectory, "games.txt");
int PartOne()
{


    var total = 0;
    foreach (var line in File.ReadLines(filePath))
    {
        
        var stringWithoutGame = line[4..];
        var id = int.Parse(stringWithoutGame.Split(":")[0]);
        var game = stringWithoutGame.Split(":")[1].Split(";");

        if (ValidGame(game)) total += id;

       
    }
    return total;   
}

bool ValidGame(string[] game)
{

    var dict = new Dictionary<string, int>();
    dict.Add("red", 12);
    dict.Add("green", 13);
    dict.Add("blue", 14);

    foreach (var part in game)
    {

        var colorTimes = part.Split(",");
        foreach(var ct in colorTimes)
        {
            var trimmedString = ct.Trim();
            var arr = trimmedString.Split(" ");
            var times = int.Parse(arr[0]);
            var color = arr[1];

            dict.TryGetValue(color, out var max);

            if (times > max) return false;
        }
    }


    return true;
}


int PartTwo()
{


    var total = 0;
    foreach (var line in File.ReadLines(filePath))
    {

        //var stringWithoutGame = line[4..];
        //var id = int.Parse(stringWithoutGame.Split(":")[0]);
        var game = line.Split(":")[1].Split(";");

        total += PowerOfGame(game);


    }
    return total;
}


int PowerOfGame(string[] game)
{

    var dict = new Dictionary<string, int>();
    dict.Add("red", 0);
    dict.Add("green", 0);
    dict.Add("blue", 0);

    foreach (var part in game)
    {

        var colorTimes = part.Split(",");
        foreach (var ct in colorTimes)
        {
            var trimmedString = ct.Trim();
            var arr = trimmedString.Split(" ");
            var times = int.Parse(arr[0]);
            var color = arr[1];

            dict.TryGetValue(color, out var max);

            if (times > max)  dict[color] = times;
        }
    }

    var values = dict.Values.ToArray();

    return values[0] * values[2]* values[1];
}

Console.WriteLine("Total was " + PartOne());

Console.WriteLine("Power was " + PartTwo());