using Supermercado.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Supermercado.Services
{
    public class ProductoService
    {
        static string cadenaDB = "Data Source=.;Initial Catalog=Supermercado;Integrated Security=True";

        public static List<Producto> getAll()
        {
            List<Producto> productos = new List<Producto>();
            string queryDb = "SELECT * FROM productos";
            using (SqlConnection conn = new SqlConnection(cadenaDB))
            {
                try
                {
                    SqlCommand command = new SqlCommand(queryDb, conn);
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        productos.Add(new Producto
                        {
                            Id = (int)reader["id"],
                            NombreProducto = (string)reader["nombreProducto"],
                            Cantidad = (int)reader["cantidad"],
                            Precio = (double)reader["precio"],
                            IdCategoria = (int)reader["idCategoria"]
                        });
                    }
                    reader.Close();
                    return productos;
                }
                catch(Exception e)
                {
                    return productos;
                }
                
            }
            
        }

        public static Producto getProductoByID(int id)
        {
            Producto producto = new Producto();
            string queryDb = "SELECT * FROM productos WHERE id = @idProd";
            using(SqlConnection conn = new SqlConnection(cadenaDB))
            {
                try
                {
                    SqlCommand command = new SqlCommand(queryDb, conn);
                    command.Parameters.AddWithValue("@idProd", id);
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        producto.Id = (int)reader["id"];
                        producto.NombreProducto = (string)reader["nombreProducto"];
                        producto.Cantidad = (int)reader["cantidad"];
                        producto.Precio = (double)reader["precio"];
                        producto.IdCategoria = (int)reader["idCategoria"];
                    }
                    reader.Close();
                    return producto;
                }
                catch(Exception e)
                {
                    return new Producto();
                }
            }
        }

    }
}