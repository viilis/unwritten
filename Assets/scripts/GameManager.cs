using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private Daytimes _daytime;

    public Daytimes Daytime { get => _daytime; set => _daytime = value; }

    public GameManager()
    {
        Daytime = Daytimes.Morning;
    }

    void OnEnable()
    {
        TimeManager.OnHourChange += OnHourlyChange;
    }

    void OnDisable()
    {
        TimeManager.OnHourChange -= OnHourlyChange;
    }

    private void OnHourlyChange(int hours)
    {
        Debug.Log(hours);
    }

    void Update()
    {
        Debug.Log(PlayerSanity.GetSanity());
    }
}