using UnityEngine;

public abstract class TargetSpawnBase : MyMono
{
    protected private abstract TargetSpawnData TargetSpawnData { get; set; }
    protected private abstract Transform TargetPoint { get; set; }

    protected internal abstract void Instantiate(Transform TargetPoint);
}
