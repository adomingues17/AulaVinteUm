using AulaVinteUm.Data;
using AulaVinteUm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AulaVinteUm.Controllers;

public class ProdutoController : Controller
{

    private readonly ApplicationDbContext _context;

    public ProdutoController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Ação para listar todos os produtos
    public async Task<IActionResult> Index()
    {
        var produtos = await _context.Produtos.ToListAsync();
        return View(produtos);
    }

    // Ação para exibir o formulário de criação de produto
    public IActionResult Create()
    {
        return View();
    }

    // Ação para salvar o novo produto
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ProdutoId,Nome,Preco,Estoque")] Produto produto)
    {
        if (ModelState.IsValid)
        {
            _context.Add(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(produto);
    }

    // Ação para editar um produto existente
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var produto = await _context.Produtos.FindAsync(id);
        if (produto == null)
        {
            return NotFound();
        }
        return View(produto);
    }
    /*
    [HttpPost]
    public IActionResult Edit(Produto prod)
    {
        if (ModelState.IsValid)
        {
            _context.Produtos.Update(prod);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
    */
    /*
    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind("ProdutoId,Nome,Preco,Estoque")] Produto produto)
    {
        if (ModelState.IsValid)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
    */

    
    // Ação para salvar a edição de um produto
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ProdutoId,Nome,Preco,Estoque")] Produto produto)
    {
        if (id != produto.ProdutoId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(produto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(produto.ProdutoId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(produto);
    }
    

    // Ação para excluir um produto
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var produto = await _context.Produtos
            .FirstOrDefaultAsync(m => m.ProdutoId == id);
        if (produto == null)
        {
            return NotFound();
        }

        return View(produto);
    }

    // Ação para confirmar a exclusão do produto
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);
        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // Método auxiliar para verificar se o produto existe
    private bool ProdutoExists(int id)
    {
        return _context.Produtos.Any(e => e.ProdutoId == id);
    }
}
   

