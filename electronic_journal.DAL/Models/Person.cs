using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace electronic_journal.DAL.Models
{
    public class Person
    {
        [Key]
        [ForeignKey("User")]
        public Guid PersonId { get; set; }

        public virtual User User { get; set; }

        public string PersonName { get; set; }

        public string Gender { get; set; }

        public Guid PulpitId { get; set; }

        public Pulpit Pulpit { get; set;}

        public Guid GroupId { get; set; }

        public Group Group { get; set; }

        public DateTime Birthday { get; set; }

        [Column(TypeName="image")]
        public byte[] Photo { get; set; }

        public List<Progress> Progresses { get; set; }
    }
}
