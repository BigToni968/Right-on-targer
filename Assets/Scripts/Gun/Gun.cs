using System.Collections.Generic;
using UnityEngine;

public class Gun : GunBase
{
    [SerializeField, Header("Gun data")] private GunData _gunData = null;
    protected private override GunData GunData { get => _gunData; set => _gunData = value; }
    protected private override float Reloading { get; set; }

    private List<SnapShot> _snapShotsList = null;

    private bool _attackSuccesed = false;
    private Timer _timer = null;

    protected internal override void Initialization()
    {
        if (GunData == null)
            Debug.LogWarning($"{this.GetType()} not avaliable {nameof(GunData)}");

        Reloading = GunData.Reloading;
        _snapShotsList = new List<SnapShot>(100);
        _timer = new Timer();
    }

    protected internal override bool OnAttack(Transform Direction)
    {
        if (!_attackSuccesed)
        {
            SnapShot snapShot = Instantiate(GunData.SnapShot);
            snapShot.Initialization();
            snapShot.transform.position = new Vector2(transform.position.x, transform.localScale.y);
            snapShot.Instantiate(Direction);
            snapShot.Hit += SnapShotListClear;
            _snapShotsList.Add(snapShot);
            _attackSuccesed = true;
            return _attackSuccesed;
        }

        return !_attackSuccesed;
    }

    private void SnapShotListClear(SnapShotBase snapShot)
    {
        snapShot.Hit -= SnapShotListClear;
        _snapShotsList.RemoveAll(snapshot => ReferenceEquals(snapshot, snapShot));
        Destroy(snapShot.gameObject);
    }


    protected internal override void OnUpdate()
    {
        if (_snapShotsList.Count > 0)
            foreach (SnapShot snapShot in _snapShotsList)
                snapShot.OnUpdate();

        if (_attackSuccesed)
            if (_timer.Counting(_gunData.Reloading)) _attackSuccesed = false;
    }
}
