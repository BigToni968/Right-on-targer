using UnityEngine;

[CreateAssetMenu(menuName = "Right to target/SnapShot Data", fileName = "SnapShotData", order = 1)]
public class SnapShotData : ScriptableObject
{
    [SerializeField] private float _speed = 0f;
    [SerializeField] private float _turningSpeed = 0f;

    public float Speed => _speed;
    public float TurningSpeed => _turningSpeed;
}
