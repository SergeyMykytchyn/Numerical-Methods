using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab2
{
    public partial class Form1 : Form
    {
        double[,] a;
        double[] b;
        int N;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TextReader reader = File.OpenText("input.txt");

            string text = reader.ReadLine();
            string[] bits = text.Split(' ');
            int m, n;
            m = int.Parse(bits[0]);
            n = int.Parse(bits[1]);
            a = new double[m, n];
            b = new double[n];
            N = n;
            for (int i = 0; i < m; i++)
            {
                text = reader.ReadLine();
                bits = text.Split(' ');
                for (int j = 0; j < n; j++)
                {
                    double temp = double.Parse(bits[j]);
                    a[i, j] = temp;
                }
            }

            text = reader.ReadLine();
            text = reader.ReadLine();
            bits = text.Split(' ');

            for (int i = 0; i < n; i++)
            {
                double temp = double.Parse(bits[i]);
                b[i] = temp;
            }

            this.dataGridViewMatrix.ColumnCount = n;

            for(int j = 0; j < n; j++)
            {
                DataGridViewColumn col = dataGridViewMatrix.Columns[j];
                col.Width = 30;
            }

            DataGridViewRow row;

            for (int i = 0; i < m; i++)
            {
                row = new DataGridViewRow();
                row.CreateCells(this.dataGridViewMatrix);

                for (int j = 0; j < n; j++)
                {
                    row.Cells[j].Value = a[i, j];
                }

                this.dataGridViewMatrix.Rows.Add(row);
            }

            row = new DataGridViewRow();
            row.CreateCells(this.dataGridViewMatrix);
            this.dataGridViewMatrix.Rows.Add(row);

            row = new DataGridViewRow();
            row.CreateCells(this.dataGridViewMatrix);

            for (int j = 0; j < n; j++)
            {
                row.Cells[j].Value = b[j];
            }

            this.dataGridViewMatrix.Rows.Add(row);

            // Inverse Matrix
            double[,] aInv = Inv(a);

            this.dataGridViewInvMatrix.ColumnCount = N;

            for (int j = 0; j < N; j++)
            {
                DataGridViewColumn col = dataGridViewInvMatrix.Columns[j];
                col.Width = 50;
            }

            for (int i = 0; i < N; i++)
            {
                row = new DataGridViewRow();
                row.CreateCells(this.dataGridViewInvMatrix);

                for (int j = 0; j < N; j++)
                {
                    row.Cells[j].Value = aInv[i, j];
                }

                this.dataGridViewInvMatrix.Rows.Add(row);
            }

            // show a * aInv

            double[,] I = MultMatrix(a, aInv, N, N, N);

            this.dataGridViewIdentity.ColumnCount = N;

            for (int j = 0; j < N; j++)
            {
                DataGridViewColumn col = dataGridViewIdentity.Columns[j];
                col.Width = 50;
            }

            for (int i = 0; i < N; i++)
            {
                row = new DataGridViewRow();
                row.CreateCells(this.dataGridViewIdentity);

                for (int j = 0; j < N; j++)
                {
                    row.Cells[j].Value = Math.Round(I[i, j], 1);
                }

                this.dataGridViewIdentity.Rows.Add(row);
            }

            double DET;
            DET = determinantOfMatrix(a, N);
            /*LUdecomp(a);
            DET = 1;
            for (int i = 0; i < N; i++)
                DET *= a[i, i];
            DET = Math.Round(DET, 4);*/
            
            labelDET.Text = DET.ToString();

            double cond = MatrixNorm(a, N) * MatrixNorm(aInv, N);

            labelCond.Text = cond.ToString();
            labelNorm.Text = MatrixNorm(a, N).ToString();
        }

        private void choleski_Decomp(double[,] a, double[,] s, double[] d)
        {
            double temp;
            for(int i = 0; i < N; i++)
            {
                temp = 0;
                for (int k = 0; k < i; k++)
                    temp -= s[k, i] * s[k, i] * d[k];
                temp += a[i, i];

                d[i] = temp >= 0 ? 1 : -1;

                s[i, i] = Math.Sqrt(Math.Abs(temp));

                for(int j = i + 1; j < N; j++)
                {
                    temp = 0;
                    for (int k = 0; k < i; k++)
                        temp -= s[k, i] * s[k, j] * d[k];
                    temp += a[i, j];
                    temp /= d[i];
                    temp /= s[i, i];

                    s[i, j] = temp;
                }
            }
        }

        private double[] choleski_Sol(double[,] s, double[] d, double[] x)
        {

            double[] b = new double[N];
            for (int i = 0; i < N; i++)
                b[i] = x[i];

            b[0] = b[0] / s[0, 0] / d[0];
            double temp;
            for(int j = 1; j < N; j++)
            {
                temp = 0;
                for (int k = 0; k < j; k++)
                    temp -= s[k, j] * d[k] * b[k];
                temp += b[j];
                temp /= s[j, j];
                temp /= d[j];

                b[j] = temp;
            }

            for(int j = N - 1; j >= 0; j--)
            {
                temp = 0;
                for (int k = j + 1; k < N; k++)
                    temp -= s[j, k] * b[k];
                temp += b[j];
                temp /= s[j, j];

                b[j] = temp;
            }

            return b;
        }


        private double[] Mult(double[,] a, double[] b)
        {
            double[] c = new double[N];

            for(int i = 0; i < N; i++)
            {
                double temp = 0;
                for (int j = 0; j < N; j++)
                    temp += a[i, j] * b[j];
                c[i] = temp;
            }

            return c;
        }

        private double[,] MultMatrix(double[,] a, double[,] b, int l, int m, int n)
        {
            double[,] c = new double[l, n];
            double temp;
            for(int i = 0; i < l; i++)
                for(int j = 0; j < n; j++)
                {
                    temp = 0;

                    for (int r = 0; r < m; r++)
                        temp += a[i, r] * b[r, j];

                    c[i, j] = temp;
                }
            return c;
        }

        private void btn_CALC_QUAD_Click(object sender, EventArgs e)
        {
            dataGridViewQuadSol.Rows.Clear();
            dataGridViewQuadSol.Refresh();

            dataGridViewQuadMult.Rows.Clear();
            dataGridViewQuadMult.Refresh();

            double[,] s = new double[N, N];
            double[] d = new double[N];

            for(int i = 0; i < N; i++)
            {
                d[i] = 0;
                for (int j = 0; j < N; j++)
                    s[i, j] = 0;
            }

            choleski_Decomp(a, s, d);
            double[] x = choleski_Sol(s, d, b);
            double[] Ax = Mult(a, x);


            for(int i = 0; i < N; i++)
            {
                x[i] = Math.Round(x[i], 4);
                Ax[i] = Math.Round(Ax[i], 4);
            }

            this.dataGridViewQuadSol.ColumnCount = N;
            this.dataGridViewQuadMult.ColumnCount = N;

            DataGridViewRow row;

            row = new DataGridViewRow();
            row.CreateCells(this.dataGridViewQuadSol);

            for (int j = 0; j < N; j++)
            {
                row.Cells[j].Value = x[j];
                DataGridViewColumn col = dataGridViewQuadSol.Columns[j];
                col.Width = 50;
            }

            this.dataGridViewQuadSol.Rows.Add(row);

            row = new DataGridViewRow();
            row.CreateCells(this.dataGridViewQuadMult);

            for (int j = 0; j < N; j++)
            {
                row.Cells[j].Value = Ax[j];
                DataGridViewColumn col = dataGridViewQuadMult.Columns[j];
                col.Width = 50;
            }

            this.dataGridViewQuadMult.Rows.Add(row);
        }

        private void iter_Eqs(double[,] a, double[] b, double[] x)
        {
            double temp;
            for(int i = 0; i < N; i++)
            {
                temp = 0;
                for(int k = 0; k < N; k++)
                {
                    if (k == i)
                        continue;
                    temp -= a[i, k] * x[k];
                }
                temp += b[i];
                temp /= a[i, i];
                x[i] = temp;
            }
        }

        private void gauss_Seidel(double[,] a, double[] b, double[] x, out int iter, double tol = 1e-4)
        {
            double dx;
            iter = 0;
            for(int i = 0; i < 10000; i++)
            {
                double[] xOld = new double[N];
                x.CopyTo(xOld, 0);
                iter_Eqs(a, b, x);
                dx = 0;
                for (int k = 0; k < N; k++)
                    dx += (x[k] - xOld[k]) * (x[k] - xOld[k]);
                dx = Math.Sqrt(dx);
                if (dx < tol)
                {
                    iter = i;
                    return;
                }
            }
            MessageBox.Show("Gauss-Seidel failed to converge");
        }

        private void btn_CALC_SEIDEL_Click(object sender, EventArgs e)
        {
            dataGridViewSeidelSol.Rows.Clear();
            dataGridViewSeidelSol.Refresh();

            dataGridViewSeidelMult.Rows.Clear();
            dataGridViewSeidelMult.Refresh();

            double[] x = new double[N];
            for (int i = 0; i < N; i++)
                x[i] = 0;
            int iter;
            gauss_Seidel(a, b, x, out iter);
            double[] Ax = Mult(a, x);

            for (int i = 0; i < N; i++)
            {
                x[i] = Math.Round(x[i], 4);
                Ax[i] = Math.Round(Ax[i], 4);
            }

            this.dataGridViewSeidelSol.ColumnCount = N;
            this.dataGridViewSeidelMult.ColumnCount = N;

            DataGridViewRow row;

            row = new DataGridViewRow();
            row.CreateCells(this.dataGridViewSeidelSol);

            for (int j = 0; j < N; j++)
            {
                row.Cells[j].Value = x[j];
                DataGridViewColumn col = dataGridViewSeidelSol.Columns[j];
                col.Width = 50;
            }

            this.dataGridViewSeidelSol.Rows.Add(row);

            row = new DataGridViewRow();
            row.CreateCells(this.dataGridViewSeidelMult);

            for (int j = 0; j < N; j++)
            {
                row.Cells[j].Value = Ax[j];
                DataGridViewColumn col = dataGridViewSeidelMult.Columns[j];
                col.Width = 50;
            }

            this.dataGridViewSeidelMult.Rows.Add(row);

            label5.Text = iter.ToString();
        }

        private void LUdecomp(double[,] a)
        {
            for(int k = 0; k < N - 1; k++)
            {
                for(int i = k + 1; i < N; i++)
                {
                    if(a[i, k] != 0.0)
                    {
                        double lam = a[i, k] / a[k, k];

                        for (int j = k + 1; j < N; j++)
                            a[i, j] = a[i, j] - lam * a[k, j];
                        a[i, k] = lam;
                    }
                }
            }
        }

        private void LUsolve(double[,] a, double[] b)
        {
            double temp;
            for(int k = 1; k < N; k++)
            {
                temp = 0;
                for (int j = 0; j < k; j++)
                    temp -= a[k, j] * b[j];
                temp += b[k];
                b[k] = temp;
            }
            b[N - 1] = b[N - 1] / a[N - 1, N - 1];
            for(int k = N - 2; k >= 0; k--)
            {
                temp = 0;
                for (int j = k + 1; j < N; j++)
                    temp -= a[k, j] * b[j];
                temp += b[k];
                temp /= a[k, k];
                b[k] = temp;
            }
        }

        private double[,] Inv(double[,] a)
        {
            double[,] aInv = new double[N, N];
            for(int i = 0; i < N; i++)
                for(int j = 0; j < N; j++)
                {
                    aInv[i, j] = 0;
                    if (i == j)
                        aInv[i, j] = 1;
                }
            double[,] acp = new double[N, N];
            // acp copy
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    acp[i, j] = a[i, j];
            //acp copy
            LUdecomp(acp);
            for(int i = 0; i < N; i++)
            {
                double[] Ib = new double[N];
                for (int k = 0; k < N; k++)
                    Ib[k] = 0;
                Ib[i] = 1;
                LUsolve(acp, Ib);
                for (int j = 0; j < N; j++)
                {
                    aInv[i, j] = Math.Round(Ib[j], 4);
                }
            }
            return aInv;
        }

        private void getCofactor(double[,] mat, double[,] temp, int p, int q, int n)
        {
            int i = 0, j = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (row != p && col != q)
                    {
                        temp[i, j] = mat[row, col];
                        j++;
                        if (j == n - 1)
                        {
                            j = 0;
                            i++;
                        }
                    }
                }
            }
        }

        private double determinantOfMatrix(double[,] mat, int n)
        {
            double D = 0;
            if (n == 1)
                return mat[0, 0];

            double[,] temp = new double[n, n];
            int sign = 1; 
  
            for (int f = 0; f<n; f++) 
            { 

                getCofactor(mat, temp, 0, f, n);
                D += sign * mat[0, f] * determinantOfMatrix(temp, n - 1);
                sign = -sign; 
            } 
  
            return D; 
        }

        private double MatrixNorm(double[,] a, int N)
        {
            double max = 0, temp;
            for(int i = 0; i < N; i++)
            {
                temp = 0;
                for (int j = 0; j < N; j++)
                    temp += Math.Abs(a[i, j]);
                if (temp > max)
                    max = temp;
            }
            return max;
        }
    }
}
