using System;

namespace GestaoTestes.Dominio.ModuloQuestao
{
    [Serializable]
    public class Alternativa
    {

        public int Numero { get; set; }
        public string Descricao { get; set; }

        public bool AlternativaCorreta { get; private set; }
        public char Letra { get; set; }
        public Questao Questao { get; set; }

        public void MarcarAlternativaCorreta()
        {
            AlternativaCorreta = true;
        }
        public string VisualizarAlternativa 
        { 
            get 
            { 
                return Letra + ") " + Descricao + "- " + (AlternativaCorreta ? "Verdadeira" : "Falsa"); 
            }
        }
    }
}