using System.ComponentModel.DataAnnotations;

namespace Travel.Application.Dtos.User
{
    /// <summary>
    /// The preceding block of code requires the login request to have Username and 
    /// Password properties or keys in the request body
    /// </summary>

    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}