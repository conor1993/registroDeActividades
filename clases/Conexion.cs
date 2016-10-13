using System.Data;

using System.Data.SqlClient;

using System.Data.Common;

/* Creamos la Clase */

class Conexion

{

private SqlConnection Con; // Obj Conexion
string DtsConection = "";
public Conexion()

{


   DtsConection = "Data Source=INTEGRASRV3; Database=RegistroActividades2; User ID=sa; Password=int3gr@;";

   Con = new SqlConnection(DtsConection);

}

public void Abrir() // Metodo para Abrir la Conexion

{

Con.Open();

}

public string ObtenerConexionString()
{
    return DtsConection;
}

public void Cerrar() // Metodo para Cerrar la Conexion

{

Con.Close();

}

public DataSet Ejecutar(string Comando) // Metodo para Ejecutar Comandos

{

SqlDataAdapter CMD = new SqlDataAdapter(Comando, Con); // Creamos un DataAdapter con el Comando y la Conexion

DataSet DS = new DataSet(); // Creamos el DataSet que Devolvera el Metodo

CMD.Fill(DS); 
    // Ejecutamos el Comando en la Tabla

return DS; // Regresamos el DataSet

}


} // Fin de la Clase