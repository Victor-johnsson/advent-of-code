import csv


datalist = []

with open("input.txt") as file:
    reader = csv.reader(file, delimiter=";")
     
    for row in reader:
        datalist.append(row)
        
    
    

points= 0
 
def whatChose(choice):
    if(choice == 'X' or choice == 'A'):
        return 'rock'
    elif(choice == 'Y' or choice == 'B'):
        return 'paper'
    else:
        return 'scissor'
    
    
def whatChoice(opponent, outcome):
    if(outcome =='Z'):
        if(opponent=='rock'):
            return 2
        if(opponent=="paper"):
            return 3
        if(opponent == "scissor"):
            return 1
    if(outcome == 'Y'):
        if(opponent == 'rock'):
            return 1
        if(opponent == 'paper'):
            return 2
        if(opponent == 'scissor'):
            return 3        
    if(outcome == 'X'):
        if(opponent == 'rock'):
            return 3
        if(opponent == 'paper'):
            return 1
        if(opponent == 'scissor'):
            return 2   
        


for row in datalist:
    
    choices = row[0].split(' ')
    opponent = choices[0]
    me = choices[1]
    if(me == 'Z'):
        points+=6
    if(me== 'Y'):
        points+=3
    if(me=='X'):
        points+=0
        
    opponent = whatChose(opponent)
    print(opponent)

    points += whatChoice(opponent, me)
    


print(points)
    
    
    
    
    
    

    
    