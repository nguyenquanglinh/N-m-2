from random import randrange
# print(randrange(0,99))
dem=0
f=open("ramdo.csv","w+")
for v in range(5):
    for t in range(2,9,1):
        print("T= ",t)
        re = []
        for c in range(27):
            so = randrange(0, 99)
            re.append(so)
            trr = str(t) + "," + str(so) + "," + "co \n"
            print(trr)
            f.writelines(trr)
            dem += 1
        for x in range(0, 99):
            if x not in re:
                trr = str(t) + "," + str(x) + "," + "khong \n"
                print(trr)
                f.writelines(trr)



print(dem)
f.close()