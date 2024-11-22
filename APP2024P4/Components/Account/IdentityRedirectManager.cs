using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;

namespace APP2024P4.Components.Account
{
    internal sealed class IdentityRedirectManager
    {
        private readonly NavigationManager navigationManager;

        public const string StatusCookieName = "Identity.StatusMessage";

        private static readonly CookieBuilder StatusCookieBuilder = new()
        {
            SameSite = SameSiteMode.Strict,
            HttpOnly = true,
            IsEssential = true,
            MaxAge = TimeSpan.FromSeconds(5), // El mensaje de estado estar� disponible durante 5 segundos
        };

        public IdentityRedirectManager(NavigationManager navigationManager)
        {
            this.navigationManager = navigationManager;
        }

        /// <summary>
        /// Redirige a una URI espec�fica.
        /// </summary>
        [DoesNotReturn]
        public void RedirectTo(string? uri)
        {
            uri ??= "";

            if (!Uri.IsWellFormedUriString(uri, UriKind.Relative))
            {
                // Prevenir redirecciones abiertas
                uri = navigationManager.ToBaseRelativePath(uri);
            }

            navigationManager.NavigateTo(uri);

            // Excepci�n manejada para redirecci�n durante renderizado est�tico
            throw new InvalidOperationException($"{nameof(IdentityRedirectManager)} solo se puede usar durante el renderizado est�tico.");
        }

        /// <summary>
        /// Redirige a una URI con par�metros de consulta.
        /// </summary>
        [DoesNotReturn]
        public void RedirectTo(string uri, Dictionary<string, object?> queryParameters)
        {
            var uriWithoutQuery = navigationManager.ToAbsoluteUri(uri).GetLeftPart(UriPartial.Path);
            var newUri = navigationManager.GetUriWithQueryParameters(uriWithoutQuery, queryParameters);
            RedirectTo(newUri);
        }

        /// <summary>
        /// Redirige a una URI espec�fica con un mensaje de estado almacenado en cookies.
        /// </summary>
        [DoesNotReturn]
        public void RedirectToWithStatus(string uri, string message, HttpContext context)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException("El mensaje de estado no puede estar vac�o.", nameof(message));
            }

            context.Response.Cookies.Append(StatusCookieName, message, StatusCookieBuilder.Build(context));
            RedirectTo(uri);
        }

        /// <summary>
        /// Obtiene la ruta actual.
        /// </summary>
        private string CurrentPath => navigationManager.ToAbsoluteUri(navigationManager.Uri).GetLeftPart(UriPartial.Path);

        /// <summary>
        /// Redirige a la p�gina actual.
        /// </summary>
        [DoesNotReturn]
        public void RedirectToCurrentPage() => RedirectTo(CurrentPath);

        /// <summary>
        /// Redirige a la p�gina actual con un mensaje de estado.
        /// </summary>
        [DoesNotReturn]
        public void RedirectToCurrentPageWithStatus(string message, HttpContext context)
        {
            RedirectToWithStatus(CurrentPath, message, context);
        }
    }
}
