using GestaoTestes.Dominio.ModuloMateria;
using System;
using System.Collections.Generic;

namespace GestaoTestes.Dominio.ModuloDisciplina
{
    [Serializable]
    public class Disciplina : EntidadeBase<Disciplina>
    {
        public Disciplina()
        {
        }

        public string NomeDisciplina { get; set; }
        
        public override void Atualizar(Disciplina registro)
        {
            this.NomeDisciplina = registro.NomeDisciplina;
        }
    }
}
