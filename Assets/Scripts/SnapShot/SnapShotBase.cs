using UnityEngine;
using System;

public abstract class SnapShotBase : MonoBehaviour
{
    protected internal abstract event Action<SnapShotBase> Hit;
    protected private abstract SnapShotData SnapShotData { get; set; }
    protected private abstract float Speed { get; set; }
    protected private abstract float TurningSpeed { get; set; }
    protected private abstract Transform Target { get; set; }
    protected internal abstract void Initialization();
    protected internal abstract void Instantiate(Transform Target);
    protected internal abstract void OnUpdate();
}
