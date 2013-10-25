namespace NCrunchNancyFxBug
{
    using Nancy;

    // Two routes, one for each view engine. All they do is return their respective views.

    public class ExampleModule : NancyModule
    {
        public ExampleModule()
        {
            Get["/SuperSimpleViewEngine"] = context =>
            {
                ExampleModel model = new ExampleModel();
                model.Title = "SuperSimple title";
                model.Message = "SuperSimple message";

                return View["SuperSimpleView", model];
            };

            Get["/RazorViewEngine"] = context =>
            {
                ExampleModel model = new ExampleModel();
                model.Title = "Razor title";
                model.Message = "Razor message";

                return View["RazorView", model];
            };
        }
    }
}
