using UnityEngine;

[CreateAssetMenu(menuName = "Right to target/Target Data", fileName = "TargetData", order = 1)]
public class TargetData : ScriptableObject
{
    [SerializeField] private float _radius = 0f;
    [SerializeField] private float _speed = 0f;

    public float Radius => _radius;
    public float Speed => _speed;
}
