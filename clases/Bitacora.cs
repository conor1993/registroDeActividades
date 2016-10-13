using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace registroActividades.clases
{
    class Bitacora
    {

        String NombreForma;
        string cadena;
        
        string usuario;
        String accion;

        private SqlConnection Cnx; // Obj Conexion
        String DtsConection = "";

        public Bitacora() {
        
        }

        public Bitacora(String cadenaConexion, String usuario)
        {
            this.usuario = usuario;
            this.DtsConection = cadenaConexion;
            this.accion = "";
        }


    #region recorrer


        public void recorrerForma(Form forma, int tipo) 
        {    //recorremos la forma

            
            NombreForma = forma.Name;
            cadena = "";


            foreach(Control cl in  forma.Controls)
            {   
                //en caso de encontrar un grupo llamamos a recorrer grupo para buscar los componentes internos
                if (cl is GroupBox)
                {
                    recorrerGroub(cl,tipo);
                }
            }

            switch(tipo){
                    //CONSULTA
                case 1:

                    break;
                //NUEVO MODIFICAR
                case 2:
                    if (!cadena.Equals(""))
                    {
                        guardarBitacora();
                    }
                    break;
                    //ELIMINAR
                case 3:
                    if (!cadena.Equals(""))
                    {
                        guardarBitacora();
                    }
                    break;

            }
        }

        private void recorrerGroub(Control cl , int tipo)
        {

            //recorremos la forma
            foreach (Control c in cl.Controls)
            {    
                 //en caso de contener otra forma llamamos recursibamente a recorrergroub
                if (c is GroupBox)
                {
                    recorrerGroub(c, tipo);
                }
                
                 switch(tipo){
                   
                     case 1:
                         verificarControl(c);
                         break;
                     
                     case 2:
                         verificarcambios(c);
                         break;

                     case 3:
                         accion = "elimino";
                         verificarcambios(c);
                         break;

                     default:
                         break;
                  
                }
            }

        }

        private void verificarControl(Control c)
        {    
            //preguntamos por cada componente para verificar de cual se trata
            if(c is TextBox){
                c.Tag = c.Text;
               
            }

            if(c is ComboBox){
                ComboBox comboGen = (ComboBox)c;
                comboGen.Tag = comboGen.Text;

        
            }

            if(c is CheckBox){
                CheckBox chkgen = (CheckBox)c;
                chkgen.Tag = chkgen.Checked;
            }

            if(c is RadioButton){
                RadioButton rdtgen = (RadioButton)c;
                rdtgen.Tag = rdtgen.Checked;
             }
                
            if(c is DateTimePicker){
                DateTimePicker dtmgen = (DateTimePicker)c;
                dtmgen.Tag = dtmgen.Value;

            }

        }

        private void verificarcambios(Control c)
        {

           
            //preguntamos por cada componente para verificar de cual se trata
            if (c is TextBox)
            {
                try
                {
                    if (!c.Tag.Equals(c.Text))
                    {
                        cadena = cadena + c.Name + ">>" + c.Tag + ">>" + c.Text + "&&";
                        if (accion.Equals(""))
                            accion = "modifico";
                    }
                }
                catch {
                    cadena = cadena + c.Name + ">>" + c.Text + "&&";
                    accion = "nuevo";
                }

                c.Tag = null;
            }

            if (c is ComboBox)
            {
                ComboBox comboGen = (ComboBox)c;
                try
                {
                    
                    if (!c.Tag.Equals(comboGen.Text))
                    {

                        cadena = cadena + c.Name + ">>" + c.Tag + ">>" + comboGen.Text + "&&";
                        if (accion.Equals(""))
                            accion = "modifico";
                    }
                }
                catch {
                    cadena = cadena + c.Name + ">>" + c.Text + "&&";
                    accion = "nuevo";
                }

                c.Tag = null;
            }

            if (c is CheckBox)
            {
                CheckBox chkgen = (CheckBox)c;
                try
                {
                   
                    if (!chkgen.Equals(chkgen.Checked))
                    {
                        cadena = cadena + c.Name + ">>" + c.Tag + ">>" + chkgen.Checked + "&&";
                        if (accion.Equals(""))
                            accion = "modifico";
                    }
                }
                catch {

                    cadena = cadena + c.Name + ">>" + chkgen.Checked + "&&";
                    accion = "nuevo";
                }

                c.Tag = null;
            }

            if (c is RadioButton)
            {
                RadioButton rdtgen = (RadioButton)c;
                try
                {
                  
                    if (!rdtgen.Tag.Equals(rdtgen.Checked))
                    {
                        cadena = cadena + c.Name + ">>" + rdtgen.Tag + ">>" + rdtgen.Checked + "&&";
                        if (accion.Equals(""))
                            accion = "modifico";
                    }
                }
                catch {

                    cadena = cadena + c.Name + ">>" + rdtgen.Tag + ">>" + rdtgen.Checked + "&&";
                    accion = "nuevo";
                }

                c.Tag = null;

            }

            if (c is DateTimePicker)
            {

                DateTimePicker dtmgen = (DateTimePicker)c;
                try
                {
                   
                    dtmgen.Tag = dtmgen.Value;
                    if (!dtmgen.Tag.Equals(dtmgen.Value))
                    {
                        cadena = cadena + c.Name + ">>" + dtmgen.Tag + ">>" + dtmgen.Value + "&&";
                        if(accion.Equals(""))
                            accion = "modifico";
                    }
                }
                catch {
              
                    dtmgen.Tag = dtmgen.Value;
                    cadena = cadena + c.Name + ">>" + dtmgen.Tag + ">>" + dtmgen.Value + "&&";
                    accion = "nuevo";

                }
                c.Tag = null;
            }

        }

        private void guardarBitacora()
        {
            MessageBox.Show("entra");

            try
            {

                Cnx = new SqlConnection(DtsConection);
                Cnx.Open();
                String Comando = "INSERT INTO [dbo].[CatBitacora] ([bitacora],[forma],[usuario],[accion])  VALUES ('" + cadena + "','" + NombreForma + "','" + usuario + "','" + accion + "') ";
                SqlDataAdapter CMD = new SqlDataAdapter(Comando, Cnx); // Creamos un DataAdapter con el Comando y la Conexion
                DataSet DS = new DataSet(); // Creamos el DataSet que Devolvera el Metodo
                Cnx.Close();
                CMD.Fill(DS);

               // Con.Ejecutar("INSERT INTO [dbo].[CatBitacora] ([bitacora],[forma],[usuario],[accion])  VALUES ('" + cadena + "','" + NombreForma + "','" + usuario + "','" + accion + "') ");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally {
            
            }
           
        }

        public void limpiarTag(Form forma)
        {
            foreach (Control cl in forma.Controls)
            {
                //en caso de encontrar un grupo llamamos a recorrer grupo para buscar los componentes internos
                if (cl is GroupBox)
                {
                    limpiarTags(cl);
                }
                cl.Tag = null;
            }
        
        }

        private void limpiarTags(Control cl)
        {

            foreach (Control c in cl.Controls)
            {
                //en caso de contener otra forma llamamos recursibamente a recorrergroub
                if (c is GroupBox)
                {
                    limpiarTags(c);
                }

                c.Tag = null;
            }
            
        }


    #endregion

 

    }
}
