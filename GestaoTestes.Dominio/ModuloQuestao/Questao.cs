using GestaoTestes.Dominio.ModuloDisciplina;
using GestaoTestes.Dominio.ModuloMateria;
using System.Collections.Generic;
using System;

namespace GestaoTestes.Dominio.ModuloQuestao
{
    [Serializable]
    public class Questao : EntidadeBase<Questao>
    {
        public List<Alternativa> alternativas = new List<Alternativa>();        
        public Disciplina Disciplina { get; set; }
        public Materia Materia { get; set; }
        public string Enunciado { get; set; }   
        public List<Alternativa> Alternativas { get { return alternativas; } set { } }

        public Questao()
        {
        }
        
        public void AdicionarAlternativa(Alternativa alternativa)
        {
            alternativa.Questao = this;
            if (Alternativas.Exists(x => x.Equals(alternativa)) == false)
                alternativas.Add(alternativa);
        }

        public override void Atualizar(Questao registro)
        {
            this.Disciplina = registro.Disciplina;
            this.Materia = registro.Materia;
            this.Enunciado = registro.Enunciado;
            this.alternativas = registro.Alternativas;
        }
    }
}
