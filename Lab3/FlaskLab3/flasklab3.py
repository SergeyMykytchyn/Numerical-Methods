from flask import Flask, render_template, url_for, flash, redirect, send_file
import numpy as np
import matplotlib.pyplot as plt
import io
import base64
from forms import InputForm

app = Flask(__name__)
app.config['SECRET_KEY'] = '5791628bb0b13ce0c676dfde280ba245'


def f(x):
	return np.cos(x)


def GraphInit(Xaxis, Xcheb):
	img = io.BytesIO()
	plt.clf()
	plt.axhline(linestyle = '-', color = 'k')
	plt.axvline(linestyle = '-', color = 'k')
	plt.scatter(Xaxis, f(Xaxis))
	plt.scatter(Xcheb, f(Xcheb), color = 'r')
	plt.legend(['cos(x)'], loc='best')
	plt.savefig(img, format='png')
	img.seek(0)
	plot_url = base64.b64encode(img.getvalue()).decode()
	return plot_url


def Calc_dvdf(Xaxis):
	N = len(Xaxis)
	dvdf_t = np.empty(N)
	for i in range(0, N):
		dvdf_t[i] = f(Xaxis[i])
	dvdf_t_ = dvdf_t.copy()

	for i in range(1, N + 1):
		dvdf_t[i - 1] = dvdf_t_[i - 1]
		t = dvdf_t_[i - 1]
		for j in range(i, N):
			t1 = dvdf_t_[j]
			dvdf_t_[j] = (dvdf_t_[j] - t) / (Xaxis[j] - Xaxis[j - i])
			t = t1
	return dvdf_t	        


def P(x, Xaxis, dvdf, n=0):
	if n == len(Xaxis) - 1:
		return dvdf[n] + x * 0
	return dvdf[n] + (x - Xaxis[n]) * P(x, Xaxis, dvdf, n + 1)


def GraphRes(Xaxis, dvdf, Xcheb, dvdf_cheb):
	img = io.BytesIO()
	plt.clf()
	plt.axhline(linestyle = '-', color = 'k')
	plt.axvline(linestyle = '-', color = 'k')
	XaxisN = np.linspace(-np.pi / 2, np.pi / 2, 20)

	plt.scatter(Xaxis, f(Xaxis))
	plt.plot(XaxisN, P(XaxisN, Xaxis, dvdf))

	plt.scatter(Xcheb, f(Xcheb), color='r')
	plt.plot(XaxisN, P(XaxisN, Xcheb, dvdf_cheb), color='r')

	plt.legend(['cos(x)'], loc='best')
	plt.savefig(img, format='png')
	img.seek(0)
	plot_url_res = base64.b64encode(img.getvalue()).decode()
	return plot_url_res


def r(x, Xaxis, dvdf):
    return f(x) - P(x, Xaxis, dvdf)


def fact(n):
    if n < 2:
        return 1
    return n * fact(n - 1)


def omega(x, Xaxis):
	n = len(Xaxis)
	mul = 1
	for i in range(0, n):
		mul *= (x - Xaxis[i])
	return mul


def tol(x, Xaxis):
    n = len(Xaxis)
    return abs(omega(x, Xaxis)) / fact(n)



def Gen_Cheb(N):
	x = np.empty(N)
	for i in range(N):
		x[i] = np.cos((2 * i + 1) * np.pi / 2 / N)
	return x

@app.route("/", methods=['GET', 'POST'])
def home():
	form = InputForm()
	plot_url = None
	plot_url_res = None
	Rn = None
	Tol_maxInd = None
	Tol = None
	cheb = None
	if form.vectorX.data != None and form.vectorX.data != "":
		strV = form.vectorX.data.split(" ")
		Xaxis = []
		for i in strV:
			Xaxis.append(float(i))

		Xaxis = np.array(Xaxis)
		Xcheb = Gen_Cheb(len(Xaxis))

		plot_url = GraphInit(Xaxis, Xcheb)

		dvdf = Calc_dvdf(Xaxis)
		dvdf_cheb = Calc_dvdf(Xcheb)

		plot_url_res = GraphRes(Xaxis, dvdf, Xcheb, dvdf_cheb)

		XaxisN = np.linspace(-np.pi / 2, np.pi / 2, 20)
		Rn = max(abs(r(XaxisN, Xaxis, dvdf)))
		maxInd = np.argmax(abs(r(XaxisN, Xaxis, dvdf)))
		Tol_maxInd = tol(XaxisN[maxInd], Xaxis)
		Tol = max(tol(XaxisN, Xaxis))
		N = len(Xaxis)
		cheb = (np.pi) ** N / 2 ** (2 * N - 1) / fact(N)
		#cheb = np.pi ** N / 2 ** (2 * N - 1)
		#flash(f'Vector read {Xaxis[0]}!', 'success')
	    #return redirect(url_for('home'))
	return render_template('home.html', form=form, plot_url=plot_url, plot_url_res=plot_url_res, Rn=Rn, 
		Tol_maxInd=Tol_maxInd, Tol=Tol, cheb=cheb)


if __name__ == '__main__':
	app.run(debug=True)