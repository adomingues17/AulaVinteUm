using System.ComponentModel.DataAnnotations;

namespace AulaVinteUm.Models;

public class Venda
{
    [Key]
    public int VendaId { get; set; }       // Identificador único da venda
    public DateTime DataVenda { get; set; } // Data da venda
    public decimal Total { get; set; }     // Valor total da venda
    public List<ItemVenda>? ItensVenda { get; set; }  // Relacionamento com os itens da venda

}