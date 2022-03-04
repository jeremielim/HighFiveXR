using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TargetBase : MonoBehaviour
{
    [SerializeField] protected int speed;
    [SerializeField] protected Vector3 moveDirection;

    protected Rigidbody _rb;

    private void Start()
    {
        _rb = transform.GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        Move();
    }

    protected virtual void Move()
    {
        _rb.AddForce(moveDirection * speed, ForceMode.Force);
    }

    public void StopMoving()
    {
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
    }
}