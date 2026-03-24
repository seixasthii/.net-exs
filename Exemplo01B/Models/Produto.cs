namespace Exemplo01B.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public decimal Preco { get; set; }
        public decimal Quantidade { get; set; }
    }
}