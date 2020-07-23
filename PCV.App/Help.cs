using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCV.App
{
    public static class Help
    {

        public static Hashtable tabelaDistancias = new Hashtable();
        public static List<Cidade> cidades;

        public static string Memoria(long memoria)
        {
            if ((memoria / (1024L)) > 1024)
            {
                return string.Format("{0} MB", ((memoria) / (1024L * 1024L)).ToString());
            }
            else
            {
                return string.Format("{0} KB", ((memoria) / (1024L)).ToString());
            }
        }

        public static string Descricao(this Calculo.ETipoCalculo valor)
        {
            switch (valor)
            {
                case Calculo.ETipoCalculo.ForcaBruta:
                    return "Força-bruta";
                case Calculo.ETipoCalculo.Vizinho:
                    return "Vizinho mais próximo";
                case Calculo.ETipoCalculo.ForcaBrutaNovo:
                    return "Novo Força-bruta";
                case Calculo.ETipoCalculo.Genetico:
                    return "Genético";
                default:
                    break;
            }
            return string.Empty;
        }

        public static void CopiarPara(this sbyte[] origem, ref sbyte[] destino, int inicial,int final)
        {
            var aux = final + 1;
            for (int i = inicial; i <= final; i++)
            {
                destino[aux] = origem[i];
                aux++;
            }
        }
    }
}
