using System.ComponentModel.DataAnnotations;

namespace MyTracker.Models.AppModels
{
    public class Login
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
