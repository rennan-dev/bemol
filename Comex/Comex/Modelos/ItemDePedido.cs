namespace Comex.Modelos; 
internal class ItemDePedido {
    public Produto produto { get; set; }
    public int Quantidade { get; set; }
    public double PrecoUnitario { get; set; }
    public double Subtotal {
        get {
            return Quantidade * PrecoUnitario;
        }
    }

    public override string ToString() {
        return $"\nProduto: {produto.Nome}\n" +
               $"Quantidade: {Quantidade}\n" +
               $"Preço Unitário: {PrecoUnitario}\n" +
               $"Subtotal: {Subtotal}\n";
    }
}
