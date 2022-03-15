using UnityEngine;

public class HitBounds : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.UpdateLife(-1);

        if (other.gameObject.tag != "Target") return;
        Destroy(other.gameObject);
    }
}