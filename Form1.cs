using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Parcial_Mysql
{
    public partial class Form1 : Form
    {

        public string cadena_conexion = "Database= misempleados;Data Source=localhost;User Id=admin ;Password=admin";
        public string usuario_modificar;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void bsalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //Desabilitar campos, se activan al crear nuevo registro 
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
           
            


            try
            {
                string consulta = "select * from empleados";
                MySqlConnection conexion = new MySqlConnection(cadena_conexion);
                MySqlDataAdapter comando = new MySqlDataAdapter(consulta, conexion);
                System.Data.DataSet ds = new System.Data.DataSet();
                comando.Fill(ds, "misempleados");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "misempleados";
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error de conexion", "Error!", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void bnuevo_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            comboBox1.Text = "Seleccione su sexo";
            comboBox2.Text = "Seleccione su estado";
            comboBox3.Text = "";
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;
            bnuevo.Visible = false;
            bguardar.Visible = true;
            textBox1.Focus();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Enabled = true;
            comboBox3.Enabled = true;
            dateTimePicker1.Enabled = true;
        }

        private void bguardar_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection myConnection = new MySqlConnection(cadena_conexion);
                string myInsertQuery = "INSERT INTO empleados(nombres,apellidos,fechanacimiento,lugarnacimiento,dui,nit,sexo,estado,lugarresidencia,celular,telefonocasa,correo,afiliadoafp) Values(?nombres,?apellidos,?fechanacimiento,?lugarnacimiento,?dui,?nit,?sexo,?estado,?lugarresidencia,?celular,?telefonocasa,?correo,?afiliadoafp)";
                MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
                myCommand.Parameters.Add("?nombres", MySqlDbType.VarChar, 70).Value = textBox1.Text;
                myCommand.Parameters.Add("?apellidos", MySqlDbType.VarChar, 70).Value = textBox2.Text;
                myCommand.Parameters.Add("?fechanacimiento", MySqlDbType.VarChar, 25).Value = dateTimePicker1.Text;
                myCommand.Parameters.Add("?lugarnacimiento", MySqlDbType.VarChar, 50).Value = textBox3.Text;
                myCommand.Parameters.Add("?dui", MySqlDbType.Int32, 11).Value = textBox4.Text;
                myCommand.Parameters.Add("?nit", MySqlDbType.Int32, 20).Value = textBox5.Text;
                myCommand.Parameters.Add("?sexo", MySqlDbType.VarChar, 15).Value = comboBox1.Text;
                myCommand.Parameters.Add("?estado", MySqlDbType.VarChar, 15).Value = comboBox2.Text;
                myCommand.Parameters.Add("?lugarresidencia", MySqlDbType.VarChar, 50).Value = textBox6.Text;
                myCommand.Parameters.Add("?celular", MySqlDbType.Int32, 11).Value = textBox7.Text;
                myCommand.Parameters.Add("?telefonocasa", MySqlDbType.Int32, 11).Value = textBox8.Text;
                myCommand.Parameters.Add("?correo", MySqlDbType.VarChar, 40).Value = textBox9.Text;
                myCommand.Parameters.Add("?afiliadoafp", MySqlDbType.VarChar, 10).Value = comboBox3.Text;

                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();
               
                MessageBox.Show("Usuario agregado con éxito", "Ok", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                


                string consulta = "SELECT * FROM empleados";

                MySqlConnection conexion = new MySqlConnection(cadena_conexion);
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, conexion);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds, "misempleados");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "misempleados";
            }
            catch (MySqlException)
            {
                MessageBox.Show("Ya existe el usuario", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            bnuevo.Visible = true;
            bguardar.Visible = false;

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
            textBox10.Enabled = false;
            

            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;

            dateTimePicker1.Enabled = false;

            bnuevo.Focus();

        }

    }
}
