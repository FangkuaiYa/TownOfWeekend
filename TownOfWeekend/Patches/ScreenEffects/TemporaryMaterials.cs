using System.Collections;
using Reactor.Utilities;
using UnityEngine;

namespace TownOfWeekend.Patches.ScreenEffects;

public abstract class TemporaryMaterial
{
    private protected Material original_material;

    protected TemporaryMaterial(GameObject target)
    {
        this.target = target;
        Coroutines.Start(apply_Material());
    }

    protected TemporaryMaterial(Renderer target)
    {
        rtarget = target;
        Coroutines.Start(rapply_Material());
    }

    public abstract Material mat { get; }
    public abstract float duration { get; }
    private GameObject target { get; }
    private Renderer rtarget { get; }

    protected IEnumerator apply_Material()
    {
        original_material = target.GetComponent<Renderer>().material;
        target.GetComponent<Renderer>().material = mat;
        yield return new WaitForSecondsRealtime(duration);
        target.GetComponent<Renderer>().material = original_material;
    }

    protected IEnumerator rapply_Material()
    {
        original_material = rtarget.material;
        var sharedmat = rtarget.sharedMaterial;

        rtarget.material = mat;
        rtarget.sharedMaterial = mat;
        yield return new WaitForSecondsRealtime(duration);
        rtarget.material = original_material;
        rtarget.sharedMaterial = sharedmat;
    }
}