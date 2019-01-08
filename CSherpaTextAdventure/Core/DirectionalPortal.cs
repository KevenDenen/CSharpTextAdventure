using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTextAdventure.Core
{
    class DirectionalPortal
    {
        public DirectionalPortal(Location leadsTo)
        {
            LeadsTo = leadsTo;
        }
        public Location LeadsTo { get; private set; }
    }
}
