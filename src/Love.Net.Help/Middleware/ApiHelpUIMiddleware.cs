using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Template;

namespace Love.Net.Help {
    public class ApiHelpUIMiddleware {
        private readonly RequestDelegate _next;
        private readonly TemplateMatcher _requestMatcher;
        private readonly IInedexPageStreamFactory _indexPageStreamFactory;

        public ApiHelpUIMiddleware(RequestDelegate next, IInedexPageStreamFactory indexPageStreamFactory, string baseRoute) {
            _next = next;
            _indexPageStreamFactory = indexPageStreamFactory;
            _requestMatcher = new TemplateMatcher(TemplateParser.Parse(baseRoute), new RouteValueDictionary());
        }

        public async Task Invoke(HttpContext httpContext) {
            if (!RequestingApiHelpUI(httpContext.Request)) {
                await _next(httpContext);
                return;
            }

            RespondWithContentHtml(httpContext.Response, _indexPageStreamFactory.Create());
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
