using APP2024P4.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;

namespace APP2024P4.Components.Account;

/// <summary>
/// Este servicio no envía correos reales. Se utiliza solo para pruebas y desarrollo local.
/// Implementar un servicio real antes de desplegar en producción.
/// </summary>
[Obsolete("Implementa un servicio real de envío de correos para producción.")]
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
        logger.LogInformation("Enviando correo de confirmación a {Email} con enlace: {Link}", email, confirmationLink);
        return emailSender.SendEmailAsync(email, "Confirma tu correo",
            $"Por favor, confirma tu cuenta haciendo clic en este enlace: <a href='{confirmationLink}'>Confirmar cuenta</a>.");
    }

    public Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink)
    {
        logger.LogInformation("Enviando correo de restablecimiento de contraseña a {Email} con enlace: {Link}", email, resetLink);
        return emailSender.SendEmailAsync(email, "Restablece tu contraseña",
            $"Por favor, restablece tu contraseña haciendo clic en este enlace: <a href='{resetLink}'>Restablecer contraseña</a>.");
    }

    public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode)
    {
        logger.LogInformation("Enviando código de restablecimiento de contraseña a {Email} con código: {Code}", email, resetCode);
        return emailSender.SendEmailAsync(email, "Código de restablecimiento de contraseña",
            $"Por favor, utiliza el siguiente código para restablecer tu contraseña: {resetCode}");
    }
}
