using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace electronic_journal.DAL.Models
{
    public class Profession
    {
        [Key]
        public Guid ProfessionId { get; set; }

        public Guid FacultyId { get; set; }

        public Faculty Faculty { get; set; }

        public string ProfessionName { get; set; }

        public string Qualification { get; set; }

        public List<Group> Groups { get; set; }
    }
}
