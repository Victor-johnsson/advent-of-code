
x_value = 1
checkpoint =40
cycle = 1
values = list()
breakpoint = 0
sprite = [0,1,2]
pixel_line =""







    
    
def draw_line():
    global pixel_line
    global sprite
    calculate_signal_strenght()

    if(sprite.__contains__(cycle-1)):
        pixel_line+="#"
    else:
        pixel_line+="."


def noop():

    ""    

   
def addx(x:int):

    sprite[0] = sprite[0]+x
    sprite[1] = sprite[1]+x
    sprite[2] = sprite[2]+x





def calculate_signal_strenght():
    global cycle
    global checkpoint
    global values
    global x_value

    global pixel_line

    if(breakpoint % 40 == 0 and breakpoint != 0):
        checkpoint += 40
        cycle =cycle - 40
        print(pixel_line)
        pixel_line =""



with open("input.txt") as f:
    for line in f:

        line = line.removesuffix("\n")
        command = line.split(" ")[0]
        
        if(command == "noop"):
            draw_line()
            cycle +=1
            breakpoint +=1
            


            
        else:
            draw_line()
            cycle +=1
            breakpoint +=1
            
            draw_line()

            addx(x=int(line.split(" ")[1]))
            cycle +=1
            breakpoint +=1


            

    
print(pixel_line)

