using GestaoTestes.Dominio.ModuloDisciplina;
using System;

namespace GestaoTestes.Dominio.ModuloMateria
{
    [Serializable]
    public class Materia : EntidadeBase<Materia>
    {
        public string NomeMateria { get; set; }
        public string Serie { get; set; }
        public Disciplina Disciplina { get; set; }

        public Materia()
        {
        }

        public override void Atualizar(Materia registro)
        {
            NomeMateria = registro.NomeMateria;
            Disciplina = registro.Disciplina;
            Serie = registro.Serie;
        }
    }
}
