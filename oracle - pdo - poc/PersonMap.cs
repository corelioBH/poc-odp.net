using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace oracle___pdo___poc
{
    class PersonMap : ClassMap<PEOPLE>
    {
        public PersonMap()

        {

            Id(x => x.id);

            Map(x => x.name);
            
            Table(Program.db_name.ToString());
        }

}
}
