using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace electronic_journal.DAL.Models
{
    public class Pulpit
    {
        [Key]
        public Guid PulpitId { get; set; } 

        public string PulpitName { get; set; }

        public Guid FacultyId { get; set; }

        public Faculty Faculty { get; set; }

        public List<Subject> Subjects { get; set; }

        public List<Person> People { get; set; }
    }
}
