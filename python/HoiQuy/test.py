print(__doc__)


# Code source: Jaques Grobler
# License: BSD 3 clause

import  pandas as pd
import matplotlib.pyplot as plt
import numpy as np
from sklearn import datasets, linear_model
from sklearn.metrics import mean_squared_error, r2_score

# Load the diabetes dataset
diabetes = datasets.load_diabetes()


# Use only one feature
diabetes_X = diabetes.data[:, np.newaxis, 2]

# Split the data into training/testing sets
diabetes_X_train = diabetes_X[:-20]
diabetes_X_test = diabetes_X[-20:]

# Split the targets into training/testing sets
diabetes_y_train = diabetes.target[:-20]
diabetes_y_test = diabetes.target[-20:]
# Importing the dataset
dataset = pd.read_csv('bmi.csv')
X = dataset.iloc[:, :1].values
y = dataset.iloc[:, 2].values
# Create linear regression object
regr = linear_model.LinearRegression()
print(X,y)
# Train the model using the training sets
regr.fit(X,y)

# Make predictions using the testing set
diabetes_y_pred = regr.predict(X)

# The coefficients
print('Coefficients: \n', regr.coef_)
x=regr.coef_[0]*X[0][0]-y[0]
print(x)
# The mean squared error
print("Mean squared error: %.2f"
      % mean_squared_error(X, diabetes_y_pred))
# Explained variance score: 1 is perfect prediction
print('Variance score: %.2f' % r2_score(X, diabetes_y_pred))

# Plot outputs
plt.scatter(X, y,  color='black')
plt.plot(X, diabetes_y_pred, color='blue', linewidth=1)

plt.xticks(())
plt.yticks(())

plt.show()