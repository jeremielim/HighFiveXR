using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetManager : MonoBehaviour
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
        
        if (transform.position.z < -3)
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        rb.AddForce(Vector3.back * randAcc, ForceMode.Force);
    }

    public void StopMoving()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}