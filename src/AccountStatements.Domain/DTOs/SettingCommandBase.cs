using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountStatements.Domain.DTOs
{
    public abstract class SettingCommandBase
    {
        public decimal InterestPct { get; set; }
        public decimal MinBalancePct { get; set; }
    }
}
