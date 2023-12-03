import csv

datalist = []



with open("input.txt") as file:
    reader = csv.reader(file, delimiter=";")
    for row in reader:
        datalist.append(row)
        
#print(datalist)


groupedList = []
sublist =[]
for row in datalist:
    
    if( len(row) != 0):
        sublist.append(int(row[0]))
    else:
        groupedList.append(sublist)
        sublist = []        
        

largest = 0
top =[]
for row in groupedList:
    sumCalorie = 0
    for calorie in row:
        sumCalorie += calorie
        
    print(sumCalorie)
    top.append(sumCalorie)
    if(sumCalorie>largest):
        largest = sumCalorie
        
        
        
top.sort()
print(top[len(top)-1] + top[len(top)-2] + top[len(top)-3])