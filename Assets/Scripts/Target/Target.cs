using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Target : TargetBase
{
    [SerializeField, Header("Target data")] private TargetData _targetData = null;
    protected private override TargetData TargetData { get => _targetData; set => _targetData = value; }
    protected private override float Radius { get; set; }
    protected private override float Speed { get; set; }
    protected private override Transform TargetPoint { get; set; }

    protected private Rigidbody2D _targerBody = null;
    protected private float _angle = 0f;

    protected internal override void Initialization()
    {
        if (TargetData == null)
            Debug.LogWarning($"{this.GetType()} not avaliable {nameof(TargetData)}");

        this.Radius = TargetData.Radius;
        this.Speed = TargetData.Speed;
        _targerBody = GetComponent<Rigidbody2D>();
    }

    protected internal void Instantiate(float Angle) => _angle = Angle;

    protected private virtual void OnMove(Vector2 Direcction) => _targerBody.MovePosition(Direcction);

    protected private virtual Vector2 OnDirection()
    {
        Vector2 direction = Vector2.zero;
        direction.x = TargetPoint.position.x + Mathf.Cos(_angle) * Radius;
        direction.y = TargetPoint.position.y + Mathf.Sin(_angle) * Radius;
        _angle += Time.deltaTime * Speed;
        return direction;
    }

    protected internal override void Instantiate(Transform TargetPoint) => this.TargetPoint = TargetPoint;

    protected internal override void OnUpdate()
    {
        OnMove(OnDirection());
    }

}
