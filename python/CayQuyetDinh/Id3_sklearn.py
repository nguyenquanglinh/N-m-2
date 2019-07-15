import numpy as np
import pandas as pd
from sklearn.tree import DecisionTreeClassifier
from sklearn.model_selection import train_test_split

balance_data = pd.read_csv(
'bmi.csv')
X = balance_data.values[:, :2]
Y = balance_data.values[:,-1]
print(X,Y)
X_train, X_test, y_train, y_test = train_test_split( X, Y)
clf_gini = DecisionTreeClassifier()
# print("xtrain",X_train[0])
clf_gini.fit(X, Y)
print(X_train[0])
print(X_train[0],len(X_train))
print("predict(X)",clf_gini.predict(X))
