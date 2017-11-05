using Autofac;
using PocketClone.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketClone.Config
{
    public class AppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var algoliaApp = ConfigurationManager.AppSettings[AppConfigConstants.AlgoliaAppId];
            var algoliaKey = ConfigurationManager.AppSettings[AppConfigConstants.AlgoliaAuthKey];
            var algoliaIndex = ConfigurationManager.AppSettings[AppConfigConstants.AlgoliaIndex];

            var searchService = new AlgoliaSearchService(algoliaApp, algoliaKey, algoliaIndex);
            builder.RegisterInstance(searchService).As<ISearchService>().SingleInstance();
        }
    }
}
