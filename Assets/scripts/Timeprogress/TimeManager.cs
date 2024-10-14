using System;
using Unity;
using UnityEngine;


// --- Observer pattern ---
// You can make anything to subscribe OnHour/MinuteChange and this class Invokes them
// at every in-game minute/hour change. Could be used for e.g. clock object
public class TimeManager : Singleton<TimeManager>
{
    public static Action<int> OnMinuteChange;
    public static Action<int> OnHourChange;

    public int Minute { get; private set; }
    public int Hour { get; private set; }

    private float _minToIRL = 0.5f;
    private float _timer;

    private void Start()
    {
        Minute = 0;
        Hour = 10;

        _timer = _minToIRL;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            Minute++;
            OnMinuteChange?.Invoke(Minute);
            if (Minute >= 60)
            {
                Hour++;
                Minute = 0;
                OnHourChange?.Invoke(Hour);

                if (Hour >= 24)
                {
                    Hour = 0;
                }
            }
            _timer = _minToIRL;
        }
    }
}