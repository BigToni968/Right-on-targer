using System.Collections.Generic;
using UnityEngine;

public class TargetSpawn : TargetSpawnBase
{
    [SerializeField, Header("Target spawn data")] private TargetSpawnData _targetSpawnData = null;
    protected private override TargetSpawnData TargetSpawnData { get => _targetSpawnData; set => _targetSpawnData = value; }
    protected private override Transform TargetPoint { get; set; }

    public List<Target> Targets { get; protected set; } = null;

    protected internal override void Initialization()
    {
        if (TargetSpawnData == null)
            Debug.LogWarning($"{this.GetType()} not avaliable {nameof(TargetSpawnData)}");

        Targets = new List<Target>(TargetSpawnData.Count);
    }

    protected internal override void Instantiate(Transform Target)
    {
        this.TargetPoint = Target;
        Spawn();
    }
    protected internal override void OnUpdate()
    {
        foreach (TargetBase target in Targets)
            target.OnUpdate();
    }

    private void Spawn()
    {
        for (short i = 0; i < Targets.Capacity; i++)
        {
            Targets.Add(AddTarget(TargetSpawnData.Target));
            Targets[i].Instantiate(i);
        }

    }

    private Target AddTarget(Target Target)
    {
        Target target = Instantiate(TargetSpawnData.Target, transform);
        target.Initialization();
        target.Instantiate(TargetPoint);
        return target;
    }

    private void AddTargets(Target Target) => Targets.Add(AddTarget(Target));
}
