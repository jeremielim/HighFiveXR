using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem _burst;
    [SerializeField] private AudioSource _clap;


    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        _burst.Play();
        _clap.Play();

        GameManager.Instance.UpdateScore(1);
    }
}