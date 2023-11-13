file_name= "input.txt"
row_index = 1
num_lines = 0
num_columns = 0 
column_index =1
with open("input.txt") as f:
    num_lines = sum(1 for _ in f) + 2

with open("input.txt") as f:
    lines = [line for line in f]
    
num_columns = len(lines[0].rstrip('\n')) + 2
map = [[-1 for x in range(num_columns)] for y in range(num_lines)]


for line in lines:
    line = line.rstrip('\n')
    for number in line:
        map[row_index][column_index]=int(number)
        column_index += 1
    row_index += 1
    column_index = 1


for row in map:
    print(row)

def isVisible(x:int, y:int, map:list):
    visible_north = check_north(x,y,map)
    visible_south = check_south(x,y,map)
    visible_west = check_west(x,y,map)
    visible_east = check_east(x,y,map)

     

    return (visible_north or visible_south or visible_west or visible_east)

def check_east(x:int, y:int,map:list):
    height_of_tree = map[x][y]
    for i in range(y+1,num_columns-1):
        if map[x][i]>=height_of_tree:
            return False
    return True
def check_west(x:int, y:int,map:list):
    height_of_tree = map[x][y]
    for i in range(0,x):
        if map[i][y]>=height_of_tree:
            return False
    return True
    
def check_north(x:int, y:int,map:list):
    height_of_tree = map[x][y]
    for i in range(0,y):
        if map[x][i]>=height_of_tree:
            return False
    return True
def check_south(x:int, y:int,map:list):
    height_of_tree = map[x][y]
    for i in range(y+1,num_lines):
        if map[x][i]>=height_of_tree:
            return False
    return True


def scenicScore(x:int, y:int,map:list):
    north_score = calc_north_score(x,y,map)
    south_score = calc_south_score(x,y,map)
    west_score = calc_west_score(x,y,map)
    east_score = calc_east_score(x,y,map)
    print(north_score, south_score, west_score, east_score)
    return north_score * south_score * west_score * east_score

def calc_west_score(x:int, y:int,map:list):
    height_of_tree = map[x][y]
    score = 0
    for i in reversed(range(1,y)):
        if map[x][i]<height_of_tree:
            score += 1
        else:
            score += 1
            break
    return score
def calc_east_score(x:int, y:int,map:list):
    height_of_tree = map[x][y]
    score = 0
    for i in range(y+1,num_columns-1):
        if map[x][i]<height_of_tree:
            
            score += 1
        else:
            score += 1
            break
    return score

def calc_north_score(x:int, y:int,map:list):
    height_of_tree = map[x][y]
    score = 0
    for i in range(x-1, 0, -1):
        if map[i][y] < height_of_tree:
            score += 1
        else:
            score += 1
            break
    return score
def calc_south_score(x:int, y:int,map:list):
    height_of_tree = map[x][y]
    score = 0
    for i in range(x+1,num_lines-1):
        if map[i][y]<height_of_tree:
            
            score += 1
        else:
            score += 1
            break
    return score

num_visible_trees = 0
for i in range(1, len(map)-1):
    for j in range(1, len(map[0])-1):
        if(isVisible(i,j,map)):
            num_visible_trees += 1

best_x_cordinate = 0
best_y_cordinate = 0        
# print(num_visible_trees)

for i in range(1, len(map)-1):
    for j in range(1, len(map[0])-1):
       if(scenicScore(i,j,map)>top_score):
           best_x_cordinate = i
           best_y_cordinate = j
           top_score = scenicScore(i,j,map)

print(top_score)
print(best_x_cordinate,best_y_cordinate)

