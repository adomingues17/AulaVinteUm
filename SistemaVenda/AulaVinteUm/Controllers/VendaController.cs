using AulaVinteUm.Data;
using AulaVinteUm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AulaVinteUm.Controllers;

public class VendaController : Controller
{
    private readonly ApplicationDbContext _context;

    public VendaController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Ação para exibir o formulário de venda
    public async Task<IActionResult> Create()
    {
        var produtos = await _context.Produtos.ToListAsync();
        ViewBag.Produtos = produtos;
        return View();
    }

    // Ação para salvar a venda
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Venda venda, List<int> produtoIds, List<int> quantidades)
    {
        if (ModelState.IsValid && produtoIds != null && quantidades != null)
        {
            decimal totalVenda = 0;

            // Criação da venda
            venda.DataVenda = DateTime.Now;
            venda.Total = 0;
            _context.Vendas.Add(venda);
            await _context.SaveChangesAsync();

            // Registro dos itens da venda e atualização do estoque
            for (int i = 0; i < produtoIds.Count; i++)
            {
                var produto = await _context.Produtos.FindAsync(produtoIds[i]);
                var quantidade = quantidades[i];

                if (produto != null && produto.Estoque >= quantidade)
                {
                    var itemVenda = new ItemVenda
                    {
                        VendaId = venda.VendaId,
                        ProdutoId = produto.ProdutoId,
                        Quantidade = quantidade,
                        PrecoUnitario = produto.Preco,
                        SubTotal = produto.Preco * quantidade
                    };

                    // Adiciona o item à venda
                    _context.ItensVenda.Add(itemVenda);

                    // Atualiza o estoque do produto
                    produto.Estoque -= quantidade;

                    // Atualiza o total da venda
                    totalVenda += itemVenda.SubTotal;
                }
                else
                {
                    // Se algum produto não tiver estoque suficiente, retorna uma mensagem
                    ModelState.AddModelError("", $"Estoque insuficiente para o produto {produto?.Nome}");
                    return View(venda);
                }
            }

            // Atualiza o total da venda
            venda.Total = totalVenda;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        return View(venda);
    }

    // Ação para listar as vendas
    public async Task<IActionResult> Index()
    {
        var vendas = await _context.Vendas.Include(v => v.ItensVenda)
                                           .ThenInclude(i => i.Produto)
                                           .ToListAsync();
        return View(vendas);
    }
}


