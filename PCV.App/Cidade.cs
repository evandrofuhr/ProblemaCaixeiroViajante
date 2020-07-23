using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCV.App
{
    public class Cidade
    {
        public string Nome { get; set; }
        public List<Cidade> cidades { get; set; }
        public int Distancia { get; set; }
        public int Posicao { get; set; }

        public Cidade(string nome,int posicao)
        {
            this.Nome = nome;
            this.Posicao = posicao;
            cidades = new List<Cidade>();
        }
    }
}
