using System;
using System.Web;
using System.Web.Routing;
using FubuMVC.Core;
using FubuMVC.StructureMap;
using StructureMap;

namespace Fubu1
{
    public class Global : HttpApplication
    {
        IContainer _container;

        protected void Application_Start(object sender, EventArgs e)
        {
            _container = new Container();

            FubuApplication.For<ConfigureFubuMvc>() 
                           .StructureMap(_container)
                           .Bootstrap(RouteTable.Routes);
        }

        protected void Application_BeginRequest(object sender, EventArgs e) {}
        protected void Application_AuthenticateRequest(object sender, EventArgs e) {}
        protected void Application_Error(object sender, EventArgs e) {}
        protected void Application_End(object sender, EventArgs e) {}
    }
}