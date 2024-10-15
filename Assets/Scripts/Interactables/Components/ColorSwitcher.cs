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
        _originalColor = material.color;
    }

    // TODO: Changes on materials are permanent.
    public void SwitchColor()
    {
        if (!isChanged)
        {
            _material.color = _newColor;
            isChanged = !isChanged;
        }
        else
        {
            _material.color = _originalColor;
            isChanged = !isChanged;
        }
    }
}