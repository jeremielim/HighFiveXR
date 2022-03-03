using UnityEngine;
using Random = UnityEngine.Random;

public class TargetManager : MonoBehaviour
{
    private Rigidbody _rb;
    private int _randAcc;

    private void Start()
    {
        _rb = transform.GetComponent<Rigidbody>();
        _randAcc = Random.Range(1, 20);
    }

    public void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rb.AddForce(Vector3.back * _randAcc, ForceMode.Force);
    }

    public void StopMoving()
    {
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
    }
}