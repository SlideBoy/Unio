using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Unio.modelos
{
    public class Autonomos : Banco
    {
        public List<Autonomo> CarregarAutonomos(string comandoBusca) {
            List<Autonomo> Autonomos = new List<Autonomo>();

            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vBusca", comandoBusca));

            Conectar();
            using (MySqlDataReader dados = Consultar("buscarAutonomos", parametros))
            {
                if (dados.HasRows)
                {
                    while (dados.Read())
                    {

                        #region Cidade
                        Cidade cidade = new Cidade();
                        cidade.Codigo = dados.GetInt16(7);
                        cidade.Nome = dados.GetString(8);
                        #endregion

                        #region Estado
                        Estado estado = new Estado();
                        estado.Sigla = dados.GetString(9);
                        estado.Nome = dados.GetString(10);
                        #endregion

                        #region FormasDePagamento
                        //string[] NomeformaPagamento = dados.GetString(11).Split(',');
                        //string[] CodigoformaPagamento = dados.GetString(12).Split(',');

                        //List<FormaPagamento> formasPagamento = new List<FormaPagamento>();

                        //for (int i = 0; i < NomeformaPagamento.Length; i++)
                        //{
                        //    FormaPagamento formaPagamento = new FormaPagamento();
                        //    int codigo = int.Parse(CodigoformaPagamento[i]);
                        //    formaPagamento.Codigo = codigo;
                        //    formaPagamento.Nome = NomeformaPagamento[i];

                        //    formasPagamento.Add(formaPagamento);
                        //}
                        #endregion

                        #region AreaDeAtuacao
                        string[] CodigoAreaAtuacao = dados.GetString(13).Split(',');
                        string[] NomeAreaAtuacao = dados.GetString(14).Split(',');
                        string[] CodigoProfissao = dados.GetString(11).Split(',');
                        string[] NomeProfissao = dados.GetString(12).Split(',');

                        List<AreaAtuacao> AreasAtuacoes = new List<AreaAtuacao>();
                        List<Profissao> profissoes = new List<Profissao>();

                        for (int i = 0; i < NomeProfissao.Length; i++)
                        {
                            AreaAtuacao areaAtuacao = new AreaAtuacao(int.Parse(CodigoAreaAtuacao[i]), NomeAreaAtuacao[i]);
                            Profissao profissao = new Profissao(int.Parse(CodigoProfissao[i]), NomeProfissao[i], areaAtuacao);
                            AreasAtuacoes.Add(areaAtuacao);
                            profissoes.Add(profissao);
                        }
                        #endregion

                        #region Emblema
                        Emblema emblema = new Emblema();
                        emblema.Codigo = dados.GetInt32(16);
                        emblema.Nome = dados.GetString(17);
                        #endregion

                        #region Autonomo
                        Autonomo autonomo = new Autonomo(dados.GetString(0), dados.GetString(1), dados.GetString(2), dados.GetString(3), cidade, dados.GetString(4), dados.GetBoolean(5), System.DateTime.Now, estado, null, profissoes, emblema, (Byte[])dados[06], dados.GetDouble(15));
                        #endregion

                        Autonomos.Add(autonomo);
                    }
                }
            }
            Desconectar();
            return Autonomos;
        }


        public List<Autonomo> CarregarContratados(string emailCliente)
        {
            Conectar();

            List<Autonomo> listContratados = new List<Autonomo>();

            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vEmailCliente", emailCliente));

            using (MySqlDataReader dados = Consultar("CarregarChatsCliente", parametros))
            {
                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        Autonomo autonomo = new Autonomo();
                        autonomo.Email = dados.GetString(0);
                        autonomo.PreencherDados();

                        listContratados.Add(autonomo);
                    }
                }
            }

            Desconectar();

            return listContratados;
        }
    }
}