using UnityEngine;

public abstract class GunBase : MonoBehaviour
{
    protected private abstract GunData GunData { get; set; }
    protected private abstract float Reloading { get; set; }

    protected internal abstract void Initialization();
    protected internal abstract bool OnAttack(Transform Direction);
    protected internal abstract void OnUpdate();
}
