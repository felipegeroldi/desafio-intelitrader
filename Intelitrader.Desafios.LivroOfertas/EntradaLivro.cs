namespace Intellitrader.Desafios.LivroOfertas;

internal class EntradaLivro {
    public int Codigo { get; set; }
    public double Valor { get; set; }
    public int Quantidade { get; set; }
    public EntradaLivro? Anterior { get; set; } = null;
    public EntradaLivro? Proximo { get;set; } = null;
}