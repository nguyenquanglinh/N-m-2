# To support both python 2 and python 3
#hồi quy tuyến tính hàm số cấp 1
from sklearn import datasets, linear_model
import numpy as np
import matplotlib.pyplot as plt
# bài vd đon gian voi chieu cao quyet dinh can nang
X = np.array([[147, 150, 153, 158, 163, 165, 168, 170, 173, 175, 178, 180, 183]]).T
#x là chiều cao
#y là cân nang weight (kg)
y = np.array([[ 49, 50, 51,  54, 58, 59, 60, 62, 63, 64, 66, 67, 68]]).T
#thuat toan
one = np.ones((X.shape[0], 1))
Xbar = np.concatenate((one, X), axis = 1)

# Calculating weights of the fitting line
A = np.dot(Xbar.T, Xbar)
b = np.dot(Xbar.T, y)
w = np.dot(np.linalg.pinv(A), b)
w = np.dot(np.linalg.pinv(A), b)
print('w = ', w)
# Preparing the fitting line
w_0 = w[0][0]
w_1 = w[1][0]
x0 = np.linspace(145, 185, 2)
print(x0)
y0 = w_0 + w_1*x0
print(y0)

# fit the model by Linear Regression
# regr = linear_model.LinearRegression(fit_intercept=False) # fit_intercept = False for calculating the bias
# regr.fit(Xbar, y)

# Compare two results
# print( 'Solution found by scikit-learn  : ', regr.coef_ )
print( 'Solution found by (5): ', w.T)

plt.plot(X, y, 'b')     # data
plt.plot(x0, y0)
plt.axis([140, 190, 45, 75])
# plt.axis([140, 190, 45, 75])
plt.xlabel('Height (cm)')
plt.ylabel('Weight (kg)')
plt.show()






















# # To support both python 2 and python 3
# from __future__ import division, print_function, unicode_literals
# import numpy as np
# import matplotlib.pyplot as plt
# #-->thư viện vẽ hình
# # height (cm)
# X = np.array([[170,147, 150, 153, 158, 163, 165, 168, 170, 173, 175, 178, 180, 183]]).T
# result=[75,49, 50, 51,  54, 58, 59, 60, 62, 63, 64, 66, 67, 68]
# # for v in X:
# #     BMI=(v[1])/(v[0]*v[0]/10000)
# #     if BMI<19:
# #         result.append(1)
# #     elif BMI>25:
# #         result.append(3)
# #     else:result.append(2)
# print("result",result)
# y = np.array([result]).T
# # Visualize data
# # Building Xbar
# print("y",y)
# print(X.shape[0])
# one = np.ones((X.shape[0], 1))
# Xbar = np.concatenate((one, X), axis = 1)
# print("xbar",Xbar)
# # # Calculating weights of the fitting line
# A = np.dot(Xbar.T, Xbar)
# b = np.dot(Xbar.T, y)
# w = np.dot(np.linalg.pinv(A), b)
# print('w = ', w)
# # Preparing the fitting line
# w_0 = w[0][0]
# xschieu_cao = w[1][0]
# # xscang_nang=w[2][0]
#
# # y1 = chieu_cao*147 + w_0+cang_nang*49
# # print("y1",y1)
# y=2
# chieu_cao=146.5
# # cang_nang=(y-chieu_cao*xschieu_cao-w_0)/xscang_nang
# # print("can_nang",cang_nang)
# # y2 = w_1*160 + w_0
# # print('Predict weight of person with height 155 cm: %.2f (kg), real number: 52 (kg)'%(y1) )
# # print('Predict weight of person with height 160 cm: %.2f (kg), real number: 56 (kg)'  %(y2) )
#
# from sklearn import  linear_model
#
# # fit the model by Linear Regression
# regr = linear_model.LinearRegression(fit_intercept=False) # fit_intercept = False for calculating the bias
# regr.fit(Xbar, y)
#
# # Compare two results
# print( 'Solution found by scikit-learn  : ', regr.coef_)
# print( 'Solution found by (5): ', w.T)
# # Drawing the fitting line
# # plt.plot(X.T, y.T, 'ro')     # data
# # plt.plot(x0, y0)               # the fitting line
# # plt.axis([140, 190, 45, 75])
# # plt.xlabel('Height (cm)')
# # plt.ylabel('Weight (kg)')
# # plt.show()
# # plt.plot(X, y, 'ro')
# # plt.axis([140, 190, 45, 75])
# # plt.xlabel('Height (cm)')
# # plt.ylabel('Weight (kg)')
# # plt.show()
