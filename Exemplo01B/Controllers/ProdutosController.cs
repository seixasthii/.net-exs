using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exemplo01B.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exemplo01.Controllers
{
    public class ProdutosController : Controller
    {
        //'simular' um banco de dados na memória
        private static List<Produto> _produtos = new List<Produto>
        {
            new Produto {Id = 1, Nome = "Caderno", Preco = 20, Quantidade = 15},
            new Produto {Id = 2, Nome = "Tablet", Preco = 2000, Quantidade = 6}
        };

        //get /Produtos
        public IActionResult Index()
        {
            return View(_produtos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        //Post: /Produtos/Criar
        [HttpPost]
        public IActionResult Criar(Produto produto)
        {
            produto.Id = _produtos.Count + 1; // simulação do AUTO_INCREMENT
            _produtos.Add(produto);

            TempData["Mensagem"] = $"Produto criado com sucesso!!";

            return RedirectToAction("Index");
        }

        //GET: /Produtos/Edit/1
        public IActionResult Edit(int id)
        {
            var produto = _produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        //Post: /Produtos/Edit/1
        [HttpPost]
        public IActionResult Edit(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }
            var produtoExistente = _produtos.FirstOrDefault(p => p.Id == id);
            if (produtoExistente == null)
            {
                return NotFound();
            }

            //Atualiza os dados
            produtoExistente.Nome = produto.Nome;
            produtoExistente.Preco = produto.Preco;
            produtoExistente.Quantidade = produto.Quantidade;
            return RedirectToAction(nameof(Index)); //redireciona para pagina da lista de produtos
        }

        // GET: /Produtos/Delete
        public IActionResult Delete(int id)
        {
            var produto = _produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        //Post: /Produtos/Delete/1
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var produto = _produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
            {
                return NotFound();
            }
            _produtos.Remove(produto);
            return RedirectToAction(nameof(Index));
        }
        

    }
}