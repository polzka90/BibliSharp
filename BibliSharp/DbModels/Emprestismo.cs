﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliSharp.DbModels
{
    public class Emprestismo
    {
        public int AlunoId { get; set; }
        public int LivroId { get; set; }
        public DateTime DataRetirada { get; set; }
        public string CriadoPor { get; set; }
        public DateTime DataLimite{ get; set; }
        public DateTime DataEntrega { get; set; }
        public string AlteradoPor { get; set; }
    }
}
