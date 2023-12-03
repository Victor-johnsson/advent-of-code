import csv

datalist =[]

with open("input.txt") as file:
    reader = csv.reader(file, delimiter=";")
    for row in reader:
        datalist.append(row[0])
        
        

firstElves =[]
secondElves = []

for pair in datalist:
    splitPair = pair.split(",")
    a = splitPair[0].split("-")
    firstElves.append(a)
    a = splitPair[1].split("-")
    secondElves.append(a)
    
print(firstElves)
print(secondElves)
sum=0
sum2=0
for i in range(len(firstElves)):
    a1 = int(firstElves[i][0])
    a2 = int(firstElves[i][1])
   
    b1 = int(secondElves[i][0])
    b2 = int(secondElves[i][1])
   
    if((a1>= b1 and a2<=b2) or (b1>=a1 and b2<=a2)):
        sum+=1
    
    
    
    
    if((a1<=b2 and a1>=b1) or (a2>=b1 and a2<=b2) or(b1<=a2 and b1>=a1) or (b2<=a2 and b2>=a1)):
        sum2+=1
        


   
   
 
 
   
print(sum2)
   
   
   
   
   