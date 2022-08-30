namespace TorneioWebApplication.Models
{
    public class Competidor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public int ArtesMarciais { get; set; }
        public int TotalLutas { get; set; }
        public int Vitorias { get; set; }
        public int Derrotas { get; set; }
        public int? PorcentagemVitorias { get; set; }

        public Competidor()
        {

        }
        public Competidor(Competidor competidor)
        {
            double media = (double)competidor.Vitorias / (double)competidor.TotalLutas * 100;
            this.PorcentagemVitorias = (int)media;
            this.Id = competidor.Id;
            this.Nome = competidor.Nome;
            this.Idade = competidor.Idade;
            this.ArtesMarciais = competidor.ArtesMarciais;
            this.TotalLutas = competidor.TotalLutas;
            this.Vitorias = competidor.Vitorias;
            this.Derrotas = competidor.Derrotas;

        }
    }
}
