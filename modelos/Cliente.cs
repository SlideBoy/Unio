using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Unio.modelos
{
    public class Cliente : Usuario
    {
        public List<Autonomo> Favoritos { get; set; }

        public Cliente(string Email, string Nome, string CPF, string Telefone, Cidade Cidade, byte[] Foto)
        {
            this.Email = Email;
            this.Nome = Nome;
            this.CPF = CPF;
            this.Telefone = Telefone;
            this.Cidade = Cidade;
            this.Foto = Foto;
        }

        public Cliente() { }

        public bool CadastrarCliente(string[] dadosCliente)
        {
            Conectar();

            List<Parametro> parametrosPrimarios = new List<Parametro>();
            parametrosPrimarios.Add(new Parametro("vEmail", dadosCliente[1]));
            parametrosPrimarios.Add(new Parametro("vCPF", dadosCliente[2]));

            //Analisar tanto no cliente tanto no autonomo : busca pelo usuario
            MySqlDataReader dados = Consultar("buscarCliente", parametrosPrimarios);
            if (dados.Read())
            {
                if (dados != null)
                {
                    if (!dados.IsClosed)
                    {
                        dados.Close();
                    }

                    return true;
                }
            }

            if (!dados.IsClosed)
            {
                dados.Close();
            }

            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", dadosCliente[1]));
            parametros.Add(new Parametro("vCPF", dadosCliente[2]));
            parametros.Add(new Parametro("vNome", dadosCliente[0]));
            parametros.Add(new Parametro("vSenha", dadosCliente[3]));
            parametros.Add(new Parametro("vTelefone", dadosCliente[4]));
            parametros.Add(new Parametro("vCidade", dadosCliente[5]));

            Executar("cadastrarCliente", parametros);

            Desconectar();

            return false;
        }

        public void PreencherDados()
        {
            Conectar();

            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmail", this.Email));

            using (MySqlDataReader dados = Consultar("PreencherDadosCliente", parametros))
            {
                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        Cidade cidade = new Cidade();
                        cidade.Nome = dados.GetString(4);
                        cidade.Codigo = dados.GetInt32(5);

                        Estado estado = new Estado();
                        estado.Nome = dados.GetString(7);
                        estado.Sigla = dados.GetString(8);

                        this.Nome = dados.GetString(1);
                        this.CPF = dados.GetString(2);
                        this.Telefone = dados.GetString(3);
                        this.Cidade = cidade;
                        this.Estado = estado;
                        this.Foto = (byte[])dados[6];
                    }
                }
            }

            Desconectar();

        }
    }
}