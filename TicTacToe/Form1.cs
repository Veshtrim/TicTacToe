using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void UKlikuaNjeButon(object sender, EventArgs e)
        {
            //se pari e gjejme butonin qe u klikua
            var b = sender as Button;

            //nese ka qene i klikuar me heret, mos bej asgje
            if (b.Text != "")
            {
                return;
            }

            //vendose 0 ose X, varesisht kush e ka pasur radhen
            b.Text = lblRadha.Text;

            //duhet te shohim mos ka fitues
            string pergjigja = ShikoAKaFitues();

            if (pergjigja != "")
            {
                labelFituesi.Text = pergjigja;
                panelLoja.Enabled = false;
                return;
            }


            if (lblRadha.Text == "0")
                lblRadha.Text = "X";
            else
                lblRadha.Text = "0";
            
            //nese luajme konder kompjuterit
            if (checkKunderKompj.Checked)
            {
                if (lblRadha.Text == "X")
                    LuajVete();
                        //new Thread(LuajVete).Start();
            }

        }

        Random rasti = new Random();

        private void LuajVete()
        {
            // kompj klikon butonin 1
            //  Button b = button1;
            ////////////fillimi:
            ////////////int numri = rasti.Next(1, 10); //1-9
            ////////////string emri = "button" + numri;
            ////////////var ctl = panelLoja.Controls[emri];
            ////////////if (ctl.Text != "")
            ////////////    goto fillimi;
            
            while (true)
            {
                int numri = rasti.Next(1, 10); //1-9
                string emri = "button" + numri;
                var ctl = panelLoja.Controls[emri];
                if (ctl.Text == "")
                {
                    //this.Refresh();
                    Thread.Sleep(100);

                    UKlikuaNjeButon(ctl, null);
                    return;
                }
            }

        }

        bool AJaneTeNjejte(Button a, Button b, Button c)
        {
            if (a.Text == b.Text && b.Text == c.Text && a.Text != "")
                return true;

            return false;
        }


        private string ShikoAKaFitues()
        {
            //rreshti i pare
            if (AJaneTeNjejte(button1, button2, button3))
                return $"Winner is:{button1.Text}";

            //rreshti i dyte
            if (AJaneTeNjejte(button4, button5, button6))
                return $"Winner is:{button4.Text}";

            //rreshti i trete
            if (AJaneTeNjejte(button7, button8, button9))
                return $"Winner is:{button7.Text}";

            //shtylla e pare
            if (AJaneTeNjejte(button1, button4, button7))
                return $"Winner is:{button1.Text}";

            //shtylla e dyte
            if (AJaneTeNjejte(button2, button5, button8))
                return $"Winner is:{button2.Text}";

            //shtylla e trete
            if (AJaneTeNjejte(button3, button6, button9))
                return $"Winner is:{button3.Text}";

            //diagonalja
            if (AJaneTeNjejte(button1, button5, button9))
                return $"Winner is:{button1.Text}";

            //diagonalja
            if (AJaneTeNjejte(button3, button5, button7))
                return $"Winner is:{button3.Text}";



            return "";
        }

        private void btnFilloLojen_Click(object sender, EventArgs e)
        {
            //

            foreach (Control b in panelLoja.Controls)
            {
                if (b.GetType() == typeof(Button))
                {
                    int ngjyra = rasti.Next(0, colors.Length);


                    Button b1 = (b as Button);
                    b1.Text = "";
                    b1.BackColor = colors[ngjyra];
                } 
            }
            panelLoja.Enabled = true;
            lblRadha.Text = "0";

        }

        int numriIRastit;
        int numriITentimeve;
        private void btnCaktoNumrin_Click(object sender, EventArgs e)
        {
            //
            numriITentimeve = 0;
            listBox1.Items.Clear();
            numriIRastit = rasti.Next(0, 50);
            listBox1.Items.Add($"u caktua{numriIRastit}");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int tentimi = int.Parse(txtVlera.Text);
            listBox1.Items.Add($"u tentua{tentimi}");
            numriITentimeve++;

            if (tentimi == numriIRastit)
                listBox1.Items.Add($"ia qellove me {numriITentimeve} tentime");
            else if (tentimi < numriIRastit)
                listBox1.Items.Add($"jo, me i vogel");
            else
                listBox1.Items.Add($"jo, me i madh");


        }
        Color[] colors = new Color[] { Color.Blue, Color.Red, Color.Yellow, Color.Green, Color.Pink };
        private void button11_Click(object sender, EventArgs e)
        {
            rasti = new Random(0);
            listBox1.Items.Clear();
            for (int i = 0; i < 10; i++)
            {
                listBox1.Items.Add(rasti.Next(0, 1000));
            }
        }
    }
}
