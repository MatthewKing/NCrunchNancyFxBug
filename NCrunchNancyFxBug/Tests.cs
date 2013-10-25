namespace NCrunchNancyFxBug
{
    using Nancy;
    using Nancy.Testing;
    using Xunit;

    public class Tests
    {
        [Fact]
        public void SuperSimpleViewEngine()
        {
            var bootstrapper = new ConfigurableBootstrapper(config =>
            {
                config.Module<ExampleModule>();
                config.ViewResolver(new MyViewResolver());
            });

            var browser = new Browser(bootstrapper);

            var result = browser.Get("/SuperSimpleViewEngine", c => c.HttpRequest());

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            result.Body["title"].ShouldExistOnce().And.ShouldContain("SuperSimple title");
            result.Body["body"].ShouldExistOnce().And.ShouldContain("SuperSimple message");
        }

        [Fact]
        public void RazorViewEngine()
        {
            var bootstrapper = new ConfigurableBootstrapper(config =>
            {
                config.Module<ExampleModule>();
                config.ViewResolver(new MyViewResolver());
            });

            var browser = new Browser(bootstrapper);

            var result = browser.Get("/RazorViewEngine", c => c.HttpRequest());

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            result.Body["title"].ShouldExistOnce().And.ShouldContain("Razor title");
            result.Body["body"].ShouldExistOnce().And.ShouldContain("Razor message");
        }
    }
}
