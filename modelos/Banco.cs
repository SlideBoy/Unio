using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Unio.modelos
{
    public class Banco
    {
        private MySqlConnection conexao = null;
        private MySqlCommand cSQL = null;

        protected void Conectar()
        {
            conexao = new MySqlConnection(Conexao.getConexao());

            try
            {
                conexao.Open();
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível conectar");
            }
        }

        protected void Desconectar()
        {
            try
            {
                if (conexao != null)
                {
                    if (conexao.State == System.Data.ConnectionState.Open)
                    {
                        conexao.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível desconectar!");
            }
        }

        protected void Executar(string nomeSP, List<Parametro> parametros)
        {
            //Conectar();
            try
            {
                cSQL = new MySqlCommand(nomeSP, conexao);
                cSQL.CommandType = System.Data.CommandType.StoredProcedure;
                cSQL.Parameters.Clear();

                if (parametros != null)
                {
                    for (int i = 0; i < parametros.Count; i++)
                    {
                        cSQL.Parameters.AddWithValue(parametros[i].Nome, parametros[i].Valor);
                    }
                }

                cSQL.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível realizar o comando!");
            }
            finally
            {
                Desconectar();
            }
        }

        protected void Executar(string comando)
        {
            //Conectar();
            try
            {
                cSQL = new MySqlCommand(comando, conexao);
                cSQL.ExecuteNonQuery();
            }
            catch
            {
                throw new Exception("Não foi possível realizar o comando!");
            }
            finally
            {
                Desconectar();
            }

        }

        protected MySqlDataReader Consultar(string nomeSP, List<Parametro> parametros)
        {
            //Conectar();

            try
            {
                cSQL = new MySqlCommand(nomeSP, conexao);
                cSQL.CommandType = System.Data.CommandType.StoredProcedure;
                cSQL.Parameters.Clear();

                if (parametros != null)
                {
                    for (int i = 0; i < parametros.Count; i++)
                    {
                        cSQL.Parameters.AddWithValue(parametros[i].Nome, parametros[i].Valor);
                    }
                }

                return cSQL.ExecuteReader();
            }
            catch (Exception)
            {
               throw new Exception("Não foi possível realizar a consulta!");
            }
        }

        protected MySqlDataReader Consultar(string comando)
        {
            //Conectar();

            try
            {
                cSQL = new MySqlCommand(comando, conexao);
                return cSQL.ExecuteReader();
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível realizar a consulta!");
            }
        }




    }
}