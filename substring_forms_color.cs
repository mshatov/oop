using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = strText.Text;
            string find = findText.Text;
            string res = "";
            List<int> point = new List<int>();

            string invertedFind = "";
            for (int i = 0; i < find.Length; i++)
            {
                char currentSymbol = find[i];
                char invertedSymbol;

                if (char.IsLower(currentSymbol))
                {
                    invertedSymbol = char.ToUpper(currentSymbol);
                }
                else
                { 
                    invertedSymbol = char.ToLower(currentSymbol);
                }

                invertedFind += invertedSymbol;
            }

            char zeroSymbol = find[0];

            for (int i = 0; i < str.Length; i++)
            {
                
                char currentSymbol = str[i];
                string chunkToAdd = char.ToString(currentSymbol);

                if (zeroSymbol == currentSymbol)
                {
                    //+ возможная точка входа

                    bool match = true;

                    for (int j = 1; j < find.Length; j++)
                    {
                        if ((i + j) >= str.Length)
                        {
                            match = false;
                            break;
                        }

                        char currentSymbolFind = find[j];
                        char nextSymbolStr = str[i + j];

                        if (currentSymbolFind != nextSymbolStr)
                        {
                            match = false;
                            break;
                        }
                    }

                    if (match)
                    {
                        point.Add(i);
                        chunkToAdd = invertedFind;
                        i += (find.Length - 1);
                    }

                }
                else
                {
                    //- нет точки входа
                    //эту ветку можно удалить
                }
                res += chunkToAdd;
            }

            resText.Text = res;

            for (int i = 0; i < point.Count; i++)
            {
                resText.SelectionStart = point[i];
                resText.SelectionLength = find.Length;
                resText.SelectionBackColor = colorPick.BackColor;
            }
        }

        private void colorPick_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();

            /*
            Color color = colorDialog.Color;
            byte r = color.R,
                 g = color.G,
                 b = color.B;
            colorPick.BackColor = Color.FromArgb(r, g, b);
            */
            //Color color = colorDialog.Color;

            colorPick.BackColor = colorDialog.Color;

        }
    }
}
