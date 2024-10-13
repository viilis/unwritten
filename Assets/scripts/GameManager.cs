using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private GameObject inGameUI;

    private Daytimes _daytime;

    public Daytimes Daytime { get => _daytime; set => _daytime = value; }

    public GameManager()
    {
        Daytime = Daytimes.Morning;
    }

    private void Update()
    {

    }
}