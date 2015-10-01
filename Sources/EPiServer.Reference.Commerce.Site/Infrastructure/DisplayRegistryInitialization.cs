using System;
using System.Linq;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using System.Web.Mvc;

namespace EPiServer.Reference.Commerce.Site.Infrastructure
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class DisplayRegistryInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            if (context.HostType == HostType.WebApplication)
            {
                // Register Display Options
                var options = ServiceLocator.Current.GetInstance<DisplayOptions>();
                options
                    .Add("full", "/displayoptions/full", Global.ContentAreaTags.Full, "", "epi-icon__layout--full")
                    .Add("wide", "/displayoptions/wide", Global.ContentAreaTags.Wide, "", "epi-icon__layout--two-thirds")
                    .Add("narrow", "/displayoptions/narrow", Global.ContentAreaTags.Narrow, "", "epi-icon__layout--one-third");

            }
        }

        public void Preload(string[] parameters) { }

        public void Uninitialize(InitializationEngine context)
        {
            //Add uninitialization logic
        }
    }
}