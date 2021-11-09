using BibliSharp.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliSharp.Models
{
    public class DetailsEmprestismoViewModel
    {
        public string Aluno { get; set; }
        public string Livro { get; set; }
        public Emprestismo Emprestismo { get; set; }
    }
}
