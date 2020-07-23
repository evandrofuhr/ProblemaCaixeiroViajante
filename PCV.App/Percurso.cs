using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCV.App
{
    public class Percurso
    {
        private sbyte[] arr_rotas;
        public int distancia;
        public int registros;

        public Percurso(int totalCidades)
        {
            arr_rotas = new sbyte[totalCidades];
            for (int i = 0; i < arr_rotas.Length; i++)
            {
                arr_rotas[i] = -1;
            }
            registros = 0;
            distancia = 0;
        }

        public void AdicionaRotasArr(sbyte[] rotas)
        {
            foreach (var item in rotas)
            {
                if (item >= 0)
                {
                    arr_rotas[registros] = item;
                    registros++;
                }
            }
        }

        public void AdicionaRotasArr(sbyte rota)
        {
            if (rota >= 0)
            {
                arr_rotas[registros] = rota;
                registros++;
                if ((registros > 1) && (arr_rotas[0] == rota))
                {
                    CalculaDistanciaArr();
                }
            }
        }

        public sbyte[] RotasArr()
        {
            return arr_rotas;
        }

        public void InsereRotaArr(sbyte rota)
        {
            var chupaJU = new sbyte[arr_rotas.Length];
            chupaJU[0] = rota;

            for (sbyte i = 1; i < arr_rotas.Length; i++)
            {
                chupaJU[i] = arr_rotas[i-1];
            }
            arr_rotas = chupaJU;
            registros++;
        }

        private void CalculaDistanciaArr()
        {
            distancia = 0;
            for (int i = 0; i < arr_rotas.Length - 1; i++)
            {
                if (Help.tabelaDistancias.Contains(string.Format("{0}{1}", arr_rotas[i], arr_rotas[i + 1])))
                    distancia += int.Parse(Help.tabelaDistancias[string.Format("{0}{1}", arr_rotas[i], arr_rotas[i + 1])].ToString());
            }
        }
        
        public string MontaRotasArr()
        {
            var retorno = new List<string>();
            for (int i = 0; i < arr_rotas.Length; i++)
            {
                retorno.Add(Help.cidades.Where(w => w.Posicao.ToString().Equals(arr_rotas[i].ToString())).Select(s=>s.Nome).First());
            }
            return string.Join(" -> ", retorno.ToArray());
        }

        public string MontaRotasNumArr()
        {
            return string.Join("|", arr_rotas);
        }

    }

}
