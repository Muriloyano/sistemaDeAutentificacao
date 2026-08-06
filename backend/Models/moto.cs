namespace backend.Models
{
    public class Moto : Veiculo
    {
        public Moto()
        {
            quantidadeRodas = 2;
        }
        public int quantidadeRodas { get; set; }

        public override void Acelerar()
        {
            InjetarCombustivel(1);
        }

        private void InjetarCombustivel(int quantidadeCombustivel)
        {
            base.TanqueCombustivel -= quantidadeCombustivel;
        }

    }
}