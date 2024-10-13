using System;
using Unity;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static Action OnMinuteChange;
    public static Action OnHourChange;

    public static int Minute { get; private set; }
    public static int Hour { get; private set; }

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
            OnMinuteChange?.Invoke();
            if (Minute <= 60)
            {
                Hour++;
                Minute = 0;
                OnHourChange?.Invoke();
            }
            _timer = _minToIRL;
        }
    }
}