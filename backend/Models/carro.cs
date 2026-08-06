namespace backend.Models
{
    public class Carro : Veiculo
    {
        public Carro()
        {
            quantidadeRodas = 4;
        }
        public int quantidadeRodas { get; set; }

        public override void Acelerar()
        {
            InjetarCombustivel(4);
        }
        
        private void InjetarCombustivel(int quantidadeCombustivel)
        {
            base.TanqueCombustivel -= quantidadeCombustivel;
        }
    }
}