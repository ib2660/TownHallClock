using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownHallClock.Shared.Services;

namespace TownHallClock.Shared.Model;

public delegate void TimeEventHandler(object sender, TimeEventArgs e);

public class WatchClass : IWatch
{
    public event TimeEventHandler? OnTimeChanged;
    public event TimeEventHandler? OnAlarm;
    private TimeOnly _alarm;
    private TimeOnly _time;
    private CancellationTokenSource? _cancellationTokenSource;

    public string GetTime()
    {
        return _time.ToString("HH:mm:ss");
    }

    public void Run()
    {
        _cancellationTokenSource = new CancellationTokenSource();
        var token = _cancellationTokenSource.Token;

        Task.Run(() =>
        {
            while (!token.IsCancellationRequested)
            {
                Thread.Sleep(1000);
                _time = new TimeOnly(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                if (_time == _alarm)
                {
                    OnAlarm?.Invoke(this, new TimeEventArgs(_time));
                }
                OnTimeChanged?.Invoke(this, new TimeEventArgs(_time));
            }
        }, token);
    }

    public void Stop()
    {
        Console.WriteLine("Stop is called");
        _cancellationTokenSource?.Cancel();
    }

    public void SetAlarm(TimeOnly alarm)
    {
        Console.WriteLine($"SetAlarm is called {alarm}");
        _alarm = new TimeOnly(alarm.Hour, alarm.Minute, alarm.Second);
    }
}
