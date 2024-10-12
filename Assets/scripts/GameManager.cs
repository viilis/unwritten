using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private InGameUI inGameUI;

    public Daytimes Daytime { get => _daytime; set => _daytime = value; }

    public GameManager()
    {
        Daytime = Daytimes.Morning;
    }
}