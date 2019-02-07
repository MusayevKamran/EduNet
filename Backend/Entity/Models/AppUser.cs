using System.Collections.Generic;

namespace EntityData.Models
{
    public class AppUser
    {
        public int Id { get; set; }

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
