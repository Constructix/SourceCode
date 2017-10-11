using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var validator = new Validator(this.textBox1.Text, this.textBox2.text);

            if(validator.isValid)
                CreateFile();
        }

        private static void CreateFile(int rowSizes, int ColSizes)
        {
            const int maxRows = 20;
            const int maxCols = 20;

            Bitmap bitMap = new Bitmap(maxRows, maxCols);


            // randomize walls inside
            var r = new Random((int) DateTime.Now.Ticks);
            // Top Line all Black
            for (int x = 0; x < maxRows; x++)
            {
                bitMap.SetPixel(x, 0, Color.Black);
                bitMap.SetPixel(x, maxCols - 1, Color.Black);
            }

            for (int y = 0; y < maxCols; y++)
            {
                bitMap.SetPixel(0, y, Color.Black);
                bitMap.SetPixel(maxCols - 1, y, Color.Black);
            }
            var startColIndex = CreateOpeningInBorder(r, maxCols);

            bitMap.SetPixel(startColIndex, 0, Color.White);

            var endColIndex = CreateOpeningInBorder(r, maxCols);

            bitMap.SetPixel(endColIndex, maxCols - 1, Color.White);


            for (int i = 0; i < 150; i++)
            {
                var colIndex = r.Next(1, maxCols - 2);
                var rowIndex = r.Next(1, maxRows - 2);

                if (colIndex == startColIndex && rowIndex == 1)
                    i--;
                else
                {
                    Color c = bitMap.GetPixel(rowIndex, colIndex);
                    bitMap.SetPixel(rowIndex, colIndex, Color.Black);
                }
            }


            bitMap.Save(@"D:\Files\test.bmp");
        }

        private static int CreateOpeningInBorder(Random r, int maxCols)
        {
            int index = r.Next(1, maxCols - 2);
            return index;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    internal class Validator
    {


        public int RowSize { get; }
        public int ColSize { get; }
        private string text1;
        private object text2;

        public Validator(string text1, string text2)
        {

            int row;
            int col;
            if(!int.TryParse(text1, out row) )
                throw new ArgumentException();
            if(!int.TryParse(text2, out col))
            throw  new ArgumentException();

            RowSize = row;
            ColSize = col;
        }
    }
}
