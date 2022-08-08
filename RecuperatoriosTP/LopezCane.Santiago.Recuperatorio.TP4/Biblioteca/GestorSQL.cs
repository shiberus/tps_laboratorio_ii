using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Biblioteca
{
    public static class GestorSQL
    {
        public static string stringConexion;

        static GestorSQL()
        {
            GestorSQL.stringConexion = "Data Source =.; Database = KIOSCO_DB; Trusted_Connection = True;";
        }

        public static List<Kiosco> CargarDatos()
        {
            List<Kiosco> kioscos = new List<Kiosco>();

            using (SqlConnection conexion = new SqlConnection(GestorSQL.stringConexion))
            {
                conexion.Open();

                CargarKioscos(conexion, kioscos);
                CargarProductos(conexion, kioscos);
            }

            return kioscos;
        }

        private static void CargarKioscos(SqlConnection conexion, List<Kiosco> kioscos)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM kioscos", conexion);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string nombre = reader.GetString(1);
                int registradora = reader.GetInt32(2);

                Kiosco kiosco = new Kiosco(id, nombre, registradora);
                kioscos.Add(kiosco);
            }

            reader.Close();
        }

        private static void CargarProductos(SqlConnection conexion, List<Kiosco> kioscos)
        {
            foreach (Kiosco kiosco in kioscos)
            {

                SqlCommand cmd = new SqlCommand($"SELECT * FROM productos WHERE id_kiosco ={kiosco.ID}", conexion);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string nombre = reader.GetString(1);
                    string descripcion = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    int precio = reader.GetInt32(3);

                    if (reader.IsDBNull(4))
                    {
                        Producto producto = new Producto(nombre, precio, descripcion);
                        kiosco.Gondola.Add(producto);
                    }
                    else
                    {
                        Bebida.medida tamanio = (Bebida.medida)reader.GetInt32(4);
                        Bebida bebida = new Bebida(nombre, precio, descripcion, tamanio);
                        kiosco.Heladera.Add(bebida);
                    }
                }

                reader.Close();
            }
        }

        public static void AgregarKiosco(Kiosco kiosco)
        {
            string query = "INSERT INTO kioscos (id, nombre, registradora) VALUES (@id, @nombre, @registradora)";
            using (SqlConnection conexion = new SqlConnection(GestorSQL.stringConexion))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand(query, conexion);

                cmd.Parameters.AddWithValue("id", kiosco.ID);
                cmd.Parameters.AddWithValue("nombre", kiosco.Nombre);
                cmd.Parameters.AddWithValue("registradora", kiosco.Registradora);

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
        }

        public static void EliminarKiosco(Kiosco kiosco)
        {
            string query = $"DELETE FROM kioscos WHERE id ={kiosco.ID}";
            using (SqlConnection conexion = new SqlConnection(GestorSQL.stringConexion))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand(query, conexion);

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
        }

        public static void ActualizarKiosco(Kiosco kiosco)
        {
            using (SqlConnection conexion = new SqlConnection(GestorSQL.stringConexion))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand($"UPDATE kioscos SET registradora ={kiosco.Registradora} WHERE id ={kiosco.ID}", conexion);

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }

            string query = $"DELETE FROM productos WHERE id_kiosco ={kiosco.ID}";
            using (SqlConnection conexion = new SqlConnection(GestorSQL.stringConexion))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand(query, conexion);

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }

            foreach (Producto producto in kiosco.Gondola)
            {
                string queryProducto = $"INSERT INTO productos(nombre, descripcion, precio, id_kiosco) " +
                                       $"VALUES (@nombre, @descripcion, @precio, @id_kiosco)";

                using (SqlConnection conexion = new SqlConnection(GestorSQL.stringConexion))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand(queryProducto, conexion);

                    cmd.Parameters.AddWithValue("nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("precio", producto.Precio);
                    cmd.Parameters.AddWithValue("id_kiosco", kiosco.ID);

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
            foreach (Bebida bebida in kiosco.Heladera)
            {
                string queryProducto = $"INSERT INTO productos(nombre, descripcion, precio, tamanio, id_kiosco) " +
                                       $"VALUES (@nombre, @descripcion, @precio, @tamanio, @id_kiosco)";

                using (SqlConnection conexion = new SqlConnection(GestorSQL.stringConexion))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand(queryProducto, conexion);

                    cmd.Parameters.AddWithValue("nombre", bebida.Nombre);
                    cmd.Parameters.AddWithValue("descripcion", bebida.Descripcion);
                    cmd.Parameters.AddWithValue("precio", bebida.PrecioBase);
                    cmd.Parameters.AddWithValue("tamanio", (int) bebida.Tamanio);
                    cmd.Parameters.AddWithValue("id_kiosco", kiosco.ID);

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }
    }
}
