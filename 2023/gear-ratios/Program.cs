

using System.Reflection;



///Im not happy with part two of this solution! I am not confident that it will solve everything correctly. 
///Say there is a gear with two part numbers where both numbers are equal to another ( numOne == numTwo), the HashMap would only store one of them and the ration wouldn't be counted to the sum. 
///Another problem if there is a gear with three adjacenat numbers, where two of the numbers are equal to another ( numOne == numTwo && numOne != numThree).
///Then the ratio numOne * numThree would be counted to the sum, but in a full solution it breaks the rule of only counting gears with exactly two adjecant numbers! 
///


var executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
var projectDirectory = Path.GetFullPath(Path.Combine(executableLocation, @"..\..\.."));
var filePath = Path.Combine(projectDirectory, "schematics.txt");
var lines = File.ReadLines(filePath);

var schematics = MakeSchematics(lines);
PartOne(schematics);
PartTwo(schematics);



static string[] MakeSchematics(IEnumerable<string> lines)
{
    var numberOfLines = lines.Count();
    var schematics = new string[numberOfLines];

    for(int i= 0; i < numberOfLines; i++)
    {
 
            
            schematics[i] = lines.ElementAt(i).ToString();
        
    }

    return schematics;
}


bool CheckIfIsSymbol(string[] schematics, int row, int column)
{
    if(column < 0 || row < 0 || row >= schematics.Length || column >= schematics[0].Length) return false;

    return !int.TryParse(schematics[row][column].ToString(), out int _) && !schematics[row][column].ToString().Equals(".");
}
bool IsInRangeOfSymbol(string[] schematics, int row, int column)
{

    var left = CheckIfIsSymbol (schematics, row , column - 1);
    var right = CheckIfIsSymbol (schematics, row, column + 1);
    var up = CheckIfIsSymbol (schematics, row - 1, column );
    var down = CheckIfIsSymbol (schematics, row + 1, column);
    var upLeft = CheckIfIsSymbol (schematics, row - 1, column - 1);
    var upRight = CheckIfIsSymbol (schematics, row - 1, column + 1);
    var downLeft = CheckIfIsSymbol (schematics, row + 1, column - 1);
    var downRight = CheckIfIsSymbol(schematics, row + 1, column + 1);

    return left || right || up || down || upLeft || upRight || downLeft || downRight;
}

bool IsFullNumberInRangeOfSymbol(int numberLength,int rowContainingTheNumber, int startColumnOfNumber, string[] schematics)
{
    for (int i = startColumnOfNumber; i < startColumnOfNumber + numberLength; i++)
    {
        if (IsInRangeOfSymbol(schematics, rowContainingTheNumber, i)) return true;
    }
    return false;
}


bool IsNumber(string[] schematics, int row, int column)
{
    if (row >= schematics.Length || column>= schematics[0].Length || row < 0 || column < 0) return false;

    return int.TryParse(schematics[row][column].ToString(), out int _);
}






string GetNumberFrom(string[] schematics, int row, int column)
{
    var number = "";

    while (IsNumber(schematics, row, column))
    {
        number += schematics[row][column];
        column++;

    }
    return number;
}
string GetNumberBefore(string[] schematics, int row, int column)
{
    var number = "";
    column--;
    while (IsNumber(schematics, row, column))
    {
        var tmpNumber = schematics[row][column].ToString();
        tmpNumber += number;
        number = tmpNumber;
        column--;

    }
    return number;
}

int GetFullNumber(string[] schematics, int row, int column)
{
    var number = GetNumberBefore(schematics,row,column) + GetNumberFrom(schematics,row,column); 

    _ = int.TryParse(number, out var result);
    return result;
}

int NumberOfAdjecantNumbers(string[] schematics, int row, int column)
{
    var list = new List<(int row, int column)>();


    if( IsNumber(schematics, row, column - 1))
    {
     
        list.Add(new(row, column - 1));
    }
    if (IsNumber(schematics, row, column + 1))
    {
        list.Add(new(row, column + 1));
    }
    if (IsNumber(schematics, row - 1, column))
    {
        list.Add(new(row - 1, column));
    }
    if (IsNumber(schematics, row + 1, column))
    {
        list.Add(new(row + 1, column));
    }
    if (IsNumber(schematics, row - 1, column - 1))
    {
        list.Add(new(row - 1, column - 1));
    }
    if (IsNumber(schematics, row - 1, column + 1))
    {
        list.Add(new(row - 1, column + 1));
    }
    if (IsNumber(schematics, row + 1, column - 1))
    {
        list.Add(new(row + 1, column - 1));
    }
    if (IsNumber(schematics, row + 1, column + 1))
    {
        list.Add(new(row + 1, column + 1));
    }

    var setOfFullNumbers = new HashSet<int>();
    foreach(var tuple in list)
    {
        setOfFullNumbers.Add(GetFullNumber(schematics, tuple.row, tuple.column));
    }

    if (setOfFullNumbers.Count == 2)
    {
        return setOfFullNumbers.ElementAt(0) * setOfFullNumbers.ElementAt(1);
    }

    return 0;
}

void PartOne(string[] schematics)
{
    var total = 0;
    for (int i = 0; i < schematics.Length; i++)
    {
        for (int j = 0; j < schematics[i].Length; j++)
        {

            if (IsNumber(schematics, i, j))
            {

                int fullNumber = GetFullNumber(schematics, i, j);
                var fullNumberLength = fullNumber.ToString().Length;

                if (IsFullNumberInRangeOfSymbol(fullNumberLength, i, j, schematics))
                {
                    total += fullNumber;
                }
                j = j + fullNumberLength - 1;



            }


        }
    }

    Console.WriteLine("Part one: {0}", total);

}

void PartTwo(string[] schematics)
{

    var total = 0;
    for (int i = 0; i < schematics.Length; i++)
    {
        for (int j = 0; j < schematics[i].Length; j++)
        {

            if (schematics[i][j].ToString().Equals("*"))
            {
                total += NumberOfAdjecantNumbers(schematics,i,j);


            }

           


        }
    }

    Console.WriteLine("Part two: {0}", total);

}




