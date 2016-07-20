using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Template;

namespace Love.Net.Help {
    public class ApiHelpUIMiddleware {
        private readonly RequestDelegate _next;
        private readonly TemplateMatcher _requestMatcher;
        private readonly Assembly _resourceAssembly;

        public ApiHelpUIMiddleware(RequestDelegate next, string baseRoute) {
            _next = next;
            _requestMatcher = new TemplateMatcher(TemplateParser.Parse(baseRoute), new RouteValueDictionary());
            _resourceAssembly = GetType().GetTypeInfo().Assembly;
        }

        public async Task Invoke(HttpContext httpContext) {
            if (!RequestingApiHelpUI(httpContext.Request)) {
                await _next(httpContext);
                return;
            }

            var indexStream = _resourceAssembly.GetManifestResourceStream("Love.Net.Help.UI.dist.index.html");
            RespondWithContentHtml(httpContext.Response, indexStream);
        }

        private bool RequestingApiHelpUI(HttpRequest request) {
            if (request.Method != "GET")
                return false;

            return _requestMatcher.TryMatch(request.Path, new RouteValueDictionary());
        }
        
        private void RespondWithContentHtml(HttpResponse response, Stream content) {
            response.StatusCode = 200;
            response.ContentType = "text/html";
            content.CopyTo(response.Body);
        }
    }
}
