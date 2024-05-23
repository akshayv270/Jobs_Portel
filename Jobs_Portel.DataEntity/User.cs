using System;
using System.Collections.Generic;

namespace Jobs_Portel.DataEntity
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? FullName { get; set; }
        public string UserType { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Employer? Employer { get; set; }
        public virtual JobSeeker? JobSeeker { get; set; }
    }
}
