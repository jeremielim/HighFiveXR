using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private ParticleSystem _burst;
    [SerializeField] private AudioSource _clap;
    [SerializeField] private GameManager _gameManager;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        _burst.Play();
        _clap.Play();

        _gameManager.UpdateScore(1);
    }

    public void Update()
    {
        // Move to player to mouse position
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        transform.position = ray.GetPoint(0.5f);
    }
}