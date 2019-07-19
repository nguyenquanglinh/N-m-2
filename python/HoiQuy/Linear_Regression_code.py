import numpy as np
import pandas as pd
dataset = pd.read_csv('bmi.csv')
print(dataset)
X = dataset.iloc[:, :2].values
print("x_ \n",X)

y = dataset.iloc[:, 2:3].values
print("y= \n",y)
one = np.ones((X.shape[0], 1))
Xbar = np.concatenate((one, X), axis = 1)
# Calculating weights of the fitting line
A = np.dot(Xbar.T, Xbar)
b = np.dot(Xbar.T, y)
w = np.dot(np.linalg.pinv(A), b)
print('w = ', w)
w_0 = w[0][0]
w_1 = w[1][0]
w_2=w[2][0]
y=30*w_1+w_0+w_2*1.01
print("y= ",y)
print("-----------------------sklearn-------------")
y=dataset.iloc[:, 2].values
print("y= \n",y)
from sklearn.linear_model import LinearRegression
lin_reg = LinearRegression()
one = np.ones((X.shape[0], 1))
Xbar = np.concatenate((one, X), axis = 1)
lin_reg.fit(X,y)
lin_reg.predict(X)
print(lin_reg.coef_)
# print('y',y)
# from sklearn import datasets, linear_model
# regr = linear_model.LinearRegression(fit_intercept=False) # fit_intercept = False for calculating the bias
# regr.fit(Xbar, y)
# print( 'Solution found by scikit-learn  : ', regr.coef_ )

# import matplotlib.pyplot as plt
# ox=X.T[0]
# oy=X.T[1]
# bMi=np.linspace(20,27,2)
# chieu_cao=np.linspace(145,185,2)
# can_nang=bMi*chieu_cao*chieu_cao/10000
# # y0=y1/(x0*x0)
# plt.plot(X, y, 'ro')     # data
# plt.plot(chieu_cao, can_nang)
# plt.axis([140, 190, 45, 75])
# # plt.axis([140, 190, 45, 75])
# plt.xlabel('chieu_cao (cm)')
# plt.ylabel('can_nang (kg)')
# plt.show()
# plt.plot(ox, oy, 'r')
# plt.plot(ox[0], oy[0])
# # plt.axis([140, 190, 45, 75])
# plt.xlabel('Height (cm)')
# plt.ylabel('Weight (kg)')
# plt.show()
# data
# plt.plot(x0, y0)
# ax = plt.axes(projection='3d')
# ax.scatter3D(ox, oy,result)
# ax.set_xlabel('x')
# ax.set_ylabel('y')
# ax.set_zlabel('z');
