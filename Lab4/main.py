from mpl_toolkits.mplot3d import axes3d
import matplotlib.pyplot as plt

import numpy as np


def f1(x, z0): # one-sheeted hyperboloid
    return x[0] ** 2 - x[1] ** 2 / 9 + z0 ** 2

def f2(x, z0): # elipsoid
    return x[0] ** 2 / 4 + x[1] ** 2 + z0 ** 2 / 9 - 1

def df1_dx(x):
    return 2 * x[0]
def df1_dy(x):
    return - 2 * x[1] / 9
def df2_dx(x):
    return x[0] / 2
def df2_dy(x):
    return 2 * x[1]

def dF(x):
    a = np.empty((len(x), len(x)))
    w = np.array([[df1_dx, df1_dy], [df2_dx, df2_dy]])
    for i in range(len(x)):
        for j in range(len(x)):
            a[i, j] = w[i, j](x)
    return a

def F(x, z0):
    b = np.empty(len(x))
    f = np.array([f1, f2])
    for i in range(len(x)):
        b[i] = f[i](x, z0)
    return b

def gaussElimin(a,b):
    n = len(b)
    # Elimination Phase
    for k in range(0,n-1):
        for i in range(k+1,n):
            if a[i,k] != 0.0:
                lam = a [i,k]/a[k,k]
                a[i,k+1:n] = a[i,k+1:n] - lam*a[k,k+1:n]
                b[i] = b[i] - lam*b[k]
    # Back substitution
    for k in range(n-1,-1,-1):
        b[k] = (b[k] - np.dot(a[k,k+1:n],b[k+1:n]))/a[k,k]
    return b

def NewtonSolve(x0, z0, maxIter=100, tol=1e-4):
    #print('x0', x0)
    #print('F(x0)', F(x0, z0))
    for k in range(maxIter):
        z_k = gaussElimin(dF(x0).copy(), F(x0, z0).copy())
        x_k = x0 - z_k
        #print('x_k', x_k)
        #print('F(x_k)', F(x_k, z0))
        if np.linalg.norm(z_k) < tol:
            return x_k
        x0 = x_k

def Solve(X, Y, z0):
    x = []
    y = []
    for i in range(X.shape[0]):
        for j in range(X.shape[1]):
            x0 = np.array([X[i, j], Y[i, j]])
            try:
                x_sol = NewtonSolve(x0, z0)
                x.append(round(x_sol[0], 2))
                y.append(round(x_sol[1], 2))
            except:
                pass
    return x, y

def data_InterSect(z_N=10):
    z0 = np.linspace(-0.33, 0.33, z_N)
    flag = True
    for i in range(len(z0)):
        x = np.linspace(-2, 2, 10)
        y = np.linspace(-1, 1, 10)
        X, Y = np.meshgrid(x, y)
        x, y = Solve(X, Y, z0[i])
        x = np.array(x)
        x = np.unique(x)
        y = np.array(y)
        y = np.unique(y)
        X, Y = np.meshgrid(x, y)
        z = np.full((len(y), len(x)),  z0[i])
        if flag == True:
            X_res = X
            Y_res = Y
            z_res = z
            flag = False
        else:
            X_res = np.concatenate((X_res, X), axis=1)
            Y_res = np.concatenate((Y_res, Y), axis=1)
            z_res = np.concatenate((z_res, z), axis=1)
    return X_res, Y_res, z_res

X, Y, z = data_InterSect(30)

fig = plt.figure()
ax = fig.add_subplot(111, projection='3d')
ax.scatter(X, Y, z, color='b')

ax.set_xlabel('X Label')
ax.set_ylabel('Y Label')
ax.set_zlabel('Z Label')

plt.show()

