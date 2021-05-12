using System;
using System.ComponentModel.DataAnnotations;

namespace KeremetTest.Data
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string SocialNumber { get; set; }
    }
}
