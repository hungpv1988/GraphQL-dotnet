using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.StarWars.Types
{
    public class EPiServerManType : ObjectGraphType<EPiServerMan>
    {
        public EPiServerManType(StarWarsData data)
        {
            Name = "EPiServerMan";
            Description = "Super man in this world";
            Field(x => x.Id);
            Field(x => x.EmployeeId);
            Field(x => x.Name);
            Field(x => x.EpiServerCode);
            Field(x => x.Department);
           // Field<EnumerationGraphType<string>> ("AddonsRelated", resolve: context => data.GetAddonRelated(context.Source));
        }
    }
}
