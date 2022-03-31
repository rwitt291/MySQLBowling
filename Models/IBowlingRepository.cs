using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySQLBowling.Models
{
    public interface IBowlingRepository
    {
        IQueryable<Bowler> Bowlers { get; }
    }
}
