using EMS.Services.Core.ActionFilters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace EMS.Services.Core.Config
{
    public static class GlobalCustomizeConfig
    {
        public static void CustomizeConfig(HttpConfiguration config)
        {
            // Return request in JSON format
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            // Remove Xml formatters. This means when we visit an endpoint from a browser,
            // Instead of returning Xml, it will return Json.
            // More information from Dave Ward: http://jpapa.me/P4vdx6
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Configure json camelCasing per the following post: http://jpapa.me/NqC2HH
            // Here we configure it to write JSON property names with camel casing
            // without changing our server-side data model:
            var json = config.Formatters.JsonFormatter;

            // Handle cyclical references for json
            json.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            //json.UseDataContractJsonSerializer = false;
            var settings = json.SerializerSettings;

#if DEBUG
            // Pretty json for developers.
            settings.Formatting = Formatting.Indented;
#else
            settings.Formatting = Formatting.None;
#endif
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();


            //set date time for local date
            settings.DateTimeZoneHandling = DateTimeZoneHandling.Local;

            // Add model validation, globally
            config.Filters.Add(new ValidationActionFilter());
        }
    }
}