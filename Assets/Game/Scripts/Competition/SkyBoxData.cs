using System;
using UnityEngine;

public class SkyBoxData
{
    public readonly DateTime competisionStartTime;
    private readonly Material material;

    public SkyBoxData(Material material, DateTime competisionStartTime)
    {
        this.material = material;
        this.competisionStartTime = competisionStartTime;
    }

    public void ChangeSky()
    {
        RenderSettings.skybox = material;
        /* RenderSettings.haloStrength = haloTexture;
         RenderSettings.flareStrength = 0.54F;
         RenderSettings.ambientLight = ambColor;
         RenderSettings.fogColor = fogColor;
         RenderSettings.fog = true;*/
    }
}