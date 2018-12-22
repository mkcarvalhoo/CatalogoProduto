using System.Collections.Generic;
using System.Linq;
using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoProduto.Repositories
{
    public class ProdutoRepository
    {
        public readonly CatalagoContext CatalagoContext ;

        public ProdutoRepository( CatalagoContext catalagoContext )
        {
            CatalagoContext = catalagoContext;
        }

        public void Insert(Produto produto) 
        {
            CatalagoContext.Produtos.Add(produto);
            CatalagoContext.SaveChanges();
        }

        public void Update(Produto produto) 
        {
            CatalagoContext.Entry<Produto>(produto).State = EntityState.Modified;
            CatalagoContext.SaveChanges();
        }

        public void Delete(Produto produto) 
        {
            CatalagoContext.Remove(produto);
            CatalagoContext.SaveChanges();
        }

        public Produto Get (int id) 
        {
            var result = CatalagoContext.Produtos
            .Find(id);

            return result;
        }

        public IEnumerable<Produto> GetAll() 
        {
            var result =CatalagoContext.Produtos.AsNoTracking().ToList();

            return result;
        }
    }
}