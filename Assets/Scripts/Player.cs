using UnityEngine;

public class Player : MyMono
{
    [SerializeField] private Gun _gun = null;

    private GameManager _gameManager = null;

    private int indexTarget = 0;

    protected internal override void Initialization()
    {
        _gun = Instantiate(_gun, transform);
        _gun.Initialization();
    }
    public void Instantiate(GameManager GameManager) => _gameManager = GameManager;

    protected internal override void OnUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
            if (_gun.OnAttack(_gameManager.TargetSpawn.Targets[indexTarget].transform))
                 indexTarget = indexTarget < _gameManager.TargetSpawn.Targets.Count - 1 ? indexTarget + 1 : 0;

        if (_gun != null) _gun.OnUpdate();
    }
}
