// Copyright (c) rigofunc (xuyingting). All rights reserved.

using System;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Love.Net.Help {
    /// <summary>
    /// Allows customization of the of the Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel
    /// </summary>
    public class ApiHelpApplicationConvention : IApplicationModelConvention {
        /// <summary>
        /// Called to apply the convention to the <see cref="ApplicationModel" />.
        /// </summary>
        /// <param name="application">The <see cref="ApplicationModel" />.</param>
        public void Apply(ApplicationModel application) {
            application.ApiExplorer.IsVisible = true;
            foreach (var controller in application.Controllers) {
                if(controller.ControllerName.Equals("Help", StringComparison.OrdinalIgnoreCase)) {
                    controller.ApiExplorer.IsVisible = false;
                    continue;
                }

                controller.ApiExplorer.GroupName = controller.ControllerName;
            }
        }
    }
}
