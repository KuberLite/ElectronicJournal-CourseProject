using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace electronic_journal.DAL.Models
{
    public class Group
    {
        [Key]
        public Guid GroupId { get; set; }

        public int Course { get; set; }

        public int NumberGroup { get; set; }

        public Guid FacultyId { get; set; }

        public Faculty Faculty { get; set; }

        public Guid ProfessionId { get; set; }

        public Profession Profession { get; set; }

        public List<Person> People { get; set; }
    }
}
