using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace registroActividades.formas
{
    public partial class frmActividades : Form
    {

        DataSet DT;
        DataSet dtsDtaos;
        DataView dtwDatos;

        public frmActividades()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;
            int id;
            try { id = Convert.ToInt32(txtId.Text); }
            catch (Exception ex) { id = -1; }

            Conexion Con = new Conexion();
            Con.Abrir();
            using (SqlConnection connection = new SqlConnection(Con.ObtenerConexionString()))
            {

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GuardarActividad";
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.Add(new SqlParameter("id", id));
                    command.Parameters.Add(new SqlParameter("nombre", txtnombre.Text));




                    try
                    {
                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();

                        txtId.Text = "";
                        txtnombre.Text = "";
                        dataActividades.DataSource = null;
                        llenarGrid();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        connection.Close();

                    }

                }
            }
        }

        private void llenarGrid()
        {
            Conexion CN = new Conexion();
            try
            {

                CN.Abrir();


                DT = CN.Ejecutar("select * from CatActividades");
                CN.Cerrar();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            try
            {

                dtwDatos = new DataView(DT.Tables[0]);
                dataActividades.DataSource = dtwDatos;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private bool Validar()
        {
            Boolean Validado = true;
            String Mensaje = "";




            if (txtnombre.Text.Trim() == "")
                Mensaje = Mensaje + "   * No se ha capturado el campo nombre.\n";



            if (Mensaje != "")
            {
                Validado = false;
                Mensaje = "Antes de guardar debe corregir lo siguiente:\n\n" + Mensaje;
                MessageBox.Show(Mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return Validado;
        }

        private void dataActividades_DoubleClick(object sender, EventArgs e)
        {
            if (dataActividades.SelectedRows.Count > 0)
            {
                int id = (int)dataActividades.SelectedRows[0].Cells[0].Value;
                buscar(id);
            }
        }

        private void buscar(int id)
        {
            Conexion CN = new Conexion();
            try
            {

                CN.Abrir();


                DT = CN.Ejecutar("select * from catActividades where id =" + id);
                CN.Cerrar();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            try
            {

                txtId.Text = DT.Tables[0].Rows[0].ItemArray[0].ToString();
                txtnombre.Text = DT.Tables[0].Rows[0].ItemArray[1].ToString();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void frmActividades_Load(object sender, EventArgs e)
        {
            try
            {
                llenarGrid();
            }catch(Exception ex){}

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Conexion Con = new Conexion();
            Con.Abrir();
            using (SqlConnection connection = new SqlConnection(Con.ObtenerConexionString()))
            {

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "BorrarActividad";
                    command.CommandType = CommandType.StoredProcedure;

                    int id = Convert.ToInt32(txtId.Text);

                    command.Parameters.Add(new SqlParameter("id", id));

                    command.Parameters.Add(new SqlParameter("Error", SqlDbType.Int, 4));
                    command.Parameters["Error"].Direction = ParameterDirection.Output;

                    command.Parameters.Add(new SqlParameter("borro", SqlDbType.Int, 4));
                    command.Parameters["borro"].Direction = ParameterDirection.Output;



                    try
                    {
                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();
                        if (int.Parse(command.Parameters["borro"].Value.ToString()) > 0)
                            MessageBox.Show("La actividad no  ha sido borrada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtnombre.Text = "";
                        txtId.Text = "";
                        dataActividades.DataSource = null;
                        llenarGrid();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        connection.Close();

                    }

                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtnombre.Text = "";
            txtId.Text = "";

        }
    }
}
