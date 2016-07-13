// Copyright (c) rigofunc (xuyingting). All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace Love.Net.Help {
    internal static class ApiDescriptionExtensions {
        internal static IEnumerable<string> SupportedRequestMediaTypes(this ApiDescription apiDescription) {
            return apiDescription.SupportedRequestFormats
                .Select(requestFormat => requestFormat.MediaType);
        }

        internal static IEnumerable<string> SupportedResponseMediaTypes(this ApiDescription apiDescription) {
            return apiDescription.SupportedResponseTypes
                .SelectMany(responseType => responseType.ApiResponseFormats)
                .Select(responseFormat => responseFormat.MediaType)
                .Distinct();
        }

        internal static IEnumerable<Attribute> GetActionAttributes(this ApiDescription apiDescription) {
            var actionDescriptor = apiDescription.ActionDescriptor as ControllerActionDescriptor;
            return (actionDescriptor != null)
                ? actionDescriptor.MethodInfo.GetCustomAttributes(false)
                : Enumerable.Empty<Attribute>();
        }

        internal static bool IsObsolete(this ApiDescription apiDescription) {
            return apiDescription.GetActionAttributes().OfType<ObsoleteAttribute>().Any();
        }
    }
}
