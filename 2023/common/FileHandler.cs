namespace common;
using System.Reflection;

public class FileHandler
{
    
    public static string[] ReadFile(string fileName){

        var executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var projectDirectory = Path.GetFullPath(Path.Combine(executableLocation, @"..\..\.."));
        var filePath = Path.Combine(projectDirectory, fileName);

        return   File.ReadAllLines(filePath);
    }

}
