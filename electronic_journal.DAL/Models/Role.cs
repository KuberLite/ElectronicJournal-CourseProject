using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace electronic_journal.DAL.Models
{
    public class Role
    {
        [Key]
        public Guid RoleId { get; set; }

        public string RoleName { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}
