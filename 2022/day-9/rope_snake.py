
space_constant = 10 
list_of_knots = [(0,0) for i in range(10)]
set_of_tail_positions = set()

  

def move_right(list, index, spaces=2):
    if index == 0:
        list[index] = (list[index][0] +1 , list[index][1])
        move_right(list, index +1)
        return
    if(index == len(list)):
        return
    knot_to_move = list[index]
    previous = list[index-1]
    if knot_to_move[0] == previous[0]-spaces:
        knot_to_move = (knot_to_move[0] + 1, knot_to_move[1])
        if previous[1] != knot_to_move[1]:
            knot_to_move=(knot_to_move[0],previous[1])
    list[index] = knot_to_move
    move_right(list, index +1)


def move_left(list, index, spaces=2):
    if index == 0:
        list[index] = (list[index][0] -1 , list[index][1])
        move_left(list, index +1)
        return
    if(index == len(list)):
        return
    knot_to_move = list[index]
    previous = list[index-1]
    if knot_to_move[0] == previous[0]+spaces:
        knot_to_move = (knot_to_move[0] - 1, knot_to_move[1])
        if previous[1] != knot_to_move[1]:
            knot_to_move=(knot_to_move[0],previous[1])
    list[index] = knot_to_move
    
    move_left(list, index +1)

        
def move_up(list, index, spaces=2):
    if index == 0:
        list[index] = (list[index][0] , list[index][1] +1 )
        move_up(list, index +1)
        return
    if(index == len(list)):
        return
    knot_to_move = list[index]
    previous = list[index-1]
    if knot_to_move[1] == previous[1]-spaces:
        knot_to_move = (knot_to_move[0]  , knot_to_move[1] +1 )
        if previous[0] != knot_to_move[0]:
            knot_to_move=(previous[0],knot_to_move[1])
    list[index] = knot_to_move
    
    move_up(list, index +1)

def move_down(list, index, spaces=2):
    if index == 0:
        list[index] = (list[index][0] , list[index][1] - 1 )
        move_up(list, index +1)
        return
    if(index == len(list)):
        return
    knot_to_move = list[index]
    previous = list[index-1]
    if knot_to_move[1] == previous[1]+spaces:
        knot_to_move = (knot_to_move[0]  , knot_to_move[1] -1 )
        if previous[0] != knot_to_move[0]:
            knot_to_move=(previous[0],knot_to_move[1])
    list[index] = knot_to_move
    
    move_up(list, index +1)

with open("input.txt") as f:
    for line in f:
        times = int(line.split(" ")[1])
        move = line.split(" ")[0]
        for i in range(times):
            
            if move == "R":
                move_right(list=list_of_knots, index=0)

            elif move == "L":
                move_left(list=list_of_knots, index=0)

            elif move == "U":
                move_up(list=list_of_knots, index=0)

            elif move == "D":
                move_down(list=list_of_knots, index=0)
                
            set_of_tail_positions.add(list_of_knots[-1])

print(len(set_of_tail_positions))