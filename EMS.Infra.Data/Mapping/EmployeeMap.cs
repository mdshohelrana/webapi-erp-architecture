using System;
using EMS.Core.Helpers;
using EMS.Domain.Hrm.Entities;
using FluentNHibernate.Mapping;

namespace EMS.Infra.Data.Mapping
{
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Schema(EnumSchema.HRM.Description());
            Table(typeof(Employee).Name);
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.LocationId);
            Map(x => x.SalutationId);
            Map(x => x.FirstName);
            Map(x => x.MiddleName);
            Map(x => x.LastName);
            Map(x => x.NickName);
            Map(x => x.EmpName);
        }
    }
}