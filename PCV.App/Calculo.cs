using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCV.App
{
    public class Calculo
    {

        public List<Percurso> MelhoresResultados { get; set; }
        public List<Percurso> PioresResultados { get; set; }

        private List<Percurso> percursos;
        public ETipoCalculo TipoCalculo { get; set; }
        public long Milisegundos { get; set; }
        public int QuantidadeCidades { get; set; }
        public int PercursosCalculados { get; set; }
        public int QuantidadeResultados { get; set; }
        public long CustoMemoria { get; set; }
        private long memoriaAntes;
        private long memoriaDepois;
        public int Codigo;
        public int Inicial { get; set; }
        public int Final { get; set; }

        public int PopulacaoInicial { get; set; }
        public int QuantidadeReproducoes { get; set; }
        private List<int> NumerosUtilizadosGenetico;
        private List<string> RotasUtilizadasGenetico;
        public List<int[]> GraficoGenetico { get; set; }


        public Calculo()
        {
            QuantidadeResultados = 1;
            percursos = new List<Percurso>();
        }

        public void Calcular()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            memoriaAntes = Process.GetCurrentProcess().WorkingSet64;
            
            Stopwatch stop = Stopwatch.StartNew();
            if (TipoCalculo == ETipoCalculo.ForcaBruta)
            {
                MontaPercursos();
                PercursosCalculados = percursos.Count;

                ColetaResultado();
            }

            if (TipoCalculo == ETipoCalculo.Vizinho)
            {
                CalculaVizinho();
                ColetaResultado();
            }

            if (TipoCalculo == ETipoCalculo.ForcaBrutaNovo)
            {
                CalculaForcaBruta();
            }

            if (TipoCalculo == ETipoCalculo.Genetico)
            {
                CalculaGenetico();
                ColetaResultado();
            }

            stop.Stop();
            CustoMemoria = (memoriaDepois - memoriaAntes);
            Milisegundos = stop.ElapsedMilliseconds;
            QuantidadeCidades = Help.cidades.Count;
        }

        public enum ETipoCalculo
        {
            ForcaBruta,
            Vizinho,
            ForcaBrutaNovo,
            Genetico
        }

        private void ColetaResultado()
        {
            if (TipoCalculo == ETipoCalculo.Vizinho)
                QuantidadeResultados = 1;


            MelhoresResultados = new List<Percurso>(percursos.OrderBy(o => o.distancia).Take(QuantidadeResultados).ToList());
            PioresResultados = new List<Percurso>(percursos.OrderByDescending(o => o.distancia).Take(QuantidadeResultados).ToList());
            memoriaDepois = Process.GetCurrentProcess().WorkingSet64;
            percursos = null;
            GC.Collect();
        }

        private void CalculaVizinho()
        {
            var totalCidades = Help.cidades.Count + 1;
            var per = new Percurso(totalCidades);

            per.AdicionaRotasArr(0);
            var cidadeAtual = 0;
            totalCidades--;

            do
            {
                var menorDistancia = int.MaxValue;
                //var maiorDistancia = int.MinValue;
                sbyte proxima = 0;
                for (sbyte i = 1; i < Help.cidades.Count; i++)
                {
                    var distancia = 0;
                    if (Help.tabelaDistancias.Contains(string.Format("{0}{1}", cidadeAtual, i)))
                    {
                        distancia = int.Parse(Help.tabelaDistancias[string.Format("{0}{1}", cidadeAtual, i)].ToString());
                    }
                    else if (Help.tabelaDistancias.Contains(string.Format("{0}{1}", i, cidadeAtual)))
                    {
                        distancia = int.Parse(Help.tabelaDistancias[string.Format("{0}{1}", i, cidadeAtual)].ToString());
                    }else
                    {
                        continue;
                    }
                    if ((distancia <= menorDistancia) && (!JaPassouArr(per.RotasArr(), i)))
                    {
                        menorDistancia = distancia;
                        proxima = i;
                    }
                }
                per.AdicionaRotasArr(proxima);
                totalCidades--;
            } while ((totalCidades-1) > 0);

            per.AdicionaRotasArr(0);
            percursos.Add(per);
        }

        private void MontaPercursos()
        {

            for (sbyte i = 1; i < Help.cidades.Count; i++)
            {
                for (sbyte j = 1; j < Help.cidades.Count; j++)
                {
                    if (i != j)
                    {
                        var ni = new Percurso(Help.cidades.Count + 1);
                        ni.AdicionaRotasArr(i);
                        ni.AdicionaRotasArr(j);
                        percursos.Add(ni);
                    }
                }
            }

            List<Percurso> nova = null;
            //- 3 = -1 ORIGEM - 2 PRIMEIRA COMBINACAO (ACIMA) 
            for (int i = 0; i < Help.cidades.Count - 3; i++)
            {
                nova = new List<Percurso>();
                foreach (var item in percursos)
                {
                    for (sbyte j = 1; j < Help.cidades.Count; j++)
                    {
                        if (!JaPassouArr(item.RotasArr(), j))
                        {
                            var per = new Percurso(Help.cidades.Count + 1);
                            per.AdicionaRotasArr(item.RotasArr());
                            per.AdicionaRotasArr(j);
                            nova.Add(per);
                        }
                    }
                }
                percursos.Clear();
                percursos.AddRange(nova);
            }

            foreach (var item in percursos)
            {
                item.InsereRotaArr(0);
                item.AdicionaRotasArr(0);
            }
            
        }

        private bool JaPassou(List<sbyte> a, sbyte b)
        {
            return (a.IndexOf(b) >= 0);
        }

        private bool JaPassouArr(sbyte[] a, sbyte b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == b)
                    return true;
            }
            return false;
        }


        private Percurso PercursoRandom()
        {
            var lista = new List<int>();
            Percurso retorno = null;
            var random = new Random();

            do
            {
                retorno = new Percurso(Help.cidades.Count + 1);
                lista.Clear();
                retorno.InsereRotaArr(0);

                for (int i = 1; i < Help.cidades.Count; i++)
                {
                    var posicao = -1;
                    do
                    {
                        posicao = random.Next(1, Help.cidades.Count);
                        if (lista.IndexOf(posicao) >= 0)
                            posicao = -1;
                        else
                        {
                            retorno.AdicionaRotasArr((sbyte)posicao);
                            lista.Add(posicao);
                        }

                    } while (posicao == -1);
                }
                retorno.AdicionaRotasArr(0);
            } while (RotasUtilizadasGenetico.IndexOf(retorno.MontaRotasNumArr()) >= 0);

            RotasUtilizadasGenetico.Add(retorno.MontaRotasNumArr());
            return retorno;
        }

        private void CalculaGenetico()
        {
            GraficoGenetico = new List<int[]>();

            //cromossomo (populacao inicial)
            RotasUtilizadasGenetico = new List<string>();
            do
            {
                percursos.Add(PercursoRandom());

            } while (percursos.Count < PopulacaoInicial);
            RotasUtilizadasGenetico = null;

            GraficoGenetico.Add(new int[] { percursos.OrderBy(o => o.distancia).Take(1).FirstOrDefault().distancia, 0});

            var listaUtilizados = new List<int>();
            var geracao =  new List<Percurso>();


            /*Reproducao*/
            for (int m = 0; m < QuantidadeReproducoes; m++)
            {
                for (int k = 0; k < (percursos.Count / 2); k++)
                {
                    var percursoTmp1 = percursos.ElementAt(k);
                    var percursoTmp2 = percursos.ElementAt((percursos.Count / 2) + k);

                    var tamanho = (decimal)percursoTmp1.RotasArr().Length;
                    var limite = int.Parse((Math.Ceiling((tamanho - 2) / 2)).ToString());

                    var filho1 = new sbyte[percursoTmp1.RotasArr().Length - 1];
                    var filho2 = new sbyte[percursoTmp1.RotasArr().Length - 1];

                    filho1[0] = 0;
                    filho2[0] = 0;

                    //reproduz o par
                    for (int i = 1; i < tamanho - 1; i++)
                    {
                        if (i <= limite)
                        {
                            filho1[i] = percursoTmp1.RotasArr().ElementAt(i);
                            filho2[i] = -1;
                        }
                        else
                        {
                            filho2[i] = percursoTmp1.RotasArr().ElementAt(i);
                            filho1[i] = -1;
                        }
                    }

                    for (int i = 1; i < tamanho - 1; i++)
                    {
                        if (i <= limite)
                        {
                            if (!JaPassouArr(filho2, percursoTmp2.RotasArr().ElementAt(i)))
                                filho2[i] = percursoTmp2.RotasArr().ElementAt(i);
                        }
                        else
                        {
                            if (!JaPassouArr(filho1, percursoTmp2.RotasArr().ElementAt(i)))
                                filho1[i] = percursoTmp2.RotasArr().ElementAt(i);
                        }
                    }

                    for (int i = 0; i < filho1.Length; i++)
                    {
                        if (filho1[i] == -1)
                        {
                            for (int j = 1; j < tamanho - 1; j++)
                            {
                                if (!JaPassouArr(filho1, (sbyte)j))
                                {
                                    filho1[i] = (sbyte)j;
                                    break;
                                }
                            }
                        }
                    }

                    for (int i = 0; i < filho2.Length; i++)
                    {
                        if (filho2[i] == -1)
                        {
                            for (int j = 1; j < tamanho - 1; j++)
                            {
                                if (!JaPassouArr(filho2, (sbyte)j))
                                {
                                    filho2[i] = (sbyte)j;
                                    break;
                                }
                            }
                        }
                    }

                    //mutacao
                    var random = new Random();
                    var randomMutacao = random.Next(1, filho1.Length - 1);
                    var randomMutacaoPar = -1;
                    do
                    {
                        randomMutacaoPar = random.Next(1, filho1.Length - 1);
                    } while (randomMutacao == randomMutacaoPar);
                    var randomQualFilho = random.Next(1, 2);

                    if (randomQualFilho == 1)
                    {    
                        var tmp = filho1[randomMutacaoPar];
                        filho1[randomMutacaoPar] = filho1[randomMutacao];
                        filho1[randomMutacao] = tmp;
                    }
                    else
                    {
                        var tmp = filho2[randomMutacaoPar];
                        filho2[randomMutacaoPar] = filho2[randomMutacao];
                        filho2[randomMutacao] = tmp;
                    }

                    var percursoFilho1 = new Percurso(Help.cidades.Count + 1);
                    var percursoFilho2 = new Percurso(Help.cidades.Count + 1);

                    percursoFilho1.AdicionaRotasArr(filho1);
                    percursoFilho2.AdicionaRotasArr(filho2);
                    percursoFilho1.AdicionaRotasArr(0);
                    percursoFilho2.AdicionaRotasArr(0);
                    
                    geracao.Add(percursoFilho1);
                    geracao.Add(percursoFilho2);
                }

                var grupo = geracao.GroupBy(g => g.MontaRotasNumArr()).ToList();

                foreach (var item in grupo)
                {
                    if (percursos.Where(w => w.MontaRotasNumArr().Equals(item.Key)).Count() == 0)
                        percursos.Add(geracao.Where(w => w.MontaRotasNumArr().Equals(item.Key)).FirstOrDefault());
                }
                //selecionar individuas para a nova reproducao
                percursos = new List<Percurso>(percursos.OrderBy(o => o.distancia).Take(PopulacaoInicial).ToList());

                GraficoGenetico.Add(new int[] { percursos.ElementAt(0).distancia, m+1});

                geracao.Clear();
            }
        }

        private Percurso PercursoAleatorio()
        {
            var fatorial = MathNet.Numerics.SpecialFunctions.Factorial(Help.cidades.Count - 1);
            var cidades = new sbyte[Help.cidades.Count - 1];
            var aux = 1;
            for (int i = 0; i < cidades.Length; i++)
            {
                cidades[i] = (sbyte)aux;
                aux++;
            }

            var random = -1;
            do
            {
                random = new Random().Next(1, int.Parse(fatorial.ToString()));
            } while (NumerosUtilizadosGenetico.IndexOf(random) >= 0);

            NumerosUtilizadosGenetico.Add(random);

            var varAuxilio = 0;

            var percurso = new Percurso(Help.cidades.Count + 1);

            var comb = new sbyte[cidades.Length];

            var disponiveis = cidades;
            var repanterior = int.Parse(fatorial.ToString());

            //niveis
            for (int j = 0; j < cidades.Length; j++)
            {
                decimal rep = repanterior / (cidades.Length - j);

                var modPosicao = random % repanterior;

                if (modPosicao == 0)
                {
                    modPosicao = random;
                    while (modPosicao > repanterior)
                    {
                        modPosicao -= int.Parse(repanterior.ToString());
                    }
                }

                repanterior = int.Parse(rep.ToString());

                if ((rep == 1) && (j == (cidades.Length - 2)))
                {
                    modPosicao = varAuxilio;
                    varAuxilio++;
                    if (varAuxilio > 1)
                        varAuxilio = 0;

                    comb[j] = disponiveis[modPosicao];
                }
                else
                {

                    if (TotalDisponivel(ref disponiveis) == 1)
                        comb[j] = disponiveis[0];
                    else
                        comb[j] = disponiveis[decimal.ToInt16(Math.Ceiling(modPosicao / rep)) - 1];
                }

                AtualizaDisponiveis(ref disponiveis, comb[j]);
            }

            percurso.AdicionaRotasArr(comb);
            percurso.InsereRotaArr(0);
            percurso.AdicionaRotasArr(0);
            return percurso;
        }


        private void CalculaForcaBruta()
        {
            MelhoresResultados = new List<Percurso>();

            var fatorial = MathNet.Numerics.SpecialFunctions.Factorial(Help.cidades.Count - 1);
            var cidades = new sbyte[Help.cidades.Count - 1];
            var aux = 1;
            for (int i = 0; i < cidades.Length; i++)
            {
                cidades[i] = (sbyte)aux;
                aux++;
            }

            var menorDistancia = int.MaxValue;

            if (Inicial == 0)
                Inicial = 1;
            if (Final == 0)
                Final = int.Parse(fatorial.ToString());

            var varAuxilio = 0;

            for (int i = Inicial; i <= Final; i++)
            {
                var percurso = new Percurso(Help.cidades.Count + 1);

                var comb = new sbyte[cidades.Length];

                var disponiveis = cidades;
                var repanterior = int.Parse(fatorial.ToString());

                //niveis
                for (int j = 0; j < cidades.Length; j++)
                {
                    decimal rep = repanterior / (cidades.Length - j);

                    var modPosicao = i % repanterior;

                    if (modPosicao == 0)
                    {
                        modPosicao = i;
                        while (modPosicao > repanterior)
                        {
                            modPosicao -= int.Parse(repanterior.ToString());
                        }
                    }

                    repanterior = int.Parse(rep.ToString());

                    if ((rep == 1) && (j == (cidades.Length - 2)))
                    {
                        modPosicao = varAuxilio;
                        varAuxilio++;
                        if (varAuxilio > 1)
                            varAuxilio = 0;

                        comb[j] = disponiveis[modPosicao];
                    }
                    else
                    {

                        if (TotalDisponivel(ref disponiveis) == 1)
                            comb[j] = disponiveis[0];
                        else
                            comb[j] = disponiveis[decimal.ToInt16(Math.Ceiling(modPosicao / rep)) - 1];
                    }

                    AtualizaDisponiveis(ref disponiveis, comb[j]);
                }

                percurso.AdicionaRotasArr(comb);
                percurso.InsereRotaArr(0);
                percurso.AdicionaRotasArr(0);

                if (percurso.distancia < menorDistancia)
                {
                    menorDistancia = percurso.distancia;

                    if (MelhoresResultados.Count() >= QuantidadeResultados)
                        MelhoresResultados.Remove(MelhoresResultados.ElementAt(QuantidadeResultados - 1));

                    MelhoresResultados.Insert(0, percurso);                        
                }
                percurso = null;
            }

        }

        public int TotalDisponivel(ref sbyte[] lista)
        {
            var total = 0;
            for (int i = 0; i < lista.Length; i++)
            {
                if (lista[i] > -1)
                    total++;
            }
            return total;
        }

        public void AtualizaDisponiveis(ref sbyte[] lista, int tirar)
        {
            var nova = new sbyte[lista.Length];
            for (int i = 0; i < nova.Length; i++)
            {
                nova[i] = -1;
            }

            var aux = 0;
            for (int i = 0; i < lista.Length; i++)
            {
                if (!(lista[i] == tirar))
                {
                    nova[aux] = lista[i];
                    aux++;
                }
            }

            lista = nova;
        }
    }

}
