using System;
using UnityEngine;

namespace TownOfWeekend.RainbowMod;

public class RainbowBehaviour : MonoBehaviour
{
    public Renderer Renderer;
    public int Id;

    public RainbowBehaviour(IntPtr ptr) : base(ptr)
    {
    }

    public void Update()
    {
        if (Renderer == null) return;

        if (RainbowUtils.IsRainbow(Id)) RainbowUtils.SetRainbow(Renderer);
    }

    public void AddRend(Renderer rend, int id)
    {
        Renderer = rend;
        Id = id;
    }
}