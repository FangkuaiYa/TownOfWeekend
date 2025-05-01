using System;
using System.Collections.Generic;
using Il2CppInterop.Runtime.Injection;
using Reactor.Utilities.Extensions;
using UnityEngine;

namespace TownOfWeekend.Patches.ScreenEffects;

public class CameraEffect : MonoBehaviour
{
    public List<Material> materials = new();

    static CameraEffect()
    {
        ClassInjector.RegisterTypeInIl2Cpp<CameraEffect>();
    }

    public CameraEffect(IntPtr ptr) : base(ptr)
    {
    }

    public static CameraEffect singleton { get; private set; }

    public void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (materials.Count == 0)
        {
            Graphics.Blit(source, destination);
            return;
        }

        foreach (var material in materials) Graphics.Blit(source, destination, material);
    }

    public static void Initialize()
    {
        if (singleton != null) singleton.Destroy();
        singleton = Camera.main.gameObject.AddComponent<CameraEffect>();
    }
}