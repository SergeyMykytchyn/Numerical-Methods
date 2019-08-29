from flask import Flask, render_template, url_for, flash, redirect, send_file
import numpy as np
import matplotlib.pyplot as plt
import io
import base64
from forms import InputForm

app = Flask(__name__)
app.config['SECRET_KEY'] = '5791628bb0b13ce0c676dfde280ba245'


#a_v = - np.pi / 2
#b_v = np.pi / 2
a_v = 0.01
b_v = 0.1
m_0 = 0
m_n = 0


def f_def(x):
    #return np.cos(x) + x * 0
    return x ** 2 * np.sin(1 / x)


def eps(x, tol=0.25):
    #return tol * np.sin(x)
    return tol * x ** 2 * np.cos(1 / x)


def p(x):
    return 1 / (eps(x) + 1e-4) ** 2


def Genf_(x):
    return f_def(x) + eps(x)


def GraphInit(x):
	Xaxis = np.linspace(a_v, b_v, 1000)
	img = io.BytesIO()
	plt.clf()
	plt.axhline(linestyle = '-', color = 'k')
	plt.axvline(linestyle = '-', color = 'k')
	plt.plot(Xaxis, f_def(Xaxis))
	plt.scatter(x, f_def(x), color='r')
	plt.scatter(x, Genf_(x), color='y')
	plt.legend(['cos(x)'], loc='best')
	plt.savefig(img, format='png')
	img.seek(0)
	plot_url = base64.b64encode(img.getvalue()).decode()
	return plot_url


def GraphRes(x, Xaxis, Yaxis):
	img = io.BytesIO()
	plt.clf()
	plt.axhline(linestyle = '-', color = 'k')
	plt.axvline(linestyle = '-', color = 'k')
	plt.scatter(x, f_def(x), color='r')
	plt.scatter(x, Genf_(x), color='y')
	plt.plot(Xaxis, f_def(Xaxis))
	plt.plot(Xaxis, Yaxis, color='c')
	plt.legend(['cos(x)'], loc='best')
	plt.savefig(img, format='png')
	img.seek(0)
	plot_url_res = base64.b64encode(img.getvalue()).decode()
	return plot_url_res


def GenA(h, N):
    if N == 3:
        return np.array([2 * h / 3]).reshape(1, 1)
    A = np.zeros((N - 2, N - 2))
    A[0, 0] = 2 * h / 3
    A[0, 1] = h / 6
    for i in range(1, N - 3):
        A[i, i - 1] = h / 6
        A[i, i] = 2 * h / 3
        A[i, i + 1] = h / 6
    A[N - 3, N - 4] = h / 6
    A[N - 3, N - 3] = 2 * h / 3
    return A


def GenH(h, N):
    if N == 3:
        return np.array([1 / h, - 2 / h, 1 / h]).reshape(1, 3)
    H = np.zeros((N - 2, N))
    for i in range(0, N - 2):
        H[i, i] = 1 / h
        H[i, i + 1] = - 2 / h
        H[i, i + 2] = 1 / h
    return H


def GenP(x):
    N = len(x)
    P = np.zeros((N, N))
    p_ = p(x)
    for i in range(0, N):
        P[i, i] = p_[i]
    return P


def GenVectors(T):
    N = T.shape[0]
    d = np.ones(N)
    e = np.ones(N - 1)
    f = np.ones(N - 2)
    for i in range(0, N):
        d[i] = T[i, i]
        if i + 1 < N:
            e[i] = T[i, i + 1]
        if i + 2 < N:
            f[i] = T[i, i + 2]
    return d, e, f


def LUdecomp5(d, e, f):
    n = len(d)
    for k in range(n - 2):
        lam = e[k] / d[k]
        d[k + 1] = d[k + 1] - lam * e[k]
        e[k + 1] = e[k + 1] - lam * f[k]
        e[k] = lam
        lam = f[k] / d[k]
        d[k + 2] = d[k + 2] - lam * f[k]
        f[k] = lam
    lam = e[n - 2] / d[n - 2]
    d[n - 1] = d[n - 1] - lam * e[n - 2]
    e[n - 2] = lam
    return d, e, f


def LUsolve5(d, e, f, b_):
    b = b_.copy()
    n = len(d)
    b[1] = b[1] - e[0] * b[0]
    for k in range(2, n):
        b[k] = b[k] - e[k - 1] * b[k - 1] - f[k - 2] * b[k - 2]
    b[n - 1] = b[n - 1] / d[n - 1]
    b[n - 2] = b[n - 2] / d[n - 2] - e[n - 2] * b[n - 1]
    for k in range(n - 3, -1, -1):
        b[k] = b[k] / d[k] - e[k] * b[k + 1] - f[k] * b[k + 2]
    return b


def g(x, v, m, mu, h):
    if x == v[0]:
        return mu[0] + x * 0
    for i in range(1, len(v)):
        if v[i - 1] < x and x < v[i]:
            return m[i - 1] * (v[i] - x) ** 3 / 6 / h + m[i] * (x - v[i - 1]) ** 3 / 6 / h + \
                    (mu[i - 1] - m[i - 1] * h ** 2 / 6) * (v[i] - x) / h + (mu[i] - m[i] * h ** 2 / 6) * (x - v[i - 1]) / h
        elif x == v[i]:
            return mu[i] + x * 0




@app.route("/", methods=['GET', 'POST'])
def home():
	form = InputForm()
	plot_url = None
	plot_url_res = None
	if form.Nv.data != None and form.Nv.data != "":
		N = int(form.Nv.data)

		if N < 3:
			flash('Потрiбно ввести не менше 3 вузлiв', 'danger')
		else:
			h = (b_v - a_v) / (N - 1)
			x = np.linspace(a_v, b_v, N)

			plot_url = GraphInit(x)

			A = GenA(h, N)
			H = GenH(h, N)
			P = GenP(x)
			T = A + H @ np.linalg.inv(P) @ H.T

			if T.shape != (1, 1):
				d, e, f = GenVectors(T)

			f_ = Genf_(x)
			b = H @ f_

			if T.shape != (1, 1):
				d, e, f = LUdecomp5(d, e, f)
				m = LUsolve5(d, e, f, b)
			else:
				m = np.array([b[0] / T[0, 0]])

			mu = f_ - np.linalg.inv(P) @ H.T @ m

			m = np.insert(m, 0, m_0)
			m = np.insert(m, len(m), m_n)

			Xaxis = np.linspace(a_v, b_v, 1000)
			Yaxis = np.empty(len(Xaxis))
			for i in range(len(Xaxis)):
				Yaxis[i] = g(Xaxis[i], x, m, mu, h)

			plot_url_res = GraphRes(x, Xaxis, Yaxis)

	return render_template('home.html', form=form, plot_url=plot_url, plot_url_res=plot_url_res)

if __name__ == '__main__':
	app.run(debug=True)