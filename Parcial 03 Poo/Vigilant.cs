using System;
using System.Windows.Forms;

namespace Parcial_03_Poo
{
    public partial class Vigilant : UserControl
    {
        public delegate void DelegatePrint();
        
        public Vigilant()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") ||
                textBox2.Text.Equals("") ||
                textBox3.Text.Equals(""))
            {
                DelegatePrint d2 = new DelegatePrint(display);
                d2();
            }
            else
            {
                try
                {
                    ConnectionBD.ExecuteNonQuery($"INSERT INTO REGISTRO(entrada, fechahora, temperatura) VALUES('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}')");

                    MessageBox.Show("Se ha ingresado el registro");
                }
                catch (Exception ex)
                {
                    DelegatePrint d3 = new DelegatePrint(display);
                    d3();
                }
            }
        }
        
        public static void display()
        {
            MessageBox.Show("No se pueden dejar campos vacíos");
        }

        public static void error()
        {
            MessageBox.Show("Ha ocurrido un error");
        }
    }
}