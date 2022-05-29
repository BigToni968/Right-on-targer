using UnityEngine;

[CreateAssetMenu(menuName = "Right to target/Game Manager Data", fileName = "GameManagerData", order = 1)]
public class GameManagerData : ScriptableObject
{
    [SerializeField, Header("Prefabs array")] private MyMono[] _mono = null;
    public MyMono[] Mono => _mono;
}
