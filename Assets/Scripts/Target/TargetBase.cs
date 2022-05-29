using UnityEngine;

public abstract class TargetBase : MonoBehaviour
{
    protected private abstract TargetData TargetData { get; set; }
    protected private abstract float Speed { get; set; }
    protected private abstract Transform TargetPoint { get; set; }
    protected private abstract float Radius { get; set; }
    protected internal abstract void Initialization();
    protected internal abstract void Instantiate(Transform TargetPoint);
    protected internal abstract void OnUpdate();
}
