using System;
using System.Windows.Forms;

namespace Parcial_03_Poo
{
    public partial class Employee : UserControl
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar campos vacíos");
            }
            else
            {
                try
                {
                    var dt = ConnectionBD.ExecuteQuery($"SELECT idUsuario, fechahora, temperatura FROM REGISTRO WHERE idUsuario = '{textBox1.Text}'");

                    dataGridView1.DataSource = dt;
                    MessageBox.Show("Datos obtenidos correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un problema");
                }
            }
        }
    }
}
