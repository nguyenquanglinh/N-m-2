bmi=3
dang_nguoi=1
resutf=[]
import  time
import  math
can_nang=30
chieu_cao = 1.

f= open("bmi.csv","w+")
bmi=[]
nhieu=0
chieu_cao_=[]
can_nang_=[]
for u in range(700):
    chieu_cao=1
    for v in range(100):
        nhieu=can_nang/math.pow(chieu_cao,2)
        if nhieu not in bmi:
            bmi.append(nhieu)
            chieu_cao_.append(chieu_cao)
            can_nang_.append(can_nang)
        chieu_cao += 0.01
    can_nang+=0.25
for v in range(len(chieu_cao_)):
    f.writelines(str('%.2f'%can_nang_[v])+","+str('%.2f'%chieu_cao_[v])+","+str('%.4f'%bmi[v])+"\n")
f.close()

# while chieu_cao<2 and can_nang<200:
#     bmi=can_nang/chieu_cao*chieu_cao
#     if bmi < 18.5:
#         dang_nguoi = 1
#     elif bmi >= 18.5 and bmi < 25:
#         dang_nguoi = 2
#     elif bmi >= 25 and bmi < 30:
#         dang_nguoi = 3
#     elif bmi >= 30 and bmi < 35:
#         dang_nguoi = 4
#     elif bmi >= 35 and bmi < 40:
#         dang_nguoi = 5
#     else:
#         dang_nguoi = 6
#     if chieu_cao<2 and can_nang<200:
#         can_nang+=0.25
#


# for v in range(4000):
#     chieu_cao = 1.5
#     # for u in range(350):
#     #     time.sleep(0.01)
#     #     f.writelines("%.3f" % chieu_cao+ ",%.3f" % bmi*chieu_cao*chieu_cao+ ","+ str(dang_nguoi)+"\n")
#     #     chieu_cao+=0.001
#     for u in range(19000):
#         # time.sleep(0.01)
#         # print("%.3f" % chieu_cao + ",%.3f" % math.sqrt(can_nang / bmi))
#         # f.writelines("%.3f" % chieu_cao + ",%.3f" %math.sqrt(can_nang/bmi)  + "," + str(dang_nguoi) + "\n")
#         can_nang+=0.01
#     can_nang=10
#     bmi += 0.1
#
# print(len(resutf))
