using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace electronic_journal.DAL.Models
{
    public class Progress
    {
        [Key]
        public Guid ProgressId { get; set; }

        public Guid SubjectId { get; set; }

        public Subject Subject { get; set; }

        public Guid PersonId { get; set; }

        public Person Person { get; set; }

        public int NoteFirst { get; set; }

        public int NoteSecond { get; set; }
    }
}
