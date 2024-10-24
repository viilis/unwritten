using System.Collections.Generic;
using Unity;
using UnityEngine;

public class ColorSwitcher
{
    private Material _material;
    private Color _newColor;
    private Color _originalColor;

    private bool isChanged = false;

    public ColorSwitcher(Color color, Material material)
    {
        _newColor = color;
        _material = material;
        _originalColor = material.GetColor("_Color");
    }

    // TODO: Changes on materials are permanent.
    public void SwitchColor()
    {
        if (!isChanged)
        {
            _material.SetColor("_Color", _newColor);
            isChanged = !isChanged;
        }
        else
        {
            _material.SetColor("_Color", _originalColor);
            isChanged = !isChanged;
        }
    }
}