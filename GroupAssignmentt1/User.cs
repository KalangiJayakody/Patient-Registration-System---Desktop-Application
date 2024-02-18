using System.ComponentModel.DataAnnotations;

namespace GroupAssignmentt1
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}