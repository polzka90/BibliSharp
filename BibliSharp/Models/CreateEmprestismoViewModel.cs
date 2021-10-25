using BibliSharp.DbModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BibliSharp.Models
{
    public class CreateEmprestismoViewModel
    {
        public List<SelectListItem> Alunos { get; set; }
        public List<SelectListItem> Livros { get; set; }

        public string Aluno { get; set; }
        public string Livro { get; set; }

        public Emprestismo Emprestismo { get; set; }
    }
}
