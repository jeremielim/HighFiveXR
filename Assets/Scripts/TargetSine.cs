using Unity.VisualScripting;
using UnityEngine;

public class TargetSine : TargetBase
{
    protected override void Move()
    {
        var curPos = transform.position;
        var aAcc = Mathf.Sin(Mathf.PI * Time.time);
        var aVel = new Vector3(aAcc, curPos.y, curPos.z);

        transform.position = aVel;

        _rb.AddForce(moveDirection * speed, ForceMode.Force);
    }
}