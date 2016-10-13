using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using registroActividades.clases;

namespace registroActividades.formas
{
    public partial class frmModulo : Form
    {
        DataSet DT;
        DataSet dtsDtaos;
        DataView dtwDatos;

        public frmModulo()
        {
            InitializeComponent();
        }

        private void frmModulo_Load(object sender, EventArgs e)
        {
            llenarcombo();
            llenarGrid();

        }

        private void llenarGrid()
        {
            Conexion CN = new Conexion();
            try
            {

                CN.Abrir();


                DT = CN.Ejecutar("select CatModulos.id, CatModulos.descripcion as descripcion, CatProyecto.descripcion as proyecto from CatModulos JOIN CatProyecto ON CatModulos.idProyecto = CatProyecto.id;");
                CN.Cerrar();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            try
            {

                dtwDatos = new DataView(DT.Tables[0]);
                dataformas.DataSource = dtwDatos;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void llenarcombo()
        {
            

            Conexion CN = new Conexion();
            try
            {

                CN.Abrir();

          
                DT = CN.Ejecutar("select *  from CatProyecto ");
                CN.Cerrar();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            try
            {
                cmbProyecto.DisplayMember = "descripcion";
                cmbProyecto.ValueMember = "id";
                cmbProyecto.DataSource = DT.Tables[0].DefaultView;
                cmbProyecto.SelectedIndex = -1;
                cmbProyecto.Text = "Seleccione una opción";
            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message);
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            if (!Validar())
                return;

            String des = txtnombre.Text;
            int proyecto = (int)cmbProyecto.SelectedValue;
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
                    command.CommandText = "GuardarModulo";
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.Add(new SqlParameter("id", id));
                    command.Parameters.Add(new SqlParameter("descripcion", des));
                    command.Parameters.Add(new SqlParameter("proyecto", proyecto));

                    try
                    {
                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();


                        //agregar  la bitacora
                        
                        Bitacora bitac = new Bitacora(Con.ObtenerConexionString(),"juan");
                        bitac.recorrerForma(this, 2);
                        //----------------------


                        LIMPIAR();
                        dataformas.DataSource = null;
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

        private void buscar(int id)
        {

            Conexion CN = new Conexion();
            try
            {

                CN.Abrir();


                DT = CN.Ejecutar("select CatModulos.id, CatModulos.descripcion as descripcion, CatProyecto.id from CatModulos JOIN CatProyecto ON CatModulos.idProyecto = CatProyecto.id where CatModulos.id="+id);
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
                cmbProyecto.SelectedValue = int.Parse(DT.Tables[0].Rows[0].ItemArray[2].ToString());

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dataformas_DoubleClick(object sender, EventArgs e)
        {
            if (dataformas.SelectedRows.Count > 0)
            {
                int id = (int)dataformas.SelectedRows[0].Cells[0].Value;
                buscar(id);
            }


            Bitacora bitac = new Bitacora();
            bitac.recorrerForma(this, 1);

        }

        private bool Validar()
        {
            Boolean Validado = true;
            String Mensaje = "";



           
            if (txtnombre.Text.Trim() == "")
                Mensaje = Mensaje + "   * No se ha capturado el campo descripción.\n";

            if (cmbProyecto.SelectedIndex == -1)
                Mensaje = Mensaje + "   * No se ha capturado el campo proyecto.\n";




            if (Mensaje != "")
            {
                Validado = false;
                Mensaje = "Antes de guardar debe corregir lo siguiente:\n\n" + Mensaje;
                MessageBox.Show(Mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return Validado;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {


            Conexion Con = new Conexion();
            Con.Abrir();
            using (SqlConnection connection = new SqlConnection(Con.ObtenerConexionString()))
            {

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection; 
                    command.CommandText = "BorrarModulo";
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
                             MessageBox.Show("El Modulo no  ha sido borrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtnombre.Text = "";
                        cmbProyecto.Text = "";
                        txtId.Text = "";
                        dataformas.DataSource = null;
                        llenarGrid();


                        Bitacora bitac = new Bitacora(Con.ObtenerConexionString(),"juan");
                        bitac.recorrerForma(this, 3);
                        //bitacora

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

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            LIMPIAR();
            Bitacora bitac = new Bitacora();
            bitac.limpiarTag(this);

        }

        private void LIMPIAR()
        {   

            txtId.Text = "";
            txtnombre.Text = "";
            cmbProyecto.SelectedIndex = -1;
            cmbProyecto.Text = "Seleccione una opción";
        }

    }
}
