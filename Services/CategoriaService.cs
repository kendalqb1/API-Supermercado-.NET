using Supermercado.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Supermercado.Services
{
    public class CategoriaService
    {
        static string cadenaDB = "Data Source=.;Initial Catalog=Supermercado;Integrated Security=True";

        public static void debugPrint(string cadena)
        {
            System.Diagnostics.Debug.WriteLine(cadena);
        }
        static CategoriaService()
        {
        }

        public static List<Categoria> GetAll()
        {
            List<Categoria> categorias = new List<Categoria>();
            string queryDB = "SELECT * FROM categorias";
            using (SqlConnection conn = new SqlConnection(cadenaDB))
            {
                SqlCommand command = new SqlCommand(queryDB, conn);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        categorias.Add(new Categoria { Id = (int)reader["id"], NombreCategoria = (string)reader["nombreCategoria"] });
                    }
                    return categorias;
                }
                finally
                {
                    reader.Close();
                }
            }
        }
        public static Categoria GetItem(int id)
        {
            Categoria cat = new Categoria();
            string queryDB = "SELECT * FROM categorias WHERE id = @idCat";
            using (SqlConnection conn = new SqlConnection(cadenaDB))
            {
                SqlCommand command = new SqlCommand(queryDB, conn);
                command.Parameters.AddWithValue("@idCat", id);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while(reader.Read())
                    {
                        cat.Id = (int)reader["id"];
                        cat.NombreCategoria = (string)reader["nombreCategoria"];
                    }
                    return cat;
                }
                finally
                {
                    reader.Close();
                }
            }
        }

        public static bool Add(Categoria cat)
        {
            string queryDB = "INSERT INTO categorias (nombreCategoria) VALUES (@nombreCat);";
            using (SqlConnection conn = new SqlConnection(cadenaDB))
            {
                SqlCommand command = new SqlCommand(queryDB, conn);
                command.Parameters.AddWithValue("@nombreCat", cat.NombreCategoria);
               try
               {
                    conn.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return true;
               }
               catch (Exception e)
               {
                    Console.WriteLine(e);
                    return false;
               }
            }
        }
        public static bool Delete(int id)
        {
            string queryDB = "DELETE FROM categorias WHERE id = @idCat";
            using (SqlConnection conn = new SqlConnection(cadenaDB))
            {
                SqlCommand command = new SqlCommand(queryDB, conn);
                command.Parameters.AddWithValue("@idCat", id);
                try
                {
                    conn.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            }

        }
        public static bool Update(int id, Categoria cat)
        {
            string queryDB = "UPDATE categorias SET nombreCategoria = @nomCat WHERE id = @idCat;";
            using (SqlConnection conn = new SqlConnection(cadenaDB))
            {
                SqlCommand command = new SqlCommand(queryDB, conn);
                command.Parameters.AddWithValue("@idCat", id);
                command.Parameters.AddWithValue("@nomCat", cat.NombreCategoria);
                try
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            }
        }
    }
}