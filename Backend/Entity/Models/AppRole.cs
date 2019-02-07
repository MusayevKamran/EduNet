using Microsoft.AspNetCore.Identity;
using System;

namespace EntityData.Models
{
    public class AppRole : IdentityRole<Guid>
    {
        public AppRole() : base() { }
        public AppRole(string roleName) : base() { }
        public AppRole(string roleName, string description, DateTime creationDate) : base(roleName)
        {
            Description = description;
            CreationDate = creationDate;
        }

        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
