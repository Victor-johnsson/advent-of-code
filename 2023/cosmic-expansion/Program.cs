using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using common;

var file = FileHandler.ReadFile("cosmos.txt");
var fileCopy = new int[file.Length,file[0].Length];
int a = 0;
int fileLength = file.Length;
int rowLenght = file[0].Length;
int pairs = 0;
List<Coordinate> coordinates = new();

for(int i = 0; i<fileLength; i ++){

    for(int j = 0; j<rowLenght; j++){
        fileCopy[i,j]=0;
       if(file[i][j]=='#'){
        a ++;
        pairs += a;
        fileCopy[i,j]=1;
        coordinates.Add(new Coordinate(i,j));

       }
    }
}
pairs -=a;

RowsWithNoGalaxies(fileCopy);

for(int i = 0;  i<coordinates.Count; i++){
    var lengthBetween = new List<int>();

    var startElement = coordinates.ElementAt(i);
    for(int j = i+1; j<coordinates.Count;j++){
        var secondElement =coordinates.ElementAt(j);
        var maxRow = int.Max(secondElement.Row, startElement.Row);
        var maxColumn = int.Max(secondElement.Column, startElement.Column);
        var minRow = int.Min(secondElement.Row, startElement.Row);
        var minColumn = int.Min(secondElement.Column, startElement.Column);
        var doubleRows = RowsWithNoGalaxies(fileCopy);
        var doubleColumns = ColumnssWithNoGalaxies(fileCopy);
        List<int> columns = Enumerable.Range(minColumn, maxColumn-minColumn+1).ToList();
        List<int> rows = Enumerable.Range(minRow, maxRow-minRow+1).ToList();
        
        var lenght = Math.Abs(secondElement.Column - startElement.Column) + Math.Abs(secondElement.Row - startElement.Row) ;
        
        var slicedArray = SlicedArray(minRow, minColumn,maxRow - minRow,maxColumn - minColumn, fileCopy);
        if(lenght<0) lenght = lenght*-1;
        
        lengthBetween.Add(lenght);
    }
    lengthBetween.Sort();
    Console.WriteLine(lengthBetween[0]);

}
List<int> RowsWithNoGalaxies(int[,] array){
    var nbrOfRows = array.GetLength(0);
    var nbrOfColumns = array.GetLength(1);
    List<int> rows = new();
    for(int i = 0; i< nbrOfRows; i++){
        var sum = 0;

        for(int j = 0; j<nbrOfColumns; j++){
            sum+=array[i,j];
        }
        if(sum == 0){
            rows.Add(i);
        }
    }
    return rows;

    
}

List<int> ColumnssWithNoGalaxies(int[,] array){
    var nbrOfRows = array.GetLength(0);
    var nbrOfColumns = array.GetLength(1);
    List<int> rows = new();
    for(int i = 0; i< nbrOfColumns; i++){
        var sum = 0;

        for(int j = 0; j<nbrOfRows; j++){
            sum+=array[j,i];
        }
        if(sum == 0){
            rows.Add(i);
        }
    }
    return rows;

    
}
int[,] SlicedArray(int start, int end, int rowLenght, int columLenght, int[,] arr){
    int[,] slicedArray = new int[rowLenght, columLenght];

// Copy the specified portion to the slicedArray
    for (int i = 0; i < rowLenght; i++)
    {
        
        for (int j = 0; j < columLenght; j++)
        {
            if(i ==0 && j ==0 ) {
                slicedArray[i, j] = 0;
                continue;
            }
            if(i == rowLenght-1 && j == columLenght -1){
                slicedArray[i, j] = 0;
                continue;
            }
            slicedArray[i, j] = arr[i+start +1 , j+end];
        }
    }
    return slicedArray;
}
Console.WriteLine(a);
Console.WriteLine(pairs);

record Coordinate(int Row, int Column);