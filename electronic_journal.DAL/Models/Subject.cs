using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace electronic_journal.DAL.Models
{
    public class Subject
    {
        [Key]
        public Guid SubjectId { get; set; }

        public string SubjectName { get; set; }

        public Guid PulpitId { get; set; }

        public Pulpit Pulpit { get; set; }

        public List<Progress> Progresses { get; set; }
    }
}
