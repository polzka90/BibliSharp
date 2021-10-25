using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliSharp.DbModels
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Sala { get; set; }
        public string Periodo { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCreacao { get; set; }
        public string CriadoPor { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string AlteradoPor { get; set; }
    }
}
