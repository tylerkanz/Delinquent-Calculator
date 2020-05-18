using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program_2
{
    public partial class Form1 : Form
    {
        string meterastr, meterbstr, metercstr, metertotalstr, metercountstr, kwhchargestr, totalduestr, meterchargestr, rehabbalstr, discountchargestr;
        int meterax, meteraz, meterbx, meterbz, metercx, metercz, metertotal, metera, meterb, meterc, missedapt, afterhours, priorbal, metercounta, metercharge;
        double kwhcharge, totaldue, rehabbal, kwhchargeb;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Parsing
            meterax = int.Parse(meteras.Text);
            meteraz = int.Parse(meterae.Text);
            meterbx = int.Parse(meterbs.Text);
            meterbz = int.Parse(meterbe.Text);
            metercx = int.Parse(metercs.Text);
            metercz = int.Parse(meterce.Text);
            metercounta = int.Parse(metercount.Text);
            priorbal = int.Parse(priorbalance.Text);

            //Check Boxes
            if (AfterHoursChkBx.Checked == true)
            {
                afterhours = 50;
                afterhourslbl.Text = "50.00";
            }
            if (AfterHoursChkBx.Checked == false)
            {
                afterhours = 0;
                afterhourslbl.Text = "0.00";
            }

            //Calc
            //Meter A
            if (meterax > meteraz)
            {
                metera = (9999 - meterax) + meteraz;
            }
            else {
                metera = meteraz - meterax;
            }

            //Meter B
            if (meterbx > meterbz)
            {
                meterb = (9999 - meterbx) + meterbz;
            }
            else
            {
                meterb = meterbz - meterbx;
            }

            //Meter C
            if (metercx > metercz)
            {
                meterc = (9999 - metercx) + metercz;
            }
            else
            {
                meterc = metercz - metercx;
            }
  
            //metera = meteraz - meterax;
            //meterb = meterbz - meterbx;
            //meterc = metercz - metercx;

            metertotal = metera + meterb + meterc;

            kwhcharge = metertotal * .082;

            if (metertotal > 7000) {
                kwhchargeb = (metertotal - 7000) * .05; 
            }

            else if (metertotal > 9000)
            {
                kwhchargeb = ((metertotal - 9000) * .15) + 100; 
            }



            metercharge = metercounta * 25;

            totaldue = priorbal + kwhcharge + metercharge + afterhours + missedapt - kwhchargeb;

            if (RehabYes.Checked) {
                rehabbal = totaldue * .35;

                if (rehabbal > 55) {
                    rehabbal = 55;
                }
            }


            //ToStrings
            meterastr = metera.ToString();
            meterbstr = meterb.ToString();
            metercstr = meterc.ToString();
            metertotalstr = metertotal.ToString();
            metercountstr = metercount.ToString();
            kwhchargestr = kwhcharge.ToString("C");
            meterchargestr = metercharge.ToString("C");
            totalduestr = totaldue.ToString("C");
            rehabbalstr = rehabbal.ToString("C");
            discountchargestr = kwhchargeb.ToString("C");


            //Display Labels
            usedalbl.Text = meterastr;
            usedblbl.Text = meterbstr;
            usedclbl.Text = metercstr;
            totalkwhlbl.Text = metertotalstr;
            kwhchargelbl.Text = kwhchargestr;
            meterchargelbl.Text = meterchargestr;
            totallbl.Text = totalduestr;
            RehabBalLbl.Text = rehabbalstr;
            kwhdiscountlbl.Text = discountchargestr;
            


        }

        public void button1_Click(object sender, EventArgs e)
        {
            afterhours = 50;
            afterhourslbl.Text = "50.00";
        }

        public void button2_Click(object sender, EventArgs e)
        {
            missedapt = 25;
            missedapptlbl.Text = "25.00";
        }

        public void button3_Click(object sender, EventArgs e)
        {
            meteras.Text = "";
            meterae.Text = "";
            meterbs.Text = "";
            meterbe.Text = "";
            metercs.Text = "";
            meterce.Text = "";
            metercount.Text = "";
            priorbalance.Text = "";
            usedalbl.Text = "";
            usedblbl.Text = "";
            usedclbl.Text = "";
            totalkwhlbl.Text = "";
            kwhchargelbl.Text = "";
            meterchargelbl.Text = "";
            totallbl.Text = "";

            afterhours = 0;
            afterhourslbl.Text = "0";
            
            missedapt = 0;
            missedapptlbl.Text = "0";
        }

        private void meteras_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please enter a valid value");
            }
        }

        private void meterbs_TextChanged(object sender, EventArgs e)
        {
        }

        private void meterbs_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please enter a valid value");
            }
        }

        private void metercs_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please enter a valid value");
            }
        }

        private void meterae_TextChanged(object sender, EventArgs e)
        {

        }

        private void meterae_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please enter a valid value");
            }
        }

        private void meterbe_TextChanged(object sender, EventArgs e)
        {

        }

        private void meterbe_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please enter a valid value");
            }
        }

        private void meterce_TextChanged(object sender, EventArgs e)
        {

        }

        private void meterce_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please enter a valid value");
            }
        }

        private void metercount_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                MessageBox.Show("Please enter a valid value");
            }
        }

        private void AfterHoursChkBx_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RehabYes_CheckedChanged(object sender, EventArgs e)
        {
            RehabNo.Checked = false;
        }

        private void RehabNo_CheckedChanged(object sender, EventArgs e)
        {
            RehabYes.Checked = false;
        }
    }
}
