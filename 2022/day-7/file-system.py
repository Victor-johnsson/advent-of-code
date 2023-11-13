from __future__ import annotations
from typing import List

class Directory:
    totalSizeOfFiles:int
    name:str
    childDirectories:[]
    parentDirectory:Directory
    def __init__(self, name, parentDirectory):
        self.name = name
        self.parentDirectory = parentDirectory
        self.totalSizeOfFiles = 0
        self.childDirectories = []

    def getTotalSize(self):
        size = self.totalSizeOfFiles
        for directory in self.childDirectories:
            size += directory.getTotalSize()
        return size
    def fullPath(self):
        if self.parentDirectory == None:
            return self.name
        else:
            return self.parentDirectory.fullPath() + "/" + self.name
        


fileName = "input.txt" 
file = open(fileName, "r")
listingDIR = False
rootDirectory =  Directory("/",None)
currentDir = rootDirectory

def createDirectory(name, parentDirectory):
    print("Create Directory: " + name)
    newDirectory = Directory(name, parentDirectory)
    return newDirectory
# Create file structure from input.txt
for line in file:
    if line.__contains__("$"):
        #Run Command:

        if(line.__contains__("cd")):
            listingDIR = False

            if(line.__contains__("..")):
                currentDir = currentDir.parentDirectory
            elif line.__contains__("/"):
                currentDir = rootDirectory
            else:
                filtered_list = list(filter(lambda x: x.name == line.split(" ")[2].replace("\n",""), currentDir.childDirectories))
                currentDir = filtered_list[0]

        elif(line.__contains__("ls")):
            listingDIR = True
    elif line[:3] == "dir":
        filtered_list = list(filter(lambda x: x.name == line.split(" ")[1].replace("\n",""), currentDir.childDirectories))
        if len(filtered_list) > 0:
            print("Directory already exists")
        else:
            currentDir.childDirectories.append(createDirectory(line.split(" ")[1].replace("\n",""), currentDir))

    else:
        fileSize = int(line.split(" ")[0])
        currentDir.totalSizeOfFiles += fileSize
        




# Print file structure
def makeMapOfSize(directory:Directory, map:dict):
    map[directory.fullPath()] = directory.getTotalSize()
    for child in directory.childDirectories:
        makeMapOfSize(child, map)
        
# Print file structure
def makeMapOfDirectories(directory:Directory, map:dict):
    map[directory.fullPath()] = directory
    for child in directory.childDirectories:
        makeMapOfDirectories(child, map)
map = {}
directoryMap = {}
makeMapOfSize(rootDirectory , map )
makeMapOfDirectories(rootDirectory , directoryMap )

for key in map:
    print(key + " " + str(map[key]))

total = 0
for dir in map:
    dirSize = map[dir]  
    if(dirSize<=100000):
        total += dirSize

print("Total: " + str(total))

totalSpace = 70000000
unusedSpace = totalSpace - rootDirectory.getTotalSize()
spaceToFreeUp = (unusedSpace - 30000000)*-1
print("Unused Space: " + str(unusedSpace))
print("Space to free up: " + str(spaceToFreeUp))

currentDir = rootDirectory
currentDelta = spaceToFreeUp - currentDir.getTotalSize()

for dir in directoryMap.keys():

    if(spaceToFreeUp-directoryMap[dir].getTotalSize() > currentDelta and spaceToFreeUp-directoryMap[dir].getTotalSize() <=0 ):
        currentDir = directoryMap[dir]
        currentDelta = spaceToFreeUp-directoryMap[dir].getTotalSize()

print(currentDir.name + " " + str(currentDir.getTotalSize()))
