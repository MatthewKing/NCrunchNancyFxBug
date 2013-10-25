namespace NCrunchNancyFxBug
{
    using System;
    using System.IO;
    using Nancy.ViewEngines;

    // I'm implementing IViewResolver rather than using actual views so that we can be sure that both views
    // are provided, and have the exact same contents.

    public class ExampleViewResolver : IViewResolver
    {
        public ViewLocationResult GetViewLocation(string viewName, dynamic model, ViewLocationContext viewLocationContext)
        {
            const string contents = "<html><head><title>@Model.Title</title></head><body>@Model.Message</body></html>";

            if (viewName == "SuperSimpleView")
                return new ViewLocationResult(String.Empty, viewName, "sshtml", () => new StringReader(contents));

            if (viewName == "RazorView")
                return new ViewLocationResult(String.Empty, viewName, "cshtml", () => new StringReader(contents));

            return null;
        }
    }
}
