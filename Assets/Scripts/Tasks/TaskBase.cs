using Unity;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Tasks/Task base")]
public class TaskBase : ScriptableObject
{
    [SerializeField] public string taskName { get; }
    [SerializeField] public string description { get; }
}