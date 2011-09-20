using Fubu1.App.Home;
using Fubu1.Core;
using FubuMVC.Core;
using FubuMVC.Spark;

namespace Fubu1
{
    public class ConfigureFubuMvc : FubuRegistry
    {
        public ConfigureFubuMvc()
        {
            Applies.ToThisAssembly();

            // This line turns on the basic diagnostics and request tracing
            IncludeDiagnostics(true);

            // All public methods from concrete classes ending in "Controller"
            // in this assembly are assumed to be action methods
            Actions.IncludeClassesSuffixedWithController();

            // Policies
            Routes
                .HomeIs<HomeController>()
                .IgnoreControllerNamespaceEntirely()
                .RootAtAssemblyNamespace();

            // Match views to action methods by matching
            // on model type, view name, and namespace
            Views.TryToAttachWithDefaultConventions();

            this.UseSpark();

            Output.ToJson.WhenCallMatches(action => action.Returns<AjaxResponse>());
        }
    }
}