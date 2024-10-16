using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitcher
{
    private Light _light;

    public LightSwitcher(Light light, bool beginState)
    {
        _light = light;
        if (beginState) { _light.enabled = true; } else { _light.enabled = false; };
    }

    public void Switch()
    {
        _light.enabled = !_light.enabled;
    }
}
