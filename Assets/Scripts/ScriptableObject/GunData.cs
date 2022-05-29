using UnityEngine;

[CreateAssetMenu(menuName = "Right to target/Gun Data", fileName = "GunData", order = 1)]
public class GunData : ScriptableObject
{
    [SerializeField, Header("Prefab Snapshot")] private SnapShot _snapShot = null;
    [SerializeField] private float _reloading = 0f;

    public SnapShot SnapShot => _snapShot;
    public float Reloading => _reloading;
}
