using GestaoTestes.Dominio.ModuloDisciplina;
using GestaoTestes.Dominio.ModuloMateria;
using GestaoTestes.Dominio.ModuloQuestao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoTestes.Dominio.ModuloTeste
{
    
    public class Teste : EntidadeBase<Teste>
    {
        public string Titulo { get; set; }

        public DateTime DataCriacao { get; set; }

        public Disciplina Disciplina { get; set; }

        public Materia Materia { get; set; }

        public bool Recuperacao { get; set; }

        public int NumeroQuestoes { get; set; }

        public List<Questao> Questoes { get; set; }


        public Teste()
        {
            DataCriacao = DateTime.Now;
        }
        public Teste Clone()
        {

            var questoesCopiadas = new Questao[this.Questoes.Count];

            this.Questoes.CopyTo(questoesCopiadas);

            return new Teste
            {
                Titulo = this.Titulo,
                DataCriacao = this.DataCriacao,
                Disciplina = this.Disciplina,
                Materia = this.Materia,
                Recuperacao = this.Recuperacao,
                NumeroQuestoes = this.NumeroQuestoes,
                Questoes = questoesCopiadas.ToList()
            };
        }

        public override void Atualizar(Teste registro)
        {
            this.Titulo = registro.Titulo;
            this.Disciplina = registro.Disciplina;
            this.Materia = registro.Materia;
            this.NumeroQuestoes = registro.NumeroQuestoes;
            this.Recuperacao = registro.Recuperacao;
            this.Questoes = registro.Questoes;
        }
    }
}

