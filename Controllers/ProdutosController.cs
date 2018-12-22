using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using CatalogoProduto.Repositories;
using CatalogoProduto.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoRepository ProdutoRepository;
        public ProdutosController(ProdutoRepository produtoRepository)
        {
            ProdutoRepository = produtoRepository;
        }

        [HttpGet]
        [Route("versao")]
        public string Versao()
        {
            return "Versão: 2.0";
        }

        [HttpPost]
        [Route("novo")]
        public void Inserir([FromBody]InserirProdutoViewModel produtoViewModel)
        {
            Produto produto = new Produto();
            produto.Nome = produtoViewModel.Nome;
            produto.Descricao = produtoViewModel.Descricao;
            produto.Quantidade = produtoViewModel.Quantidade;
            produto.Preco = produtoViewModel.Preco;
            produto.Criacao = DateTime.Now;

            ProdutoRepository.Insert(produto);
        }

        [HttpPut]
        [Route("editar")]
        public void Editar([FromBody]EditarProdutoViewModel produtoViewModel)
        {
            Produto produto = new Produto();
            produto.Id = produtoViewModel.Id;
            produto.Nome = produtoViewModel.Nome;
            produto.Descricao = produtoViewModel.Descricao;
            produto.Quantidade = produtoViewModel.Quantidade;
            produto.Preco = produtoViewModel.Preco;
            produto.Alteracao = DateTime.Now;

            ProdutoRepository.Update(produto);
        }

        [HttpDelete]
        [Route("apagar/{id}")]
        public void Deletar(int id)
        {
            var result = ProdutoRepository.Get(id);
            if (result.Id > 0)
            {
                ProdutoRepository.Delete(result);
            }
        }

        [HttpGet]
        [Route("obter/{id}")]
        public ObterProdutoViewModel obter(int id)
        {
            var result = ProdutoRepository.Get(id);

            return new ObterProdutoViewModel()
            {
                Id = result.Id,
                Nome = result.Nome,
                Descricao = result.Descricao,
                Preco = result.Preco,
                Quantidade = result.Quantidade
            };
        }


        [HttpGet]
        [Route("obtertodos")]
        public IEnumerable<ObterTodosProdutoViewModel> obtertodos()
        {
            var result = ProdutoRepository.GetAll();

            IList<ObterTodosProdutoViewModel> lista =
            new List<ObterTodosProdutoViewModel>();

            foreach (var item in result)
            {

                lista.Add(new ObterTodosProdutoViewModel()
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Descricao = item.Descricao,
                    Preco = item.Preco,
                    Quantidade = item.Quantidade,
                    DataCriacao = item.Criacao,
                    DataAlteracao = item.Alteracao
                });
                
            }

            return lista;
        }
    }



}
