using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliSharp.DbModels
{
    public class Livro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Editora { get; set; }
        public string Autora { get; set; }
        public int Ano { get; set; }
    }
}
