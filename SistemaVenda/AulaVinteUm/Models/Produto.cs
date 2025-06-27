using System.ComponentModel.DataAnnotations;

namespace AulaVinteUm.Models;

public class Produto
{
    [Key]
    public int ProdutoId { get; set; }  // Identificador único do produto
    public string? Nome { get; set; }    // Nome do produto
    public decimal Preco { get; set; }  // Preço do produto
    public int Estoque { get; set; }    // Quantidade disponível em estoque

}