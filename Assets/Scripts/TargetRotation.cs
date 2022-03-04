using UnityEngine;

public class TargetRotation : TargetBase
{
    [SerializeField] private float rotationSpeed = 0.1f;
    private float _angRad = Mathf.PI / 4;
    
    protected override void Move()
    {
        var curPos = transform.position;
        var aVel = new Vector3(Mathf.Cos(_angRad), Mathf.Sin(_angRad), curPos.z);

        transform.position = aVel;
        _angRad += rotationSpeed;

        _rb.AddForce(moveDirection * speed, ForceMode.Force);
    }
}