using APP2024P4.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;

namespace APP2024P4.Components.Account;

/// <summary>
/// Este servicio no env�a correos reales. Se utiliza solo para pruebas y desarrollo local.
/// Implementar un servicio real antes de desplegar en producci�n.
/// </summary>
[Obsolete("Implementa un servicio real de env�o de correos para producci�n.")]
internal sealed class IdentityNoOpEmailSender : IEmailSender<ApplicationUser>
{
    private readonly IEmailSender emailSender = new NoOpEmailSender();
    private readonly ILogger<IdentityNoOpEmailSender> logger;

    public IdentityNoOpEmailSender(ILogger<IdentityNoOpEmailSender> logger)
    {
        this.logger = logger;
    }

    public Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink)
    {
        logger.LogInformation("Enviando correo de confirmaci�n a {Email} con enlace: {Link}", email, confirmationLink);
        return emailSender.SendEmailAsync(email, "Confirma tu correo",
            $"Por favor, confirma tu cuenta haciendo clic en este enlace: <a href='{confirmationLink}'>Confirmar cuenta</a>.");
    }

    public Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink)
    {
        logger.LogInformation("Enviando correo de restablecimiento de contrase�a a {Email} con enlace: {Link}", email, resetLink);
        return emailSender.SendEmailAsync(email, "Restablece tu contrase�a",
            $"Por favor, restablece tu contrase�a haciendo clic en este enlace: <a href='{resetLink}'>Restablecer contrase�a</a>.");
    }

    public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode)
    {
        logger.LogInformation("Enviando c�digo de restablecimiento de contrase�a a {Email} con c�digo: {Code}", email, resetCode);
        return emailSender.SendEmailAsync(email, "C�digo de restablecimiento de contrase�a",
            $"Por favor, utiliza el siguiente c�digo para restablecer tu contrase�a: {resetCode}");
    }
}
