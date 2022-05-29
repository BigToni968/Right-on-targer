using UnityEngine;
using System;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class SnapShot : SnapShotBase
{
    [SerializeField, Header("Snapshot data")] private SnapShotData _snapShotData = null;
    protected private override SnapShotData SnapShotData { get => _snapShotData; set => _snapShotData = value; }
    protected private override float Speed { get; set; }
    protected private override float TurningSpeed { get; set; }
    protected private override Transform Target { get; set; }

    protected internal override event Action<SnapShotBase> Hit;

    protected private Rigidbody2D _body = null;

    protected internal override void Initialization()
    {
        if (SnapShotData == null)
            Debug.LogWarning($"{this.GetType()} not avaliable {nameof(SnapShotData)}");

        Speed = SnapShotData.Speed;
        TurningSpeed = SnapShotData.TurningSpeed;
        _body = GetComponent<Rigidbody2D>();
    }

    protected internal override void Instantiate(Transform Target) => this.Target = Target;

    protected internal override void OnUpdate()
    {
        OnMove();
        OnRotate();
    }

    private void OnMove() => transform.Translate(Vector2.up * Speed * Time.deltaTime);

    private void OnRotate()
    {
        Quaternion direction = Quaternion.Euler(transform.rotation.eulerAngles.x,
            transform.rotation.y,
            Mathf.Atan2(Target.position.y - transform.position.y, Target.position.x - transform.position.x) * Mathf.Rad2Deg - 90);

        transform.rotation = Quaternion.Lerp(transform.rotation, direction, TurningSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Target t;
        if (collision.gameObject.TryGetComponent<Target>(out t)) Hit?.Invoke(this);
    }


}
