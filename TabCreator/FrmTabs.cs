using iTextSharp.text;
using iTextSharp.text.pdf;
using Root.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabCreator
{
    public partial class FrmTabs : Form
    {
        public string[] corda1 = new string[0];
        public string[] corda2 = new string[0];
        public string[] corda3 = new string[0];
        public string[] corda4 = new string[0];
        public string[] corda5 = new string[0];
        public string[] corda6 = new string[0];
        public string[] cordaAux1 = new string[0];
        public string[] cordaAux2 = new string[0];
        public string[] cordaAux3 = new string[0];
        public string[] cordaAux4 = new string[0];
        public string[] cordaAux5 = new string[0];
        public string[] cordaAux6 = new string[0];
        private string pulaLinha = "", ProjectFile;
        private bool toca = true, fim = false, saved, exist, load, isMultiple, X, H;
        private int notasNaLabel = 0, qtdNotasTxt, qtdNotas = 0;
        private NotasTab tab;
        int aux = 0, aux2 = 0, aux3 = 0, aux4 = 0, aux5 = 0, aux6 = 0, corda;

        public FrmTabs(string file)
        {
            InitializeComponent();

            txtTab.Text = "";

            if (File.Exists(file))
            {
                exist = true;

                var aux = File.ReadAllLines(file);

                var acorda1 = aux[0].Split(' ');
                var acorda2 = aux[1].Split(' ');
                var acorda3 = aux[2].Split(' ');
                var acorda4 = aux[3].Split(' ');
                var acorda5 = aux[4].Split(' ');
                var acorda6 = aux[5].Split(' ');

                for (int i = 0; i < acorda6.Length - 1; i ++)
                {
                    Array.Resize(ref corda1, i + 1);
                    Array.Resize(ref corda2, i + 1);
                    Array.Resize(ref corda3, i + 1);
                    Array.Resize(ref corda4, i + 1);
                    Array.Resize(ref corda5, i + 1);
                    Array.Resize(ref corda6, i + 1);

                    corda1[i] = acorda1[i] + " ";
                    corda2[i] = acorda2[i] + " ";
                    corda3[i] = acorda3[i] + " ";
                    corda4[i] = acorda4[i] + " ";
                    corda5[i] = acorda5[i] + " ";
                    corda6[i] = acorda6[i] + " ";
                    
                }
                atualizaTab();
                qtdNotas = corda1.Length;
                notasNaLabel = corda6.Length - 1;
                ProjectFile = file;
                load = true;
            }
            else
            {
                exist = false;
                corda1 = new string[1];
                corda2 = new string[1];
                corda3 = new string[1];
                corda4 = new string[1];
                corda5 = new string[1];
                corda6 = new string[1];
                qtdNotas = 0;
                load = false;
            }
        }

        private void FrmTabs_Load(object sender, EventArgs e)
        {
            cmbTempo.SelectedIndex = 0;
            pcbBarraVermelha.Visible = false;
            btnPlay.Visible = true;
            btPause.Visible = false;
            btnPlay.Enabled = true;
            btPause.Enabled = true;
            isMultiple = false;
            X = false;
            H = false;
        }

        #region btnNotas_Click
        private void btnX_Click(object sender, EventArgs e)
        {
            if (isMultiple == false)
            {
                Array.Resize(ref corda1, corda1.Length + 1);
                Array.Resize(ref corda2, corda2.Length + 1);
                Array.Resize(ref corda3, corda3.Length + 1);
                Array.Resize(ref corda4, corda4.Length + 1);
                Array.Resize(ref corda5, corda5.Length + 1);
                Array.Resize(ref corda6, corda6.Length + 1);
                corda1[qtdNotas] = "-X-- ";
                corda2[qtdNotas] = "-X-- ";
                corda3[qtdNotas] = "-X-- ";
                corda4[qtdNotas] = "-X-- ";
                corda5[qtdNotas] = "-X-- ";
                corda6[qtdNotas] = "-X-- ";
                qtdNotas++; atualizaTab();
            }
        }

        private void corda1_click(int num)
        {
            if (isMultiple == false)
            {
                Array.Resize(ref corda1, corda1.Length + 1);
                Array.Resize(ref corda2, corda2.Length + 1);
                Array.Resize(ref corda3, corda3.Length + 1);
                Array.Resize(ref corda4, corda4.Length + 1);
                Array.Resize(ref corda5, corda5.Length + 1);
                Array.Resize(ref corda6, corda6.Length + 1);
                if (X == true)
                {
                    corda1[qtdNotas] = "X--- ";
                    corda2[qtdNotas] = "---- ";
                    corda3[qtdNotas] = "---- ";
                    corda4[qtdNotas] = "---- ";
                    corda5[qtdNotas] = "---- ";
                    corda6[qtdNotas] = "---- ";
                }
                if (H == true)
                {
                    if (num < 10)
                    {
                        corda1[qtdNotas] = "<" + num + ">- ";
                        corda2[qtdNotas] = "---- ";
                        corda3[qtdNotas] = "---- ";
                        corda4[qtdNotas] = "---- ";
                        corda5[qtdNotas] = "---- ";
                        corda6[qtdNotas] = "---- ";
                    }
                    else
                    {
                        corda1[qtdNotas] = "<" + num + "> ";
                        corda2[qtdNotas] = "---- ";
                        corda3[qtdNotas] = "---- ";
                        corda4[qtdNotas] = "---- ";
                        corda5[qtdNotas] = "---- ";
                        corda6[qtdNotas] = "---- ";
                    }
                }
                if (X == false && H == false)
                {
                    if (num < 10)
                    {
                        corda1[qtdNotas] = num + "--- ";
                        corda2[qtdNotas] = "---- ";
                        corda3[qtdNotas] = "---- ";
                        corda4[qtdNotas] = "---- ";
                        corda5[qtdNotas] = "---- ";
                        corda6[qtdNotas] = "---- ";
                    }
                    else
                    {
                        corda1[qtdNotas] = num + "-- ";
                        corda2[qtdNotas] = "---- ";
                        corda3[qtdNotas] = "---- ";
                        corda4[qtdNotas] = "---- ";
                        corda5[qtdNotas] = "---- ";
                        corda6[qtdNotas] = "---- ";
                    }
                }
                qtdNotas++; atualizaTab();
            }
            else
            {
                Array.Resize(ref corda1, corda1.Length + 1);
                if (X == true)
                {
                    corda1[qtdNotas] = "X--- ";
                }
                if (H == true)
                {
                    if (num < 10)
                        corda1[qtdNotas] = "<"+num+">- ";
                    else
                        corda1[qtdNotas] = "<" + num + "> ";
                }
                if (X == false && H == false)
                {
                    if (num < 10)
                        corda1[qtdNotas] = num+"--- ";
                    else
                        corda1[qtdNotas] = num + "-- ";
                }
            }
        }

        private void corda2_click(int num)
        {
            if (isMultiple == false)
            {
                Array.Resize(ref corda1, corda1.Length + 1);
                Array.Resize(ref corda2, corda2.Length + 1);
                Array.Resize(ref corda3, corda3.Length + 1);
                Array.Resize(ref corda4, corda4.Length + 1);
                Array.Resize(ref corda5, corda5.Length + 1);
                Array.Resize(ref corda6, corda6.Length + 1);
                if (X == true)
                {
                    corda1[qtdNotas] = "---- ";
                    corda2[qtdNotas] = "X--- ";                
                    corda3[qtdNotas] = "---- ";
                    corda4[qtdNotas] = "---- ";
                    corda5[qtdNotas] = "---- ";
                    corda6[qtdNotas] = "---- ";
                }
                if (H == true)
                {
                    if (num < 10)
                    {                  
                        corda1[qtdNotas] = "---- ";
                        corda2[qtdNotas] = "<" + num + ">- ";
                        corda3[qtdNotas] = "---- ";
                        corda4[qtdNotas] = "---- ";
                        corda5[qtdNotas] = "---- ";
                        corda6[qtdNotas] = "---- ";
                    }
                    else
                    {
                        corda1[qtdNotas] = "---- ";
                        corda2[qtdNotas] = "<" + num + "> ";
                        corda3[qtdNotas] = "---- ";
                        corda4[qtdNotas] = "---- ";
                        corda5[qtdNotas] = "---- ";
                        corda6[qtdNotas] = "---- ";
                    }
                }
                if (X == false && H == false)
                {
                    if (num < 10)
                    {
                        corda1[qtdNotas] = "---- ";
                        corda2[qtdNotas] = num + "--- ";
                        corda3[qtdNotas] = "---- ";
                        corda4[qtdNotas] = "---- ";
                        corda5[qtdNotas] = "---- ";
                        corda6[qtdNotas] = "---- ";
                    }
                    else
                    {
                        corda1[qtdNotas] = "---- ";
                        corda2[qtdNotas] = num + "-- ";
                        corda3[qtdNotas] = "---- ";
                        corda4[qtdNotas] = "---- ";
                        corda5[qtdNotas] = "---- ";
                        corda6[qtdNotas] = "---- ";
                    }
                }
                qtdNotas++; atualizaTab();
            }
            else
            {
                Array.Resize(ref corda2, corda2.Length + 1);
                if (X == true)
                {
                    corda2[qtdNotas] = "X--- ";
                }
                if (H == true)
                {
                    if (num < 10)
                        corda2[qtdNotas] = "<" + num + ">- ";
                    else
                        corda2[qtdNotas] = "<" + num + "> ";
                }
                if (X == false && H == false)
                {
                    if (num < 10)
                        corda2[qtdNotas] = num + "--- ";
                    else
                        corda2[qtdNotas] = num + "-- ";
                }
            }
        }

        private void corda3_click(int num)
        {
            if (isMultiple == false)
            {
                Array.Resize(ref corda1, corda1.Length + 1);
                Array.Resize(ref corda2, corda2.Length + 1);
                Array.Resize(ref corda3, corda3.Length + 1);
                Array.Resize(ref corda4, corda4.Length + 1);
                Array.Resize(ref corda5, corda5.Length + 1);
                Array.Resize(ref corda6, corda6.Length + 1);
                if (X == true)
                {
                    corda2[qtdNotas] = "---- ";
                    corda1[qtdNotas] = "---- ";
                    corda3[qtdNotas] = "X--- ";
                    corda4[qtdNotas] = "---- ";
                    corda5[qtdNotas] = "---- ";
                    corda6[qtdNotas] = "---- ";
                }
                if (H == true)
                {
                    if (num < 10)
                    {
                        corda2[qtdNotas] = "---- ";
                        corda1[qtdNotas] = "---- ";
                        corda3[qtdNotas] = "<" + num + ">- ";
                        corda4[qtdNotas] = "---- ";
                        corda5[qtdNotas] = "---- ";
                        corda6[qtdNotas] = "---- ";
                    }
                    else
                    {
                        corda2[qtdNotas] = "---- ";
                        corda1[qtdNotas] = "---- ";
                        corda3[qtdNotas] = "<" + num + "> ";
                        corda4[qtdNotas] = "---- ";
                        corda5[qtdNotas] = "---- ";
                        corda6[qtdNotas] = "---- ";
                    }
                }
                if (X == false && H == false)
                {
                    if (num < 10)
                    {
                        corda2[qtdNotas] = "---- ";
                        corda1[qtdNotas] = "---- ";
                        corda3[qtdNotas] = num + "--- ";
                        corda4[qtdNotas] = "---- ";
                        corda5[qtdNotas] = "---- ";
                        corda6[qtdNotas] = "---- ";
                    }
                    else
                    {
                        corda2[qtdNotas] = "---- ";
                        corda1[qtdNotas] = "---- ";
                        corda3[qtdNotas] = num + "-- ";
                        corda4[qtdNotas] = "---- ";
                        corda5[qtdNotas] = "---- ";
                        corda6[qtdNotas] = "---- ";
                    }
                }
                qtdNotas++; atualizaTab();
            }
            else
            {
                Array.Resize(ref corda3, corda3.Length + 1);
                if (X == true)
                {
                    corda3[qtdNotas] = "X--- ";
                }
                if (H == true)
                {
                    if (num < 10)
                        corda3[qtdNotas] = "<" + num + ">- ";
                    else
                        corda3[qtdNotas] = "<" + num + "> ";
                }
                if (X == false && H == false)
                {
                    if (num < 10)
                        corda3[qtdNotas] = num + "--- ";
                    else
                        corda3[qtdNotas] = num + "-- ";
                }
            }
        }

        private void corda4_click(int num)
        {
            if (isMultiple == false)
            {
                Array.Resize(ref corda1, corda1.Length + 1);
                Array.Resize(ref corda2, corda2.Length + 1);
                Array.Resize(ref corda3, corda3.Length + 1);
                Array.Resize(ref corda4, corda4.Length + 1);
                Array.Resize(ref corda5, corda5.Length + 1);
                Array.Resize(ref corda6, corda6.Length + 1);
                if (X == true)
                {
                    corda2[qtdNotas] = "---- ";
                    corda3[qtdNotas] = "---- ";
                    corda1[qtdNotas] = "---- ";
                    corda4[qtdNotas] = "X--- ";
                    corda5[qtdNotas] = "---- ";
                    corda6[qtdNotas] = "---- ";
                }
                if (H == true)
                {
                    if (num < 10)
                    {
                        corda2[qtdNotas] = "---- ";
                        corda3[qtdNotas] = "---- ";
                        corda1[qtdNotas] = "---- ";
                        corda4[qtdNotas] = "<" + num + ">- ";
                        corda5[qtdNotas] = "---- ";
                        corda6[qtdNotas] = "---- ";
                    }
                    else
                    {
                        corda2[qtdNotas] = "---- ";
                        corda3[qtdNotas] = "---- ";
                        corda1[qtdNotas] = "---- ";
                        corda4[qtdNotas] = "<" + num + "> ";
                        corda5[qtdNotas] = "---- ";
                        corda6[qtdNotas] = "---- ";
                    }
                }
                if (X == false && H == false)
                {
                    if (num < 10)
                    {
                        corda2[qtdNotas] = "---- ";
                        corda3[qtdNotas] = "---- ";
                        corda1[qtdNotas] = "---- ";
                        corda4[qtdNotas] = num + "--- ";
                        corda5[qtdNotas] = "---- ";
                        corda6[qtdNotas] = "---- ";
                    }
                    else
                    {
                        corda2[qtdNotas] = "---- ";
                        corda3[qtdNotas] = "---- ";
                        corda1[qtdNotas] = "---- ";
                        corda4[qtdNotas] = num + "-- ";
                        corda5[qtdNotas] = "---- ";
                        corda6[qtdNotas] = "---- ";
                    }
                }
                qtdNotas++; atualizaTab();
            }
            else
            {
                Array.Resize(ref corda4, corda4.Length + 1);
                if (X == true)
                {
                    corda4[qtdNotas] = "X--- ";
                }
                if (H == true)
                {
                    if (num < 10)
                        corda4[qtdNotas] = "<" + num + ">- ";
                    else
                        corda4[qtdNotas] = "<" + num + "> ";
                }
                if (X == false && H == false)
                {
                    if (num < 10)
                        corda4[qtdNotas] = num + "--- ";
                    else
                        corda4[qtdNotas] = num + "-- ";
                }
            }
        }

        private void corda5_click(int num)
        {
            if (isMultiple == false)
            {
                Array.Resize(ref corda1, corda1.Length + 1);
                Array.Resize(ref corda2, corda2.Length + 1);
                Array.Resize(ref corda3, corda3.Length + 1);
                Array.Resize(ref corda4, corda4.Length + 1);
                Array.Resize(ref corda5, corda5.Length + 1);
                Array.Resize(ref corda6, corda6.Length + 1);
                if (X == true)
                {
                    corda2[qtdNotas] = "---- ";
                    corda3[qtdNotas] = "---- ";
                    corda4[qtdNotas] = "---- ";
                    corda1[qtdNotas] = "---- ";
                    corda5[qtdNotas] = "X--- ";
                    corda6[qtdNotas] = "---- ";
                }
                if (H == true)
                {
                    if (num < 10)
                    {
                        corda2[qtdNotas] = "---- ";
                        corda3[qtdNotas] = "---- ";
                        corda4[qtdNotas] = "---- ";
                        corda1[qtdNotas] = "---- ";
                        corda5[qtdNotas] = "<" + num + ">- ";
                        corda6[qtdNotas] = "---- ";
                    }
                    else
                    {
                        corda2[qtdNotas] = "---- ";
                        corda3[qtdNotas] = "---- ";
                        corda4[qtdNotas] = "---- ";
                        corda1[qtdNotas] = "---- ";
                        corda5[qtdNotas] = "<" + num + "> ";
                        corda6[qtdNotas] = "---- ";
                    }
                }
                if (X == false && H == false)
                {
                    if (num < 10)
                    {
                        corda2[qtdNotas] = "---- ";
                        corda3[qtdNotas] = "---- ";
                        corda4[qtdNotas] = "---- ";
                        corda1[qtdNotas] = "---- ";
                        corda5[qtdNotas] = num + "--- ";
                        corda6[qtdNotas] = "---- ";
                    }
                    else
                    {
                        corda2[qtdNotas] = "---- ";
                        corda3[qtdNotas] = "---- ";
                        corda4[qtdNotas] = "---- ";
                        corda1[qtdNotas] = "---- ";
                        corda5[qtdNotas] = num + "-- ";
                        corda6[qtdNotas] = "---- ";
                    }
                }
                qtdNotas++; atualizaTab();
            }
            else
            {
                Array.Resize(ref corda5, corda5.Length + 1);
                if (X == true)
                {
                    corda5[qtdNotas] = "X--- ";
                }
                if (H == true)
                {
                    if (num < 10)
                        corda5[qtdNotas] = "<" + num + ">- ";
                    else
                        corda5[qtdNotas] = "<" + num + "> ";
                }
                if (X == false && H == false)
                {
                    if (num < 10)
                        corda5[qtdNotas] = num + "--- ";
                    else
                        corda5[qtdNotas] = num + "-- ";
                }
            }
        }

        private void corda6_click(int num)
        {
            if (isMultiple == false)
            {
                Array.Resize(ref corda1, corda1.Length + 1);
                Array.Resize(ref corda2, corda2.Length + 1);
                Array.Resize(ref corda3, corda3.Length + 1);
                Array.Resize(ref corda4, corda4.Length + 1);
                Array.Resize(ref corda5, corda5.Length + 1);
                Array.Resize(ref corda6, corda6.Length + 1);
                if (X == true)
                {
                    corda2[qtdNotas] = "---- ";
                    corda3[qtdNotas] = "---- ";
                    corda4[qtdNotas] = "---- ";
                    corda5[qtdNotas] = "---- ";
                    corda1[qtdNotas] = "---- ";
                    corda6[qtdNotas] = "X--- ";
                }
                if (H == true)
                {
                    if (num < 10)
                    {
                        corda2[qtdNotas] = "---- ";
                        corda3[qtdNotas] = "---- ";
                        corda4[qtdNotas] = "---- ";
                        corda5[qtdNotas] = "---- ";
                        corda1[qtdNotas] = "---- ";
                        corda6[qtdNotas] = "<" + num + ">- ";
                    }
                    else
                    {
                        corda2[qtdNotas] = "---- ";
                        corda3[qtdNotas] = "---- ";
                        corda4[qtdNotas] = "---- ";
                        corda5[qtdNotas] = "---- ";
                        corda1[qtdNotas] = "---- ";
                        corda6[qtdNotas] = "<" + num + "> ";
                    }
                }
                if (X == false && H == false)
                {
                    if (num < 10)
                    {
                        corda2[qtdNotas] = "---- ";
                        corda3[qtdNotas] = "---- ";
                        corda4[qtdNotas] = "---- ";
                        corda5[qtdNotas] = "---- ";
                        corda1[qtdNotas] = "---- ";
                        corda6[qtdNotas] = num + "--- ";
                    }
                    else
                    {
                        corda2[qtdNotas] = "---- ";
                        corda3[qtdNotas] = "---- ";
                        corda4[qtdNotas] = "---- ";
                        corda5[qtdNotas] = "---- ";
                        corda1[qtdNotas] = "---- ";
                        corda6[qtdNotas] = num + "-- ";
                    }
                }
                qtdNotas++; atualizaTab();
            }
            else
            {
                Array.Resize(ref corda6, corda6.Length + 1);
                if (X == true)
                {
                    corda6[qtdNotas] = "X--- ";
                }
                if (H == true)
                {
                    if (num < 10)
                        corda6[qtdNotas] = "<" + num + ">- ";
                    else
                        corda6[qtdNotas] = "<" + num + "> ";
                }
                if (X == false && H == false)
                {
                    if (num < 10)
                        corda6[qtdNotas] = num + "--- ";
                    else
                        corda6[qtdNotas] = num + "-- ";
                }
            }
        }


        private void btn10_Click(object sender, EventArgs e)
        {
            corda1_click(0);
        }

        private void btn20_Click(object sender, EventArgs e)
        {
            corda2_click(0);
        }

        private void btn30_Click(object sender, EventArgs e)
        {
            corda3_click(0);
        }

        private void btn40_Click(object sender, EventArgs e)
        {
            corda4_click(0);
        }

        private void btn50_Click(object sender, EventArgs e)
        {
            corda5_click(0);
        }

        private void btn60_Click(object sender, EventArgs e)
        {
            corda6_click(0);
        }

        private void btn11_Click(object sender, EventArgs e)
        {
            corda1_click(1);
        }

        private void btn21_Click(object sender, EventArgs e)
        {
            corda2_click(1);
        }

        private void btn31_Click(object sender, EventArgs e)
        {
            corda3_click(1);
        }

        private void btn41_Click(object sender, EventArgs e)
        {
            corda4_click(1);
        }

        private void btn51_Click(object sender, EventArgs e)
        {
            corda5_click(1);
        }

        private void btn61_Click(object sender, EventArgs e)
        {
            corda6_click(1);
        }

        private void btn12_Click(object sender, EventArgs e)
        {
            corda1_click(2);
        }

        private void btn22_Click(object sender, EventArgs e)
        {
            corda2_click(2);
        }

        private void btn32_Click(object sender, EventArgs e)
        {
            corda3_click(2);
        }

        private void btn42_Click(object sender, EventArgs e)
        {
            corda4_click(2);
        }

        private void btn52_Click(object sender, EventArgs e)
        {
            corda5_click(2);
        }

        private void btn62_Click(object sender, EventArgs e)
        {
            corda6_click(2);
        }

        private void btn13_Click(object sender, EventArgs e)
        {
            corda1_click(3);
        }

        private void btn23_Click(object sender, EventArgs e)
        {
            corda2_click(3);
        }

        private void btn33_Click(object sender, EventArgs e)
        {
            corda3_click(3);
        }

        private void btn43_Click(object sender, EventArgs e)
        {
            corda4_click(3);
        }

        private void btn53_Click(object sender, EventArgs e)
        {
            corda5_click(3);
        }

        private void btn63_Click(object sender, EventArgs e)
        {
            corda6_click(3);
        }

        private void btn14_Click(object sender, EventArgs e)
        {
            corda1_click(4);
        }

        private void btn24_Click(object sender, EventArgs e)
        {
            corda2_click(4);
        }

        private void btn34_Click(object sender, EventArgs e)
        {
            corda3_click(4);
        }

        private void btn44_Click(object sender, EventArgs e)
        {
            corda4_click(4);
        }

        private void btn54_Click(object sender, EventArgs e)
        {
            corda5_click(4);
        }

        private void btn64_Click(object sender, EventArgs e)
        {
            corda6_click(4);
        }

        private void btn15_Click(object sender, EventArgs e)
        {
            corda1_click(5);
        }

        private void btn25_Click(object sender, EventArgs e)
        {
            corda2_click(5);
        }

        private void btn35_Click(object sender, EventArgs e)
        {
            corda3_click(5);
        }

        private void btn45_Click(object sender, EventArgs e)
        {
            corda4_click(5);
        }

        private void btn55_Click(object sender, EventArgs e)
        {
            corda5_click(5);
        }

        private void btn65_Click(object sender, EventArgs e)
        {
            corda6_click(5);
        }

        private void btn16_Click(object sender, EventArgs e)
        {
            corda1_click(6);
        }

        private void btn26_Click(object sender, EventArgs e)
        {
            corda2_click(6);
        }

        private void btn36_Click(object sender, EventArgs e)
        {
            corda3_click(6);
        }

        private void btn46_Click(object sender, EventArgs e)
        {
            corda4_click(6);
        }

        private void btn56_Click(object sender, EventArgs e)
        {
            corda5_click(6);
        }

        private void btn66_Click(object sender, EventArgs e)
        {
            corda6_click(6);
        }

        private void btn17_Click(object sender, EventArgs e)
        {
            corda1_click(7);
        }

        private void btn27_Click(object sender, EventArgs e)
        {
            corda2_click(7);
        }

        private void btn37_Click(object sender, EventArgs e)
        {
            corda3_click(7);
        }

        private void btn47_Click(object sender, EventArgs e)
        {
            corda4_click(7);
        }

        private void btn57_Click(object sender, EventArgs e)
        {
            corda5_click(7);
        }

        private void btn67_Click(object sender, EventArgs e)
        {
            corda6_click(7);
        }

        private void btn18_Click(object sender, EventArgs e)
        {
            corda1_click(8);
        }

        private void btn28_Click(object sender, EventArgs e)
        {
            corda2_click(8);
        }

        private void btn38_Click(object sender, EventArgs e)
        {
            corda3_click(8);
        }

        private void btn48_Click(object sender, EventArgs e)
        {
            corda4_click(8);
        }

        private void btn58_Click(object sender, EventArgs e)
        {
            corda5_click(8);
        }

        private void btn68_Click(object sender, EventArgs e)
        {
            corda6_click(8);
        }

        private void btn19_Click(object sender, EventArgs e)
        {
            corda1_click(9);
        }

        private void btn29_Click(object sender, EventArgs e)
        {
            corda2_click(9);
        }

        private void btn39_Click(object sender, EventArgs e)
        {
            corda3_click(9);
        }

        private void btn49_Click(object sender, EventArgs e)
        {
            corda4_click(9);
        }

        private void btn59_Click(object sender, EventArgs e)
        {
            corda5_click(9);
        }

        private void btn69_Click(object sender, EventArgs e)
        {
            corda6_click(9);
        }

        private void btn110_Click(object sender, EventArgs e)
        {
            corda1_click(10);
        }

        private void btn210_Click(object sender, EventArgs e)
        {
            corda2_click(10);
        }

        private void btn310_Click(object sender, EventArgs e)
        {
            corda3_click(10);
        }

        private void btn410_Click(object sender, EventArgs e)
        {
            corda4_click(10);
        }

        private void btn510_Click(object sender, EventArgs e)
        {
            corda5_click(10);
        }

        private void btn610_Click(object sender, EventArgs e)
        {
            corda6_click(10);
        }

        private void btn111_Click(object sender, EventArgs e)
        {
            corda1_click(11);
        }

        private void btn211_Click(object sender, EventArgs e)
        {
            corda2_click(11);
        }

        private void btn311_Click(object sender, EventArgs e)
        {
            corda3_click(11);
        }

        private void btn411_Click(object sender, EventArgs e)
        {
            corda4_click(11);
        }

        private void btn511_Click(object sender, EventArgs e)
        {
            corda5_click(11);
        }

        private void btn611_Click(object sender, EventArgs e)
        {
            corda6_click(11);
        }

        private void btn112_Click(object sender, EventArgs e)
        {
            corda1_click(12);
        }

        private void btn212_Click(object sender, EventArgs e)
        {
            corda2_click(12);
        }

        private void btn312_Click(object sender, EventArgs e)
        {
            corda3_click(12);
        }

        private void btn412_Click(object sender, EventArgs e)
        {
            corda4_click(12);
        }

        private void btn512_Click(object sender, EventArgs e)
        {
            corda5_click(12);
        }

        private void btn612_Click(object sender, EventArgs e)
        {
            corda6_click(12);
        }

        private void btn113_Click(object sender, EventArgs e)
        {
            corda1_click(13);
        }

        private void btn213_Click(object sender, EventArgs e)
        {
            corda2_click(13);
        }

        private void btn313_Click(object sender, EventArgs e)
        {
            corda3_click(13);
        }

        private void btn413_Click(object sender, EventArgs e)
        {
            corda4_click(13);
        }

        private void btn513_Click(object sender, EventArgs e)
        {
            corda5_click(13);
        }

        private void btn613_Click(object sender, EventArgs e)
        {
            corda6_click(13);
        }

        private void btn114_Click(object sender, EventArgs e)
        {
            corda1_click(14);
        }

        private void btn214_Click(object sender, EventArgs e)
        {
            corda2_click(14);
        }

        private void btn314_Click(object sender, EventArgs e)
        {
            corda3_click(14);
        }

        private void btn414_Click(object sender, EventArgs e)
        {
            corda4_click(14);
        }

        private void btn514_Click(object sender, EventArgs e)
        {
            corda5_click(14);
        }

        private void btn614_Click(object sender, EventArgs e)
        {
            corda6_click(14);
        }

        private void btn115_Click(object sender, EventArgs e)
        {
            corda1_click(15);
        }

        private void btn215_Click(object sender, EventArgs e)
        {
            corda2_click(15);
        }

        private void btn315_Click(object sender, EventArgs e)
        {
            corda3_click(15);
        }

        private void btn415_Click(object sender, EventArgs e)
        {
            corda4_click(15);
        }

        private void btn515_Click(object sender, EventArgs e)
        {
            corda5_click(15);
        }

        private void btn615_Click(object sender, EventArgs e)
        {
            corda6_click(15);
        }


        #endregion

        private void btnOKBaixo_Click(object sender, EventArgs e)
        {
            Array.Resize(ref corda1, corda1.Length + 1);
            Array.Resize(ref corda2, corda2.Length + 1);
            Array.Resize(ref corda3, corda3.Length + 1);
            Array.Resize(ref corda4, corda4.Length + 1);
            Array.Resize(ref corda5, corda5.Length + 1);
            Array.Resize(ref corda6, corda6.Length + 1);
            bool charDuplo = false;
            if (txtCorda1Baixo.TextLength > 1 || txtCorda2Baixo.TextLength > 1 || txtCorda3Baixo.TextLength > 1 || txtCorda4Baixo.TextLength > 1 || txtCorda5Baixo.TextLength > 1 || txtCorda6Baixo.TextLength > 1)
                charDuplo = true;

            VerificaBaixo(charDuplo, corda1, 1);
            VerificaBaixo(charDuplo, corda2, 2);
            VerificaBaixo(charDuplo, corda3, 3);
            VerificaBaixo(charDuplo, corda4, 4);
            VerificaBaixo(charDuplo, corda5, 5);
            VerificaBaixo(charDuplo, corda6, 6);


            qtdNotas++;
            atualizaTab();

        }

        private void btnOKCima_Click(object sender, EventArgs e)
        {
            Array.Resize(ref corda1, corda1.Length + 1);
            Array.Resize(ref corda2, corda2.Length + 1);
            Array.Resize(ref corda3, corda3.Length + 1);
            Array.Resize(ref corda4, corda4.Length + 1);
            Array.Resize(ref corda5, corda5.Length + 1);
            Array.Resize(ref corda6, corda6.Length + 1);
            bool charDuplo = false;
            if (txtCorda1Cima.TextLength > 1 || txtCorda2Cima.TextLength > 1 || txtCorda3Cima.TextLength > 1 || txtCorda4Cima.TextLength > 1 || txtCorda5Cima.TextLength > 1 || txtCorda6Cima.TextLength > 1)
                charDuplo = true;

            VerificaCima(charDuplo, corda1, 1);
            VerificaCima(charDuplo, corda2, 2);
            VerificaCima(charDuplo, corda3, 3);
            VerificaCima(charDuplo, corda4, 4);
            VerificaCima(charDuplo, corda5, 5);
            VerificaCima(charDuplo, corda6, 6);

            qtdNotas++;
            atualizaTab();
        }

        public void VerificaCima(bool charDuplo, string[] corda, int i)
        {
            string texto = "";
            foreach (Control c in grbCima.Controls)
            {
                texto = c.Text;
                
                if (charDuplo == true && texto.Length == 1)
                    texto = "-" + texto;
                else if (charDuplo == true && texto.Length == 0)
                    texto = "--";
                else if (charDuplo == false && texto.Length == 0)
                    texto = "-";

                if (c.Name == "txtCorda" + i.ToString() + "Cima")
                {
                    if (corda == corda6)
                    {
                        if (charDuplo == true)
                            corda[qtdNotas] = texto + "V- ";
                        else
                            corda[qtdNotas] = texto + "V-- ";
                    }
                    else
                    {
                        if (charDuplo == true)
                            corda[qtdNotas] = texto + "|- ";
                        else
                            corda[qtdNotas] = texto + "|-- ";
                    }
                }
            }
        }
        public void VerificaBaixo(bool charDuplo, string[] corda, int i)
        {
            string texto = "";
            foreach (Control c in grbBaixo.Controls)
            {
                texto = c.Text;

                if (charDuplo == true && texto.Length == 1)
                    texto = "-" + texto;
                else if (charDuplo == true && texto.Length == 0)
                    texto = "--";
                else if (charDuplo == false && texto.Length == 0)
                    texto = "-";

                if (c.Name == "txtCorda" + i.ToString() + "Baixo")
                {
                    if (corda == corda1)
                    {
                        if (charDuplo == true)
                            corda[qtdNotas] = texto + "A- ";
                        else
                            corda[qtdNotas] = texto + "A-- ";
                    }
                    else
                    {
                        if (charDuplo == true)
                            corda[qtdNotas] = texto + "|- ";
                        else
                            corda[qtdNotas] = texto + "|-- ";
                    }
                }
            }
        }


        public void GerarTab()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF | *.pdf";
            sfd.Title = "Save Tab as PDF";
            sfd.FileName = this.Text;
            sfd.ShowDialog();

            string caminho = sfd.FileName;
            //caminho = caminho.Replace(".tab", ".txt");
            var aa = Application.OpenForms.OfType<FrmTabCreator>().FirstOrDefault();
            aa.btnSave.PerformClick();

            while (saved == false)
            {
                saved = aa.saved;
                Thread.Sleep(100);
            }

            string tablatura, aux = "";

            tablatura = txtTab.Text;

            Document doc = new Document(PageSize.A4);//criando e estipulando o tipo da folha usada
            doc.SetMargins(40, 40, 40, 80);//estibulando o espaçamento das margens que queremos
            doc.AddCreationDate();//adicionando as configuracoes

            //caminho onde sera criado o pdf + nome desejado
            //OBS: o nome sempre deve ser terminado com .pdf

            //criando o arquivo pdf embranco, passando como parametro a variavel doc criada acima e a variavel caminho 
            //tambem criada acima.
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));

            doc.Open();

            //criando uma string vazia
            string dados = "";

            //criando a variavel para paragrafo
            Paragraph paragrafo = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 8));
            //etipulando o alinhamneto
            paragrafo.Alignment = Element.ALIGN_LEFT;
            //adicioando texto
                paragrafo.Add(tablatura + "\r\n");
            //acidionado paragrafo ao documento
            doc.Add(paragrafo);
            //fechando documento para que seja salva as alteraçoes.
            doc.Close();
        }


        #region TrackBar
        private void finalizaScroll()
        {
            if (qtdNotas < corda6.Length)
            {
                int conta = 0;
                if (corda6[qtdNotas] == "" || corda6[qtdNotas] == null)
                    conta++;
                if (corda5[qtdNotas] == "" || corda5[qtdNotas] == null)
                    conta++;
                if (corda4[qtdNotas] == "" || corda4[qtdNotas] == null)
                    conta++;
                if (corda3[qtdNotas] == "" || corda3[qtdNotas] == null)
                    conta++;
                if (corda2[qtdNotas] == "" || corda2[qtdNotas] == null)
                    conta++;
                if (corda1[qtdNotas] == "" || corda1[qtdNotas] == null)
                    conta++;

                if (conta != 6)
                {
                    if (corda6[qtdNotas] == "" || corda6[qtdNotas] == null)
                        corda6[qtdNotas] = "---- ";
                    if (corda5[qtdNotas] == "" || corda5[qtdNotas] == null)
                        corda5[qtdNotas] = "---- ";
                    if (corda4[qtdNotas] == "" || corda4[qtdNotas] == null)
                        corda4[qtdNotas] = "---- ";
                    if (corda3[qtdNotas] == "" || corda3[qtdNotas] == null)
                        corda3[qtdNotas] = "---- ";
                    if (corda2[qtdNotas] == "" || corda2[qtdNotas] == null)
                        corda2[qtdNotas] = "---- ";
                    if (corda1[qtdNotas] == "" || corda1[qtdNotas] == null)
                        corda1[qtdNotas] = "---- ";
                    qtdNotas++;
                    atualizaTab();
                }

                trackBar0.Value = 0;
                trackBar1.Value = 0;
                trackBar2.Value = 0;
                trackBar3.Value = 0;
                trackBar4.Value = 0;
                trackBar5.Value = 0;
                trackBar6.Value = 0;
                trackBar7.Value = 0;
                trackBar8.Value = 0;
                trackBar9.Value = 0;
                trackBar10.Value = 0;
                trackBar11.Value = 0;
                trackBar12.Value = 0;
                trackBar13.Value = 0;
                trackBar14.Value = 0;
                trackBar15.Value = 0;
            }
        }
        private void scroll(int num, int corda)
        {
            Array.Resize(ref corda1, corda1.Length + 1);
            Array.Resize(ref corda2, corda2.Length + 1);
            Array.Resize(ref corda3, corda3.Length + 1);
            Array.Resize(ref corda4, corda4.Length + 1);
            Array.Resize(ref corda5, corda5.Length + 1);
            Array.Resize(ref corda6, corda6.Length + 1);
            if (num < 10)
            {
                if (corda == 1)
                    corda6[qtdNotas] = num + "--- ";
                if (corda == 2)
                    corda5[qtdNotas] = num + "--- ";
                if (corda == 3)
                    corda4[qtdNotas] = num + "--- ";
                if (corda == 4)
                    corda3[qtdNotas] = num + "--- ";
                if (corda == 5)
                    corda2[qtdNotas] = num + "--- ";
                if (corda == 6)
                    corda1[qtdNotas] = num + "--- ";
            }
            else
            {
                if (corda == 1)
                    corda6[qtdNotas] = num + "-- ";
                if (corda == 2)
                    corda5[qtdNotas] = num + "-- ";
                if (corda == 3)
                    corda4[qtdNotas] = num + "-- ";
                if (corda == 4)
                    corda3[qtdNotas] = num + "-- ";
                if (corda == 5)
                    corda2[qtdNotas] = num + "-- ";
                if (corda == 6)
                    corda1[qtdNotas] = num + "-- ";
            }
        }
        private void trackBar0_MouseUp(object sender, MouseEventArgs e)
        {
            finalizaScroll();
        }

        private void trackBar0_Scroll(object sender, EventArgs e)
        {            
            corda = trackBar0.Value;
            if (corda != 0)
            {
                scroll(0, corda);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            corda = trackBar1.Value;
            if (corda != 0)
            {
                scroll(1, corda);
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            corda = trackBar2.Value;
            if (corda != 0)
            {
                scroll(2, corda);
            }
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            corda = trackBar3.Value;
            if (corda != 0)
            {
                scroll(3, corda);
            }
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            corda = trackBar4.Value;
            if (corda != 0)
            {
                scroll(4, corda);
            }
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            corda = trackBar5.Value;
            if (corda != 0)
            {
                scroll(5, corda);
            }
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            corda = trackBar6.Value;
            if (corda != 0)
            {
                scroll(6, corda);
            }
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            corda = trackBar7.Value;
            if (corda != 0)
            {
                scroll(7, corda);
            }
        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            corda = trackBar8.Value;
            if (corda != 0)
            {
                scroll(8, corda);
            }
        }

        private void trackBar9_Scroll(object sender, EventArgs e)
        {
            corda = trackBar9.Value;
            if (corda != 0)
            {
                scroll(9, corda);
            }
        }

        private void trackBar10_Scroll(object sender, EventArgs e)
        {
            corda = trackBar10.Value;
            if (corda != 0)
            {
                scroll(10, corda);
            }
        }

        private void trackBar11_Scroll(object sender, EventArgs e)
        {
            corda = trackBar11.Value;
            if (corda != 0)
            {
                scroll(11, corda);
            }
        }

        private void trackBar12_Scroll(object sender, EventArgs e)
        {
            corda = trackBar12.Value;
            if (corda != 0)
            {
                scroll(12, corda);
            }
        }

        private void trackBar13_Scroll(object sender, EventArgs e)
        {
            corda = trackBar13.Value;
            if (corda != 0)
            {
                scroll(13, corda);
            }
        }

        private void trackBar14_Scroll(object sender, EventArgs e)
        {
            corda = trackBar14.Value;
            if (corda != 0)
            {
                scroll(14, corda);
            }
        }

        private void trackBar15_Scroll(object sender, EventArgs e)
        {
            corda = trackBar15.Value;
            if (corda != 0)
            {
                scroll(15, corda);
            }
        }
        #endregion

        private void atualizaTab()
        {    
            
            #region EscreveNota
            txtTab.Text = pulaLinha;
                txtTab.Text += "e|";
            for (int i = 0; i < corda1.Length; i++)
                txtTab.Text += corda1[i];
            txtTab.Text += "\r\n";
                txtTab.Text += "B|";
            for (int i = 0; i < corda2.Length; i++)
                txtTab.Text += corda2[i];
            txtTab.Text += "\r\n";
                txtTab.Text += "G|";
            for (int i = 0; i < corda3.Length; i++)
                txtTab.Text += corda3[i];               
            txtTab.Text += "\r\n";
                txtTab.Text += "D|";
            for (int i = 0; i < corda4.Length; i++)
                txtTab.Text += corda4[i];
            txtTab.Text += "\r\n";
                txtTab.Text += "A|";
            for (int i = 0; i < corda5.Length; i++)
                txtTab.Text += corda5[i];            
            txtTab.Text += "\r\n";
                txtTab.Text += "E|";
            for (int i = 0; i < corda6.Length; i++)
                txtTab.Text += corda6[i];
                
            #endregion

            #region cordaAux
            int a = aux;
            for (int i = 0; i < corda1.Length; i++)
            {
                Array.Resize(ref cordaAux1, cordaAux1.Length + 1);
                cordaAux1[a] = corda1[i];
                a++;
            }
            int b = aux2;

            for (int i = 0; i < corda2.Length; i++)
            {
                Array.Resize(ref cordaAux2, cordaAux2.Length + 1);

                cordaAux2[b] = corda2[i];
                b++;
            }
            int c = aux3;

            for (int i = 0; i < corda3.Length; i++)
            {
                Array.Resize(ref cordaAux3, cordaAux3.Length + 1);

                cordaAux3[c] = corda3[i];
                c++;
            }
            int d = aux4;

            for (int i = 0; i < corda4.Length; i++)
            {
                Array.Resize(ref cordaAux4, cordaAux4.Length + 1);

                cordaAux4[d] = corda4[i];
                d++;
            }
            int e = aux5;

            for (int i = 0; i < corda5.Length; i++)
            {
                Array.Resize(ref cordaAux5, cordaAux5.Length + 1);

                cordaAux5[e] = corda5[i];
                e++;
            }
            int f = aux6;

            for (int i = 0; i < corda6.Length; i++)
            {
                Array.Resize(ref cordaAux6, cordaAux6.Length + 1);

                cordaAux6[f] = corda6[i];
                f++;
            }
            #endregion

            notasNaLabel++;
            if (notasNaLabel % 24 == 0 && notasNaLabel != 1)
            {
                aux += 24;
                aux2 += 24;
                aux3 += 24;
                aux4 += 24;
                aux5 += 24;
                aux6 += 24;

                pulaLinha = txtTab.Text + "\r\n" + " \r\n" + " \r\n";
                corda1 = new string[1];
                corda2 = new string[1];
                corda3 = new string[1];
                corda4 = new string[1];
                corda5 = new string[1];
                corda6 = new string[1];
                qtdNotas = 0;
            }

            if (txtTab.Text == null)
                tab = new NotasTab("");
            else
                tab = new NotasTab(txtTab.Text);

            txtTab.SelectionStart = txtTab.TextLength;
            txtTab.ScrollToCaret();
        }

        #region retornaCorda
        public string[] C1()
        {
            return cordaAux1;
        }
        public string[] C2()
        {
            return cordaAux2;
        }
        public string[] C3()
        {
            return cordaAux3;
        }
        public string[] C4()
        {
            return cordaAux4;
        }
        public string[] C5()
        {
            return cordaAux5;
        }
        public string[] C6()
        {
            return cordaAux6;
        }
        #endregion

        private async void btnPlay_Click(object sender, EventArgs e)
        {
            btPause.Visible = true;
            btnPlay.Visible = false;
            toca = true;
            cmbTempo.Enabled = false;

            pcbBarraVermelha.Visible = true;
            int tempoMusica = 0;
            string tempo = cmbTempo.SelectedItem.ToString();

            if (tempo == "4/4")
                tempoMusica = 450;
            if (tempo == "3/3")
                tempoMusica = 350;
            if (tempo == "2/2")
                tempoMusica = 250;
            if (tempo == "2/4")
                tempoMusica = 150;
                
            var Mizinha = cordaAux1;
            var Si = cordaAux2;
            var Sol = cordaAux3;
            var Re = cordaAux4;
            var La = cordaAux5;
            var Mizona = cordaAux6;

            if (fim == true)
            {
                pcbBarraVermelha.Location = new Point(-7, 246);
                fim = false;
                cmbTempo.Enabled = true;
                btnPlay.Enabled = true;
            }

            int X;
            int X0;
            int Y;
            int Y0;
            X = pcbBarraVermelha.Location.X;
            Y = pcbBarraVermelha.Location.Y;
            X0 = X;
            Y0 = Y;

            int Qtd = cordaAux1.Length / 24;
            if (cordaAux1.Length % 24 != 0)
                Qtd++;

            #region MoveBarraVermelha

            for (int k = 0; k < Qtd; k++)
            {
                X = X0;
                for (int i = 0; i < 24; i++)
                {
                    if (toca == true)
                    {
                        X += 35;
                        pcbBarraVermelha.Location = new Point(X, Y);
                        Thread thread = new Thread(() => TocaNota(Mizinha, Si, Sol, Re, La, Mizona, i));
                        await Task.Delay(tempoMusica);
                    }
                }
                if (toca == true)
                {
                    Y = pcbBarraVermelha.Location.Y;
                    Y += 111;
                    pcbBarraVermelha.Location = new Point(X0, Y);
                }
            }
            #endregion

            if (toca == true)
            {
                fim = true;
                pcbBarraVermelha.Visible = false;
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            toca = false;
            int Xa, Ya;
            Xa = pcbBarraVermelha.Location.X;
            Ya = pcbBarraVermelha.Location.Y;
            pcbBarraVermelha.Location = new Point(Xa, Ya);
            cmbTempo.Enabled = true;
            btnPlay.Visible = true;
            btPause.Visible = false;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            toca = false;
            pcbBarraVermelha.Visible = false;
            fim = true;
            cmbTempo.Enabled = true;
            btnPlay.Enabled = true;
            btnPlay.Enabled = true;
            btnPlay.Visible = true;
            btPause.Visible = false;
        }

        public void TocaNota(string[] Mizinha, string[] Si, string[] Sol, string[] Re, string[] La, string[] Mizona, int k)
        {
            #region PlaySound
            try
            {
                if (Mizinha[k] == "0--")
                {
                    var p1 = new System.Windows.Media.MediaPlayer();
                    p1.Open(new System.Uri(@"c:\Notas\Sons\Mizinha0.wav"));
                    p1.Play();

                }
                if (Si[k] == "0--")
                {

                    var p1 = new System.Windows.Media.MediaPlayer();
                    p1.Open(new System.Uri(@"c:\Notas\Sons\Si0.wav"));
                    p1.Play();

                }
                if (Sol[k] == "0--")
                {
                    var p1 = new System.Windows.Media.MediaPlayer();
                    p1.Open(new System.Uri(@"c:\Notas\Sons\Sol0.wav"));
                    p1.Play();
                }
                if (Re[k] == "0--")
                {
                    var p1 = new System.Windows.Media.MediaPlayer();
                    p1.Open(new System.Uri(@"c:\Notas\Sons\Re0.wav"));
                    p1.Play();

                }
                if (La[k] == "0--")
                {
                    var p1 = new System.Windows.Media.MediaPlayer();
                    p1.Open(new System.Uri(@"c:\Notas\Sons\La0.wav"));
                    p1.Play();

                }
                if (Mizona[k] == "0--")
                {
                    var p1 = new System.Windows.Media.MediaPlayer();
                    p1.Open(new System.Uri(@"c:\Notas\Sons\Mizona0.wav"));
                    p1.Play();

                }
                if (Mizinha[k] == "1--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Mizinha1.wav");
                    //simpleSound.Play();
                }
                if (Si[k] == "1--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Si1.wav");
                    //simpleSound.Play();
                }
                if (Sol[k] == "1--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Sol1.wav");
                    //simpleSound.Play();
                }
                if (Re[k] == "1--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Re1.wav");
                    //simpleSound.Play();
                }
                if (La[k] == "1--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\La1.wav");
                    //simpleSound.Play();
                }
                if (Mizona[k] == "1--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Mizona1.wav");
                    //simpleSound.Play();
                }


                if (Mizinha[k] == "2--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Mizinha2.wav");
                    //simpleSound.Play();
                }
                if (Si[k] == "2--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Si2.wav");
                    //simpleSound.Play();
                }
                if (Sol[k] == "2--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Sol2.wav");
                    //simpleSound.Play();
                }
                if (Re[k] == "2--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Re2.wav");
                    //simpleSound.Play();
                }
                if (La[k] == "2--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\La2.wav");
                    //simpleSound.Play();
                }
                if (Mizona[k] == "2--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Mizona2.wav");
                    //simpleSound.Play();
                }


                if (Mizinha[k] == "3--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Mizinha3.wav");
                    //simpleSound.Play();
                }
                if (Si[k] == "3--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Si3.wav");
                    //simpleSound.Play();
                }
                if (Sol[k] == "3--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Sol3.wav");
                    //simpleSound.Play();
                }
                if (Re[k] == "3--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Re3.wav");
                    //simpleSound.Play();
                }
                if (La[k] == "3--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\La3.wav");
                    //simpleSound.Play();
                }
                if (Mizona[k] == "3--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Mizona3.wav");
                    //simpleSound.Play();
                }



                if (Mizinha[k] == "4--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Mizinha4.wav");
                    //simpleSound.Play();
                }
                if (Si[k] == "4--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Si4.wav");
                    //simpleSound.Play();
                }
                if (Sol[k] == "4--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Sol4.wav");
                    //simpleSound.Play();
                }
                if (Re[k] == "4--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Re4.wav");
                    //simpleSound.Play();
                }
                if (La[k] == "4--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\La4.wav");
                    //simpleSound.Play();
                }
                if (Mizona[k] == "4--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Mizona4.wav");
                    //simpleSound.Play();
                }



                if (Mizinha[k] == "5--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Mizinha5.wav");
                    //simpleSound.Play();
                }
                if (Si[k] == "5--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Si5.wav");
                    //simpleSound.Play();
                }
                if (Sol[k] == "5--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Sol5.wav");
                    //simpleSound.Play();
                }
                if (Re[k] == "5--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Re5.wav");
                    //simpleSound.Play();
                }
                if (La[k] == "5--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\La5.wav");
                    //simpleSound.Play();
                }
                if (Mizona[k] == "5--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Mizona5.wav");
                    //simpleSound.Play();
                }



                if (Mizinha[k] == "6--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Mizinha6.wav");
                    //simpleSound.Play();
                }
                if (Si[k] == "6--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Si6.wav");
                    //simpleSound.Play();
                }
                if (Sol[k] == "6--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Sol6.wav");
                    //simpleSound.Play();
                }
                if (Re[k] == "6--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Re6.wav");
                    //simpleSound.Play();
                }
                if (La[k] == "6--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\La6.wav");
                    //simpleSound.Play();
                }
                if (Mizona[k] == "6--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Mizona6.wav");
                    //simpleSound.Play();
                }



                if (Mizinha[k] == "7--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Mizinha7.wav");
                    //simpleSound.Play();
                }
                if (Si[k] == "7--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Si7.wav");
                    //simpleSound.Play();
                }
                if (Sol[k] == "7--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Sol7.wav");
                    //simpleSound.Play();
                }
                if (Re[k] == "7--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Re7.wav");
                    //simpleSound.Play();
                }
                if (La[k] == "7--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\La7.wav");
                    //simpleSound.Play();
                }
                if (Mizona[k] == "7--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Mizona7.wav");
                    //simpleSound.Play();
                }



                if (Mizinha[k] == "8--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Mizinha8.wav");
                    //simpleSound.Play();
                }
                if (Si[k] == "8--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Si8.wav");
                    //simpleSound.Play();
                }
                if (Sol[k] == "8--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Sol8.wav");
                    //simpleSound.Play();
                }
                if (Re[k] == "8--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Re8.wav");
                    //simpleSound.Play();
                }
                if (La[k] == "8--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\La8.wav");
                    //simpleSound.Play();
                }
                if (Mizona[k] == "8--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Mizona8.wav");
                    //simpleSound.Play();
                }



                if (Mizinha[k] == "9--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Mizinha9.wav");
                    //simpleSound.Play();
                }
                if (Si[k] == "9--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Si9.wav");
                    //simpleSound.Play();
                }
                if (Sol[k] == "9--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Sol9.wav");
                    //simpleSound.Play();
                }
                if (Re[k] == "9--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Re9.wav");
                    //simpleSound.Play();
                }
                if (La[k] == "9--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\La9.wav");
                    //simpleSound.Play();
                }
                if (Mizona[k] == "9--")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Mizona9.wav");
                    //simpleSound.Play();
                }



                if (Mizinha[k] == "10-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Mizinha10.wav");
                    //simpleSound.Play();
                }
                if (Si[k] == "10-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Si10.wav");
                    //simpleSound.Play();
                }
                if (Sol[k] == "10-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Sol10.wav");
                    //simpleSound.Play();
                }
                if (Re[k] == "10-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Re10.wav");
                    //simpleSound.Play();
                }
                if (La[k] == "10-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\La10.wav");
                    //simpleSound.Play();
                }
                if (Mizona[k] == "10-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Mizona10.wav");
                    //simpleSound.Play();
                }



                if (Mizinha[k] == "11-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Mizinha11.wav");
                    //simpleSound.Play();
                }
                if (Si[k] == "11-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Si11.wav");
                    //simpleSound.Play();
                }
                if (Sol[k] == "11-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Sol11.wav");
                    //simpleSound.Play();
                }
                if (Re[k] == "11-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Re11.wav");
                    //simpleSound.Play();
                }
                if (La[k] == "11-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\La11.wav");
                    //simpleSound.Play();
                }
                if (Mizona[k] == "11-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Mizona11.wav");
                    //simpleSound.Play();
                }



                if (Mizinha[k] == "12-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Mizinha12.wav");
                    //simpleSound.Play();
                }
                if (Si[k] == "12-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Si12.wav");
                    //simpleSound.Play();
                }
                if (Sol[k] == "12-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Sol12.wav");
                    //simpleSound.Play();
                }
                if (Re[k] == "12-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Re12.wav");
                    //simpleSound.Play();
                }
                if (La[k] == "12-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\La12.wav");
                    //simpleSound.Play();
                }
                if (Mizona[k] == "12-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Mizona12.wav");
                    //simpleSound.Play();
                }



                if (Mizinha[k] == "13-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Mizinha13.wav");
                    //simpleSound.Play();
                }
                if (Si[k] == "13-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Si13.wav");
                    //simpleSound.Play();
                }
                if (Sol[k] == "13-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Sol13.wav");
                    //simpleSound.Play();
                }
                if (Re[k] == "13-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Re13.wav");
                    //simpleSound.Play();
                }
                if (La[k] == "13-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\La13.wav");
                    //simpleSound.Play();
                }
                if (Mizona[k] == "13-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Mizona13.wav");
                    //simpleSound.Play();
                }


                if (Mizinha[k] == "14-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Mizinha14.wav");
                    //simpleSound.Play();
                }
                if (Si[k] == "14-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Si14.wav");
                    //simpleSound.Play();
                }
                if (Sol[k] == "14-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Sol14.wav");
                    //simpleSound.Play();
                }
                if (Re[k] == "14-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Re14.wav");
                    //simpleSound.Play();
                }
                if (La[k] == "14-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\La14.wav");
                    //simpleSound.Play();
                }
                if (Mizona[k] == "14-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Mizona14.wav");
                    //simpleSound.Play();
                }



                if (Mizinha[k] == "15-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Mizinha15.wav");
                    //simpleSound.Play();
                }
                if (Si[k] == "15-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Si15.wav");
                    //simpleSound.Play();
                }
                if (Sol[k] == "15-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Sol15.wav");
                    //simpleSound.Play();
                }
                if (Re[k] == "15-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Re15.wav");
                    //simpleSound.Play();
                }
                if (La[k] == "15-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\La15.wav");
                    //simpleSound.Play();
                }
                if (Mizona[k] == "15-")
                {
                    //simpleSound = new SoundPlayer(@"c:\Notas\Sons\Mizona15.wav");
                    //simpleSound.Play();
                }
            }
            catch { }
            #endregion
        }

        public void setIsMultipleFalse()
        {
            int conta = 0;
            isMultiple = false;

            int[] TamanhoC = new int[6];
            TamanhoC[0] = corda1.Length;
            TamanhoC[1] = corda2.Length;
            TamanhoC[2] = corda3.Length;
            TamanhoC[3] = corda4.Length;
            TamanhoC[4] = corda5.Length;
            TamanhoC[5] = corda6.Length;
            int maior = 0;

            for (int i = 0; i < 6; i++ )
            {
                if (TamanhoC[i] > maior)
                    maior = TamanhoC[i];
            }

            if (corda1.Length < maior)
                Array.Resize(ref corda1, maior);
            if (corda2.Length < maior)
                Array.Resize(ref corda2, maior);
            if (corda3.Length < maior)
                Array.Resize(ref corda3, maior);
            if (corda4.Length < maior)
                Array.Resize(ref corda4, maior);
            if (corda5.Length < maior)
                Array.Resize(ref corda5, maior);
            if (corda6.Length < maior)
                Array.Resize(ref corda6, maior);

                #region VerificaBotaoPress
                if (corda1[qtdNotas] == "" || corda1[qtdNotas] == null)
                {
                    conta++;
                }
            if (corda2[qtdNotas] == "" || corda2[qtdNotas] == null)
            {
                conta++;
            }
            if (corda3[qtdNotas] == "" || corda3[qtdNotas] == null)
            {
                conta++;
            }
            if (corda4[qtdNotas] == "" || corda4[qtdNotas] == null)
            {
                conta++;
            }
            if (corda5[qtdNotas] == "" || corda5[qtdNotas] == null)
            {
                conta++;
            }
            if (corda6[qtdNotas] == "" || corda6[qtdNotas] == null)
            {
                conta++;
            }
            #endregion

            if (conta != 6)
            {
                #region VerificaValoresNulos
                if (corda1[qtdNotas] == "" || corda1[qtdNotas] == null)
                {
                    corda1[qtdNotas] = "---- ";
                }
                if (corda2[qtdNotas] == "" || corda2[qtdNotas] == null)
                {
                    corda2[qtdNotas] = "---- ";
                }
                if (corda3[qtdNotas] == "" || corda3[qtdNotas] == null)
                {
                    corda3[qtdNotas] = "---- ";
                }
                if (corda4[qtdNotas] == "" || corda4[qtdNotas] == null)
                {
                    corda4[qtdNotas] = "---- ";
                }
                if (corda5[qtdNotas] == "" || corda5[qtdNotas] == null)
                {
                    corda5[qtdNotas] = "---- ";
                }
                if (corda6[qtdNotas] == "" || corda6[qtdNotas] == null)
                {
                    corda6[qtdNotas] = "---- ";
                }
                #endregion

                qtdNotas++;
                atualizaTab();
            }
        }

        public void setIsMultipleTrue()
        {
            isMultiple = true;
        }

        public void setXTrue()
        {
            X = true;
        }

        public void setXFalse()
        {
            X = false;
        }

        public void setHTrue()
        {
            H = true;
        }

        public void setHFalse()
        {
            H = false;
        }
    }
}
