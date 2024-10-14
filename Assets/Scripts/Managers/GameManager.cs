using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private TaskManager _taskmanager;
    private TimeManager _timemanager;

    public GameManager()
    {
        _taskmanager = new TaskManager();
        _timemanager = new TimeManager();
    }

    void OnEnable()
    {
        TimeManager.OnHourChange += OnHourlyChange;
        PlayerSanity.OnSanityChange += OnSanityChange;
    }

    void OnDisable()
    {
        TimeManager.OnHourChange -= OnHourlyChange;
        PlayerSanity.OnSanityChange -= OnSanityChange;
    }

    private void OnHourlyChange(int hours)
    {
        Debug.Log(hours);
    }

    private void OnSanityChange(float currentState)
    {
        Debug.Log(currentState);
    }

    void Update()
    {

    }
}