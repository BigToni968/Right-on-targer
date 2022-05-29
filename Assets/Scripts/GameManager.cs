using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameManagerData _gameManagerData = null;

    private List<MyMono> _mono = null;

    public Player Player { get; protected internal set; } = null;
    public TargetSpawn TargetSpawn { get; protected internal set; } = null;

    private void Awake()
    {
        _mono = new List<MyMono>(_gameManagerData.Mono.Length);
        Instantiate();
        TargetSpawn.Instantiate(Player.transform);
        Player.Instantiate(this);
    }

    private void Instantiate()
    {
        for (short i = 0; i < _mono.Capacity; i++)
        {
            MyMono myMono = Instantiate(_gameManagerData.Mono[i], transform);
            myMono.Initialization();
            if (Player == null) Player = myMono as Player;
            if (TargetSpawn == null) TargetSpawn = myMono as TargetSpawn;
            _mono.Add(myMono);
        }
    }

    private void FixedUpdate()
    {
        foreach (MyMono mono in _mono)
            mono.OnUpdate();
    }
}
