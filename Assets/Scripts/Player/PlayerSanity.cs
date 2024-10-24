using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSanity : MonoBehaviour
{
    public static event Action<float> OnSanityChange;

    [SerializeField]
    private static float _sanity = 100;

    public static void IncreaseSanity(float amount)
    {
        _sanity += amount;
        OnSanityChange?.Invoke(_sanity);
    }

    public static void DecreaseSanity(float amount)
    {
        _sanity -= amount;
        OnSanityChange?.Invoke(_sanity);
    }

    public static float GetSanity()
    {
        return _sanity;
    }
}
