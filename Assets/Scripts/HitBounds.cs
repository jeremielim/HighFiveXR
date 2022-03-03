using UnityEngine;

public class HitBounds : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    private void OnTriggerEnter(Collider other)
    {
        _gameManager.UpdateLife(-1);
        
        if (other.gameObject.tag != "Target") return;
        Destroy(other.gameObject);
    }
}