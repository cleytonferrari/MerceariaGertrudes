using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using MerceariaDaGertrudes.Models;
using MerceariaDaGertrudes.Repositorio;

namespace MerceariaDaGertrudes.Aplicacao
{
    public class ProdutoAplicacao
    {
        private readonly Contexto contexto = new Contexto();

        private void Inserir(Produto produto)
        {
            var strQuery = " ";
            strQuery += " INSERT INTO produto (Nome, Preco, Validade, Descricao) ";
            strQuery += string.Format(" VALUES ('{0}','{1}','{2}','{3}') ",
                produto.Nome, produto.Preco.ToString(CultureInfo.InvariantCulture), produto.Validade, produto.Descricao);
            contexto.ExecutaComando(strQuery);
        }

        private void Alterar(Produto produto)
        {
            var strQuery = " ";
            strQuery += " UPDATE produto SET ";
            strQuery += string.Format(" Nome = '{0}', ", produto.Nome);
            strQuery += string.Format(" Preco = '{0}', ", produto.Preco.ToString(CultureInfo.InvariantCulture));
            strQuery += string.Format(" Validade = '{0}', ", produto.Validade);
            strQuery += string.Format(" Descricao = '{0}' ", produto.Descricao);
            strQuery += string.Format(" WHERE ProdutoId = {0}", produto.ProdutoId);
            contexto.ExecutaComando(strQuery);
        }

        public void Salvar(Produto produto)
        {
            if (produto.ProdutoId > 0)
                Alterar(produto);
            else
                Inserir(produto);
        }

        public void Excluir(int id)
        {
            var strQuery = string.Format(" DELETE FROM produto WHERE ProdutoId = {0} ", id);
            contexto.ExecutaComando(strQuery);
        }

        public List<Produto> ListarTodos()
        {
            var strQuery = " SELECT * FROM produto ";
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno);
        }

        public Produto ListarPorId(int id)
        {
            var strQuery = " SELECT * FROM produto WHERE ProdutoId = " + id;
            var retorno = contexto.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno).FirstOrDefault();
        }

        private List<Produto> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var produtos = new List<Produto>();
            while (reader.Read())
            {
                var tempObjeto = new Produto
                {
                    ProdutoId = int.Parse(reader["ProdutoId"].ToString()),
                    Nome = reader["Nome"].ToString(),
                    Preco = Decimal.Parse(reader["Preco"].ToString()),
                    Validade = DateTime.Parse(reader["Validade"].ToString()),
                    Descricao = reader["Descricao"].ToString()
                };
                produtos.Add(tempObjeto);
            }
            return produtos;
        }
    }
}