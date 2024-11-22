using APP2024P4.Data;
using Microsoft.AspNetCore.Identity;

namespace APP2024P4.Components.Account
{
    /// <summary>
    /// Proporciona acceso al usuario autenticado y redirige si el usuario no está disponible.
    /// </summary>
    internal sealed class IdentityUserAccessor
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IdentityRedirectManager redirectManager;

        public IdentityUserAccessor(UserManager<ApplicationUser> userManager, IdentityRedirectManager redirectManager)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.redirectManager = redirectManager ?? throw new ArgumentNullException(nameof(redirectManager));
        }

        /// <summary>
        /// Obtiene el usuario autenticado del contexto HTTP. Redirige a una página de error si no se encuentra el usuario.
        /// </summary>
        /// <param name="context">El contexto HTTP actual.</param>
        /// <returns>El usuario autenticado.</returns>
        /// <exception cref="InvalidOperationException">Si el contexto o el usuario es nulo.</exception>
        public async Task<ApplicationUser> GetRequiredUserAsync(HttpContext context)
        {
            if (context is null || context.User is null)
            {
                throw new InvalidOperationException("El contexto HTTP o el usuario es nulo.");
            }

            var user = await userManager.GetUserAsync(context.User);

            if (user is null)
            {
                var userId = userManager.GetUserId(context.User) ?? "desconocido";
                var errorMessage = $"Error: No se pudo cargar el usuario con ID '{userId}'.";

                redirectManager.RedirectToWithStatus("Account/InvalidUser", errorMessage, context);
            }

            return user!;
        }
    }
}
