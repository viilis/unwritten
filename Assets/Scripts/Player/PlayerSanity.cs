using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSanity : MonoBehaviour
{
    public static event Action<float> OnSanityChange;

    [SerializeField]
    private static float _sanity = 150;

    public static void ChangeSanity(float amount)
    {
        _sanity += amount;
        OnSanityChange?.Invoke(_sanity);
    }

    public static void ResetSanity()
    {
        _sanity = 150;
    }

    public static float GetSanity()
    {
        return _sanity;
    }
}
