using System;
using System.Windows.Forms;

namespace Parcial_03_Poo
{
    public partial class Admin : UserControl
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") ||
                textBox2.Text.Equals("") ||
                textBox3.Text.Equals("") ||
                textBox4.Text.Equals("") ||
                textBox5.Text.Equals("") ||
                textBox6.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar campos vacíos");
            }
            else
            {
                try
                {
                    ConnectionBD.ExecuteNonQuery($"INSERT INTO ESTUDIANTE VALUES(" +
                                                $"'{textBox3.Text}'," +
                                                $"'{textBox1.Text}'," +
                                                $"'{textBox2.Text}'," +
                                                $"'{textBox4.Text}'," +
                                                $"'{textBox5.Text}'," +
                                                $"'{textBox6.Text})");

                    MessageBox.Show("Se ha registrado el usuario");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var dt = ConnectionBD.ExecuteQuery($"SELECT * FROM REGISTRO");

                dataGridView1.DataSource = dt;
                MessageBox.Show("Datos obtenidos correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var dt = ConnectionBD.ExecuteQuery($"SELECT d.nombre, count(u.idDepartamento) as frecuencia FROM " +
                                                   $"REGISTRO r, DEPARTAMENTO d, USUARIO u WHERE r.idUsuario = u.idUsuario " +
                                                   $"AND d.idDepartamento = u.idDepartamento GROUP BY d.idDepartamento " +
                                                   $"ORDER BY frecuencia DESC LIMIT 1;");

                dataGridView2.DataSource = dt;
                MessageBox.Show("Datos obtenidos correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema");
            }
        }
    }
}