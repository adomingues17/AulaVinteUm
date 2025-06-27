using System.ComponentModel.DataAnnotations;

namespace AulaVinteUm.Models;

public class ItemVenda
{
    [Key]
    public int ItemVendaId { get; set; }    // Identificador único do item
    public int VendaId { get; set; }        // Relacionamento com a Venda
    public int ProdutoId { get; set; }      // Relacionamento com o Produto
    public int Quantidade { get; set; }    // Quantidade de produtos vendidos
    public decimal PrecoUnitario { get; set; } // Preço unitário do produto
    public decimal SubTotal { get; set; }  // Subtotal do item (PreçoUnitario * Quantidade)
    public Produto Produto { get; set; }    // Relacionamento com o Produto
    public Venda Venda { get; set; }        // Relacionamento com a Venda

}
