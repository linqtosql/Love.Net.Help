using System.Reflection;
using Love.Net.Help;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;

namespace Microsoft.AspNetCore.Builder {
    public static class ApiHelpUIBuilderExtensions {
        public static IApplicationBuilder UseApiHelpUI(this IApplicationBuilder app, string baseRoute = "api/help/ui") {
            baseRoute.Trim('/');
            var indexPath = baseRoute + "/index.html";

            // Enable redirect from base path ton index path.
            app.UseMiddleware<RedirectMiddleware>(baseRoute, indexPath);

            // Serve indexPath via middleware
            app.UseMiddleware<ApiHelpUIMiddleware>(indexPath);

            // Serve all other UI assets as static files
            var options = new FileServerOptions();
            options.RequestPath = "/" + baseRoute;
            options.EnableDefaultFiles = false;
            options.StaticFileOptions.ContentTypeProvider = new FileExtensionContentTypeProvider();

            // Debug view the embed files
            //var embedFiles = typeof(ApiHelpUIBuilderExtensions).GetTypeInfo().Assembly.GetManifestResourceNames();

            options.FileProvider = new EmbeddedFileProvider(typeof(ApiHelpUIBuilderExtensions).GetTypeInfo().Assembly, "Love.Net.Help.UI.dist");

            app.UseFileServer(options);

            return app;
        }
    }
}
