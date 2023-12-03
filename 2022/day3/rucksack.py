import string
import csv
lowercaseAlphapet = list(string.ascii_lowercase)
uppercaseAlphapet = list(string.ascii_uppercase)



datalist = []
def middleIndex(string):
    if(len(string)%2 ==0):
        return (len(string)-1)//2
    else:
        return len(string)//2
    



with open("input.txt") as file:
    reader = csv.reader(file, delimiter=';')
    for row in reader:
        datalist.append(row[0])
        
sum = 0

#print(uppercaseAlphapet.index('A'))
for rucksack in datalist:
    compOne = rucksack[:middleIndex(rucksack)+1]
    compTwo = rucksack[middleIndex(rucksack)+1 :]
    
    for char in compOne:
        if(char in compTwo):
            if(char.isupper()):
                index = uppercaseAlphapet.index(char) +27
                
                sum += index
            else:
                index = lowercaseAlphapet.index(char) +1
                sum += index
            break
            
                
index = 0
sum = 0
while(index<len(datalist)):
    
    rucksackOne = datalist[index]
    rucksackTwo = datalist[index+1]
    rucksackThree = datalist[index+2]
    
    for char in rucksackOne:
        if(char in rucksackTwo and char in rucksackThree):
            if(char.isupper()):
                sum += uppercaseAlphapet.index(char) +27
                
                #sum += index
            else:
                sum += lowercaseAlphapet.index(char) +1
                #sum += index
            break
        
        
    index+=3  


print(sum)