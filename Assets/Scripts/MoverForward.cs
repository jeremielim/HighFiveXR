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
        rb.AddForce(Vector3.back * randAcc, ForceMode.Force);

        // Destroy if obj goes behind camera
        if (transform.position.z < -1)
        {
            Destroy(gameObject);
        }
    }
}