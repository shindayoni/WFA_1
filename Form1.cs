using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        int i = 0;
        
        private void button1_Click(object sender, EventArgs e)
        {
            label8.Text = "";

            if (numericUpDown4.Value < numericUpDown5.Value) {

                label8.Text = "Макс. Значение не м.б. меньше мин. значения...";

                return;

            }

            int count; 

            int current = 0;

            count = (Convert.ToInt32(numericUpDown2.Value) - Convert.ToInt32(numericUpDown1.Value)) / Convert.ToInt32(numericUpDown3.Value) + 1;

            for (int n = Convert.ToInt32(numericUpDown1.Value); n <= Convert.ToInt32(numericUpDown2.Value); n += Convert.ToInt32(numericUpDown3.Value))
            {
                int[] array = new int[n];

                Random rand = new Random();

                for (int j = 0; j < n; j++)
                {
                    array[j] = rand.Next(Convert.ToInt32(numericUpDown5.Value), Convert.ToInt32(numericUpDown4.Value));
                }

                if (checkBox1.Checked)
                {
                    dataGridView1.ColumnCount = n + 1;

                    dataGridView1.Rows.Add();

                    dataGridView1.Rows[i].Cells[0].Value = "Исходный массив";

                    for (int j = 0; j < n; j++)
                    {
                        dataGridView1.Rows[i].Cells[j + 1].Value = array[j];
                    }

                    i++;
                }

                sortedArray(array, n);

                current++;

                progressBar1.Value = 100 * (current / count);
            }
        }

        private void sortedArray(int[] a, int n)
        {
            int k = 0;

            int swp = 0; // swap
            
            int m = 0;

            int cmn = 0; // comparison

            for (int j = 0; j < n; j++)
            {
                if (a[j] == 0) k++;

                else a[j - k] = a[j];
            }
            n -= k;

            cmn += n;

            if (n == 0)
            {
                label8.Text = "В массиве одни нули...";

                return;
            }

            for (m = 0; m < n - 1; m++)
            {
                for (int j = m + 1; j < n; j++)
                {
                    if (a[m] > 0 && a[j] > 0 && a[m] < a[j])
                    {
                        swapInArray(ref a[m], ref a[j]);

                        swp++;
                    }

                    if (a[m] < 0 && a[j] < 0 && a[m] > a[j])
                    {
                        swapInArray(ref a[m], ref a[j]);

                        swp++;
                    }

                    cmn += 6;
                }
            }

            if (checkBox1.Checked)
            {
                dataGridView1.AutoResizeColumns();

                dataGridView1.Rows.Add();

                dataGridView1.Rows[i].Cells[0].Value = "Получен массив";

                for (int j = 0; j < n; j++)
                {
                    dataGridView1.Rows[i].Cells[j + 1].Value = a[j];
                }

                i++;
            }

            if (Convert.ToInt32(numericUpDown1.Value) == Convert.ToInt32(numericUpDown2.Value))
            {
                label8.Text = "Количество сравнений = " + Convert.ToString(cmn) + ". Количество обменов = " + Convert.ToString(swp);
            }
            
            if (checkBox2.Checked)
            {
                chart1.Series[0].Points.AddXY(n, cmn);

                chart2.Series[0].Points.AddXY(n, swp);
            }
        }

        void swapInArray(ref int x, ref int y)
        {
            int z = x;

            x = y;
            
            y = z;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();

            chart2.Series[0].Points.Clear();

            dataGridView1.Rows.Clear();

            dataGridView1.Columns.Clear();

            progressBar1.Value = 0;

            i = 0;

            button2.Enabled = true;
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {

            /* numericUpDown6 - макс-е значение. numericUpDown7 - мин-е значение.
             * numericUpDown8 - размерность матрицы (N x N).
             */

            button3.Enabled = false;

            if (numericUpDown6.Value < numericUpDown7.Value)
            {
                label17.Text = "Макс-е значение не м.б. меньше мин-го значения...";
                return;
            }

            int n = Convert.ToInt32(numericUpDown8.Value);

            int[,] matrix = new int[n, n];

            Random rand = new Random();

            dataGridView2.AutoResizeColumns();

            dataGridView2.ColumnCount = n;

            // Формирование матрицы.
            for (int i = 0; i < n; i++)
            {
                dataGridView2.Rows.Add();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rand.Next(Convert.ToInt32(numericUpDown7.Value), Convert.ToInt32(numericUpDown6.Value));

                    dataGridView2.Rows[i].Cells[j].Value = matrix[i, j];
                }
            }



            //    dataGridView3.AutoResizeColumns();

            //    dataGridView3.ColumnCount = n;

            //    for (int i = 0; i <= n - k; i++)
            //    {
            //        dataGridView3.Rows.Add();

            //        for (int j = 0; j < n; j++)
            //        {
            //            dataGridView3.Rows[i].Cells[j].Value = matrix[i, j];
            //        }
            //    }
            //}

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
//int q = 0; 

//int k = 0; // Счётчик строк.

//if (matrix[n - 1, n - 1] < 0) k++;

//for (q = 0; q < n - 1; q++)
//{
//    if (matrix[q, n - 1] < 0)
//    {
//        k++;

//        for (int i = q; i < n - 1; i++)
//        {
//            for (int j = 0; j < n; j++)
//            {
//                matrix[i, j] = matrix[i + 1, j];
//            }
//        }

//        q--;
//    }

//    if ((k + q + 1) == n)
//    {
//        break;
//    }
//}

//if (k == n)
//{
//    label17.Text = "В матрице удалены все строки...";

//    return;
//}

//if (k == 0)
//{
//    label17.Text = "В матрице нет удаленных строк";

//    return;
//}

//label17.Text = $"В матрице удалено {k} строк(а)";

//for (int j = 0; j < n; j++)
//{
//    matrix[n - k, j] = 0;

//    for (int i = 0; i < n - k; i++)
//    {
//        matrix[n - k, j] += matrix[i, j];
//    }
//}