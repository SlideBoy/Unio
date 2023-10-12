using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Unio.modelos
{
    public class Profissoes : Banco
    {

        public List<Profissao> carregarProfissoes()
        {

            Conectar();

            List<Profissao> profissoes = new List<Profissao>();
            MySqlDataReader dados = Consultar("carregarProfissoes", null);

            while (dados.Read())
            {
                Profissao profissao = new Profissao();
                profissao.Codigo = dados.GetInt16(0);
                profissao.Nome = dados.GetString(1);

                profissoes.Add(profissao);
            }

            if (!dados.IsClosed)
            {
                dados.Close();
            }

            Desconectar();

            return profissoes;
        }

        public List<Profissao> carregarProfissoesNaBusca(string busca)
        {
            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(new Parametro("vBusca", busca));

            Conectar();

            List<Profissao> profissoes = new List<Profissao>();
            MySqlDataReader dados = Consultar("carregarProfissoesNaBusca", parametros);

            while (dados.Read())
            {
                AreaAtuacao areaAtuacao = new AreaAtuacao();
                areaAtuacao.Codigo = dados.GetInt16(2);
                areaAtuacao.Nome = dados.GetString(3);

                Profissao profissao = new Profissao();

                profissao.Codigo = dados.GetInt16(0);
                profissao.Nome = dados.GetString(1);
                profissao.areaAtuacao = areaAtuacao;


                profissoes.Add(profissao);
            }

            if (!dados.IsClosed)
            {
                dados.Close();
            }

            Desconectar();

            return profissoes;
        }

    }
}