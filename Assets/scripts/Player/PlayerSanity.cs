using System;
using System.Collections;
using UnityEngine;

public class PlayerSanity : MonoBehaviour
{
    public static Action<float> OnSanityChange;

    [SerializeField]
    private static float sanity = 100;

    public static void IncreaseSanity(float amount)
    {
        sanity += amount;
        OnSanityChange?.Invoke(sanity);
    }

    public static void DecreaseSanity(float amount)
    {
        sanity -= amount;
        OnSanityChange?.Invoke(sanity);
    }

    public static float GetSanity()
    {
        return sanity;
    }
}
