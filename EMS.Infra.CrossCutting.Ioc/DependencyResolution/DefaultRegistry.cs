// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EMS.Infra.CrossCutting.Ioc.DependencyResolution
{
    using Automapper;
    using AutoMapper;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using System;
    using System.Linq;
    public class DefaultRegistry : Registry
    {
        #region Constructors and Destructors

        public DefaultRegistry()
        {
            Scan(
                scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.Assembly("EMS.Core");
                    scan.Assembly("EMS.Infra.Data");
                    scan.Assembly("EMS.Infra.Repository");
                    scan.Assembly("EMS.Domain");
                    scan.Assembly("EMS.Domain.Services");
                    scan.Assembly("EMS.Application");
                });
            //For<IExample>().Use<Example>();

            #region Auto Mapper configurations

            var profiles = from t in typeof(AutoMapperRegistry).Assembly.GetTypes()
                           where typeof(Profile).IsAssignableFrom(t)
                           select (Profile)Activator.CreateInstance(t);

            var config = new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(profile);
                }
            });

            var mapper = config.CreateMapper();
            For<MapperConfiguration>().Use(config);
            For<IMapper>().Use(mapper);

            #endregion
        }

        #endregion
    }
}