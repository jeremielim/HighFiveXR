using UnityEngine;

public class HitBounds : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    
    private void OnTriggerEnter(Collider other)
    {
        
        _gameManager.UpdateLife(-1);
        Destroy(other);
    }
}
