using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace electronic_journal.DAL.Models
{
    public class Faculty
    {
        [Key]
        public Guid FacultyId { get; set; }

        public string FacultyName { get; set; }

        public List<Profession> Professions { get; set; }

        public List<Group> Groups { get; set; }

        public List<Pulpit> Pulpits { get; set; }
    }
}
