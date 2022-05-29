using UnityEngine;

[CreateAssetMenu(menuName = "Right to target/Target Spawn Data", fileName = "TargetSpawnData", order = 1)]
public class TargetSpawnData : ScriptableObject
{
    [SerializeField, Header("Prefab Target")] private Target _target = null;
    [SerializeField] private short _count = 0;

    public Target Target => _target;
    public short Count => _count;
}
