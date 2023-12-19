using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cg_lab89.MathUtils
{
    public class MatrixUtils
    {
        public int n { get; set; }
        public int m { get; set; }
        public double[,] matrix { get; set; }
        public MatrixUtils(int _n, int _m)
        {
            n = _n;
            m = _m;
            matrix = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = 0;
                }
            }
        }

        public MatrixUtils(int _n, int _m, params double[] list)
        {
            n = _n;
            m = _m;
            if(list.Length != n * m) throw new InvalidOperationException ("Неверное число элементов!");
            var data = list.ToArray();
            matrix = new double[n, m];
            int iter = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = data[iter];
                    iter += 1;
                }
            }
        }

        public MatrixUtils(int _n, int _m, double[,] list)
        {
            n = _n;
            m = _m;
            matrix = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = list[i,j];
                }
            }
        }

        public static MatrixUtils operator *(MatrixUtils m, double c)
        {
            MatrixUtils m1 = new MatrixUtils(m.n, m.m);
            for (int i = 0; i < m.n; ++i)
            {
                for (int j = 0; j < m.m; ++j)
                {
                    m1.matrix[i, j] = m.matrix[i, j] * c;
                }
            }
            return m1;
        }

        public static MatrixUtils operator *(MatrixUtils m1, MatrixUtils m2)
        {
            int m1Rows = m1.n;
            int m1Cols = m1.m;
            int m2Rows = m2.n;
            int m2Cols = m2.m;
            if (m1Cols != m2Rows)
                throw new InvalidOperationException
                  ("Столбцы и строки не сходятся!");
            MatrixUtils res = new MatrixUtils(m1Rows, m2Cols);

            for (int i = 0; i < m1Rows; i++)
            {
                for (int j = 0; j < m2Cols; j++)
                {
                    for (int k = 0; k < m1Cols; k++)
                    {
                        res.matrix[i, j] += m1.matrix[i, k] * m2.matrix[k, j]; 
                    }
                }
            }
            return res;
        }

        public static MatrixUtils Transpose(MatrixUtils m1)
        {
            MatrixUtils res = new MatrixUtils(m1.n, m1.m);

            for (int i = 0; i < m1.n; i++)
            {
                for (int j = 0; j < m1.m; j++)
                {
                    res.matrix[j, i] = m1.matrix[i, j];
                }
            }

            return res;
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {

                    result += matrix[i, j].ToString() + " ";
                }
                result += "\n";
            }
            return string.Concat($"Матрица размером {n}x{m}\n{result}");
        }
    }
}
