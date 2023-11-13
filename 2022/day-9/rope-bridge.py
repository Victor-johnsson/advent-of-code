head = (0,0)
tail = (0,0)
space_constant = 10 

set_of_tail_positions = set()

def move_right(head, tail, spaces=2):
    print("Moving right")
    head =(head[0] +1 , head[1])    
    if tail[0] == head[0]-spaces:
        tail = (tail[0] +1, tail[1])
        if head[1] != tail[1]:
            tail=(tail[0],head[1])
    return head, tail

        
def move_left(head, tail, spaces=2):
    print("Moving left")
    head =(head[0] -1 , head[1])    
    if tail[0] == head[0]+spaces:
        tail = (tail[0] - 1, tail[1])
        if head[1] != tail[1]:
            tail=(tail[0],head[1])
    return head, tail

def move_up(head, tail, spaces=2):
    print("Moving up")
    head =(head[0] , head[1] + 1)    

    if tail[1] == head[1]-spaces:
        tail = (tail[0], tail[1] +1)
        if head[0] != tail[0]:
            tail=(head[0],tail[1])
    return head, tail


def move_down(head, tail, spaces=2):
    print("Moving down")
    head =(head[0] , head[1] -1)    

    if tail[1] == head[1]+spaces:
        tail = (tail[0] , tail[1]-1)
        if head[0] != tail[0]:
            tail=(head[0],tail[1])
    return head, tail
    


with open("input.txt") as f:
    for line in f:
        times = int(line.split(" ")[1])
        move = line.split(" ")[0]
        for i in range(times):
            
            if move == "R":
                result = move_right(head, tail, spaces=space_constant)
                head = result[0]
                tail = result[1]
            elif move == "L":
                result =  move_left(head, tail, space_constant)
                head = result[0]
                tail = result[1]
            elif move == "U":
                result = move_up(head, tail, space_constant)
                head = result[0]
                tail = result[1]
            elif move == "D":
                result = move_down(head, tail, space_constant)
                head = result[0]
                tail = result[1]
            else:
                print("Error: Invalid move")
            set_of_tail_positions.add(tail)

print(len(set_of_tail_positions))