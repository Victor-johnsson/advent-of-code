using System.Reflection;

var executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
var projectDirectory = Path.GetFullPath(Path.Combine(executableLocation, @"..\..\.."));
var filePath = Path.Combine(projectDirectory, "almanack.txt");
var file = File.ReadAllLines(filePath);

PartOne(file);
PartTwo(file);


long FindMinimumInSeedList(List<long> seeds, List<List<CategoryMap>> mapList)
{
    var dict = new Dictionary<long, long>();

    foreach (var list in mapList)
    {

        var newSeeds = new List<long>();

        for (int i = 0; i < seeds.Count; i++)
        {
            // seed = 79
            var seed = seeds[i];
            foreach (CategoryMap map in list)
            {
                // source = 98
                // destination = 50
                // range = 2

                if (seed >= map.SourceRange && seed <= map.SourceRange + map.RangeLength)
                {

                    //destinationRange = 52
                    //sourceRange = 50
                    //rangeLength =48
                    newSeeds.Add(seed + map.DestinationRange - map.SourceRange);
                }

            }
            if (newSeeds.Count == i)
            {
                newSeeds.Add(seed);
            }



        }
        seeds = newSeeds;
        dict = new Dictionary<long, long>();
    }

    seeds.Sort();
    return seeds.FirstOrDefault();
}


void PartOne(string[] file)
{
  
    var mapList = CreateListOfCategoryMaps(file);

    var seeds = file[0].Replace("seeds: ", string.Empty).Split(" ").Select(x => long.Parse(x)).ToList();



    Console.WriteLine("Part one: {0}",FindMinimumInSeedList(seeds, mapList));
}


void PartTwo(string[] file)
{
    ///Shitty solution haha kind of bruteforcing but works.
    var mapList = CreateListOfCategoryMaps(file);

    var seeds = file[0].Replace("seeds: ", string.Empty).Split(" ").Select(x => long.Parse(x)).ToList();
    var newSeedList = new List<long>();
    for(int i =0; i<seeds.Count; i += 2)
    {

        var start = seeds[i];
        var end = seeds[i + 1] + start;
        end = end - start;
        start = 0;
        var seedRange = Enumerable.Range((int)start, (int)end).Select(x => (long)x + seeds[i]).ToList();

        var result = FindMinimumInSeedList(seedRange, mapList); 
        newSeedList.Add(result);
    }

    newSeedList.Sort();

    Console.WriteLine("Part two: {0}", newSeedList[0]);


}





List<List<CategoryMap>> CreateListOfCategoryMaps(string[] file)
{
    var list = new List<List<CategoryMap>>();
    var seeds = file[0].Replace("seeds: ", string.Empty).Split(" ").Select(x => int.TryParse(x, out int result)).ToList();
    List<CategoryMap> mapList = null;

    foreach (var line in file[2..])
    {
        var split = line.Split(" ");
        if (split.Length == 2)
        {
            list.Add(new List<CategoryMap>());

            mapList = list.Last();

        }
        else if (split.Length == 3)
        {
            var intArray = split.Select(x => long.Parse(x)).ToArray();
            var categoryMap = new CategoryMap(intArray[0], intArray[1], intArray[2]);
            mapList.Add(categoryMap);
        }




    }

    return list;
}

record CategoryMap(long DestinationRange, long SourceRange, long RangeLength);
