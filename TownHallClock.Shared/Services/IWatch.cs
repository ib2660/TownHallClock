using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownHallClock.Shared.Model;

namespace TownHallClock.Shared.Services;

public interface IWatch
{
    event TimeEventHandler OnTimeChanged;
    event TimeEventHandler OnAlarm;
    void Run();
    void SetAlarm(TimeOnly alarm);
    public void Stop();
    public string GetTime();
}
