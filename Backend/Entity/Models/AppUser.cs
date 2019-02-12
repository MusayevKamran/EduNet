using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace AppEntity.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        public AppUser() : base() { }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string Image { get; set; }

        public string URL { get; set; }

        public string Education { get; set; }

        public string Job { get; set; }

        public string About { get; set; }

        public string Quote { get; set; }

        public int Like { get; set; }

        public int Follower { get; set; }

        public int View { get; set; }

        public virtual ICollection<Article> Article { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }
    }
}
