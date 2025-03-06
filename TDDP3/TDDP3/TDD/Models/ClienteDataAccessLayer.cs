using System.Data;
using System.Data.SqlClient;
//using Npgsql.Util;
//using NpgsqlTypes;
//using Npgsql;
using TDD.Data;

namespace TDD.Models
{
    public class ClienteDataAccessLayer
    {
        //Esto coloco simplemente con fines explicativos
        string conneccionString = "Data Source=LAPTOPMATIAS; Initial Catalog=Productos; User ID=sa; Password=ma2604";


        public List<Cliente> getAllClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            //NpgsqlConnection -> SqlConnection para usar postgress
            using (SqlConnection con = new SqlConnection(conneccionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_SelectAll", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.Codigo = Convert.ToInt32(rdr["Codigo"]);
                    cliente.Cedula = rdr["Cedula"].ToString();
                    cliente.Apellidos = rdr["Apellidos"].ToString();
                    cliente.Nombres = rdr["Nombres"].ToString();
                    cliente.FechaNacimiento = Convert.ToDateTime(rdr["FechaNacimiento"]);
                    cliente.Mail = rdr["Mail"].ToString();
                    cliente.Telefono = rdr["Telefono"].ToString();
                    cliente.Direccion = rdr["Direccion"].ToString();
                    cliente.Estado = Convert.ToBoolean(rdr["Estado"]);
                    listaClientes.Add(cliente);
                }

                con.Close();
            }
            return listaClientes;
        }

        public void AddCliente(Cliente Cliente)
        {
            using (SqlConnection con = new SqlConnection(conneccionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_Insert", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@cedula", Cliente.Cedula);
                cmd.Parameters.AddWithValue("@apellidos", Cliente.Apellidos);
                cmd.Parameters.AddWithValue("@nombres", Cliente.Nombres);
                cmd.Parameters.AddWithValue("@fechanacimiento", Cliente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@mail", Cliente.Mail);
                cmd.Parameters.AddWithValue("@telefono", Cliente.Telefono);
                cmd.Parameters.AddWithValue("@direccion", Cliente.Direccion);
                cmd.Parameters.AddWithValue("@estado", Cliente.Estado);


                con.Open();
                cmd.ExecuteNonQuery();


            }
        }


        public void UpdateCliente(Cliente Cliente)
        {
            using (SqlConnection con = new SqlConnection(conneccionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Codigo", Cliente.Codigo);
                cmd.Parameters.AddWithValue("@Cedula", Cliente.Cedula);
                cmd.Parameters.AddWithValue("@Apellidos", Cliente.Apellidos);
                cmd.Parameters.AddWithValue("@Nombres", Cliente.Nombres);
                cmd.Parameters.AddWithValue("@FechaNacimiento", Cliente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Mail", Cliente.Mail);
                cmd.Parameters.AddWithValue("@Telefono", Cliente.Telefono);
                cmd.Parameters.AddWithValue("@Direccion", Cliente.Direccion ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Estado", Cliente.Estado);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


        public void DeleteCliente(int codigo)
        {
            using (SqlConnection con = new SqlConnection(conneccionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_Delete", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Codigo", codigo);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

    }
}
