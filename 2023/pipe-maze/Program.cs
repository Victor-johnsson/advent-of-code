
using System.Reflection;
using common;


var file =FileHandler.ReadFile("maze.txt");
var maze = new char[file.Length, file[0].Length];
var calculatedMaze = new int[file.Length, file[0].Length];
Coordinate startCoordinate = new (0,0);
for(int i = 0; i<file.Length; i++){
    for(int j =0; j<file[0].Length; j++){
        maze[i,j]=file[i][j];
        if(maze[i,j].Equals('S')){
            startCoordinate = new(i,j);
        }
    }
}

// FindStartPipe(startCoordinate,maze);
Coordinate currentCoordinate = new(startCoordinate.Row +1, startCoordinate.Column);

calculatedMaze[startCoordinate.Row, startCoordinate.Column]=1;
int count = 1;
string from = "north";
while(!IsStart(startCoordinate, currentCoordinate)){
    calculatedMaze[currentCoordinate.Row, currentCoordinate.Column] = 1;
    var result = Move(currentCoordinate, from, maze);
    currentCoordinate = result.Item2;
    from = result.Item1;
    count++;
    

}
Console.WriteLine("Count {0}", count);
Console.WriteLine("Amount from start = " + count/2);


(string, Coordinate) Move(Coordinate current, string from, char[,] maze){
    char c = maze[current.Row, current.Column];        
    switch (from)
    {
        
        case "north":
            if(c == '|') {

                current = new(current.Row +1, current.Column);
                from = "north";
            }

            if(c == 'L'){ // go east
                current = new(current.Row, current.Column +1 );
                from = "west";
            }
            if(c == 'J') {// go west
                current = new(current.Row, current.Column-1);
                from = "east";}



            break;
        case "south":
            if(c=='F'){
                current = new(current.Row, current.Column +1 );
                from = "west";}
            if(c == '7'){
                current = new(current.Row, current.Column -1 );
                from="east";}
            if (c == '|'){
                current = new(current.Row - 1, current.Column);
                from = "south";}
            break;
        case "east":
            if(c == 'F'){
                current = new(current.Row+1, current.Column);
                from = "north";}

            if(c == 'L'){
                current = new(current.Row -1, current.Column);
                from ="south";}
            if(c == '-'){
                current = new(current.Row, current.Column -1);
                from = "east";}
            break;
        case "west":
            if(c == 'J'){
                current = new(current.Row-1, current.Column);
                from = "south";}
                
            if(c == '7'){
                current = new(current.Row+1, current.Column);
                from = "north";}

            if(c == '-'){
                current = new(current.Row, current.Column+1);
                from = "west";}

            break;

    }
    return (from, current);
}



for(int i = 0; i<file.Length; i++){
    for (int j = 0; j<file[0].Length; j++){
        Console.Write(calculatedMaze[i,j]);
        
    }
    Console.WriteLine();
}
void FindStartPipe(Coordinate startCoordinate, char[,] maze){
    var north = GetNorth(startCoordinate,maze);
    var south   = GetSouth(startCoordinate,maze);
    var west = GetWest(startCoordinate,maze);
    var east = GetEast(startCoordinate, maze);


}
bool IsStart(Coordinate startCoordinate, Coordinate currentCoordinate){
    return startCoordinate == currentCoordinate;
}


char GetNorth(Coordinate coordinate, char[,] maze){
     return maze[coordinate.Row-1,coordinate.Column];
}
char GetSouth(Coordinate coordinate, char[,] maze){
    return maze[coordinate.Row+1,coordinate.Column];
}
char GetWest(Coordinate coordinate, char[,] maze){
    
    return maze[coordinate.Row,coordinate.Column-1];
}

char GetEast(Coordinate coordinate, char[,] maze){
    return maze[coordinate.Row,coordinate.Column+1];
}
record Coordinate(int Row, int Column);
