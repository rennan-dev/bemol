namespace Comex.Modelos;
internal class Eletronico : Produto {
    public int Voltagem { get; set; }
    public int Potencia { get; set; }
    public Eletronico(string nome) : base(nome) {
    }

    public override string ToString() {
        return base.ToString() +
               $"Especificação do Eletrônico:\n" +
               $"\tVoltagem: {Voltagem}W\n" +
               $"\tPotência: {Potencia}\n\n";
    }
}
