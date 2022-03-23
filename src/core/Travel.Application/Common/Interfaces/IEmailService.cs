using System.Threading.Tasks;
using Travel.Application.Dtos.Email;

/// <summary>
/// The following code is a contract of the EmailService.
/// </summary>
namespace Travel.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailDto emailRequest);
    }
}