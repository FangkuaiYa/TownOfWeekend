using System.Collections;
using Reactor.Utilities;
using UnityEngine;

namespace TownOfWeekend.Patches.ScreenEffects;

public abstract class ScriptEffect
{
    protected Camera camera = CameraEffect.singleton.gameObject.GetComponent<Camera>();

    protected ScriptEffect()
    {
        Coroutines.Start(runEffect());
    }

    public abstract IEnumerator runEffect();
}