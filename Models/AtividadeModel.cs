using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanban.Models
{
    public class AtividadeModel
    {
        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }

        // get current date and time
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        // it needs to have the columnds StatusId and Status (based on Entity Framework conventions)
        public int StatusId { get; set; }
        public StatusModel Status { get; set; }
        
    }
}