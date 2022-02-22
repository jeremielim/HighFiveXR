using UnityEngine;

public class MoverForward : MonoBehaviour
{
    private Rigidbody rb;
    private int randAcc;

    private void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        randAcc = Random.Range(1, 20);
    }

    public void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.AddForce(Vector3.back * randAcc, ForceMode.Force);
    }

    public void StopMoving()
    {
        rb.velocity = Vector3.zero;
    }
}