using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownHallClock.Shared.Model;

public class TimeEventArgs(TimeOnly time) : EventArgs
{
    public TimeOnly Time { get; set; } = time;
}
