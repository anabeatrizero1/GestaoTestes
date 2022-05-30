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
        public Disciplina Disciplina { get; set; }
        public Materia Materia { get; set; }

        public List<Questao> Questoes { get; set; }

        public DateTime DataCriacao { get;  }

        public Teste()
        {
            DataCriacao = DateTime.Now;
        }

        public override void Atualizar(Teste registro)
        {
            this.Titulo = registro.Titulo;
            this.Disciplina = registro.Disciplina;
            this.Materia = registro.Materia;          
        }
    }
}

