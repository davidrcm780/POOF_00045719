using System;
using System.Windows.Forms;

namespace Parcial_03_Poo
{
    public partial class Login : UserControl
    {
        public delegate void DelegateShow();
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = this.textBox1.Text;
            string password = this.textBox2.Text;
            
            if (username == "" || password == "")
            {
                
                DelegateShow d1 = new DelegateShow(display);
                d1();
            }
            else
            {
                var dt = ConnectionBD.ExecuteQuery($"SELECT idUsuario, contraseña FROM USUARIO WHERE idUsuario = '{textBox1.Text}' AND contraseña = '{textBox2.Text}'");
                
                int t = Convert.ToInt32(dt);
                if (t == 0)
                {
                    MessageBox.Show("Verfique el Usuario y Contraseña");
                }
                else
                {
                    this.Hide();
                }
            }
        }

        public static void display()
        {
            MessageBox.Show("No se pueden dejar campos vacíos");
        }
    }
}