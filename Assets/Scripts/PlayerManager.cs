using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private ParticleSystem _burst;
    [SerializeField] private AudioSource _clap;
    [SerializeField] private GameManager _gameManager;

    private float t;
    private float speed;

    private void Start()
    {
        t = 0;
        speed = 2.5f;
    }

    public void Update()
    {
        // Move to player to mouse position
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        var newPos = ray.GetPoint(0.5f);
        newPos.z = 0.6f;


        if (Input.GetMouseButton(0))
        {
            transform.position = new Vector3(newPos.x, newPos.y, Mathf.Lerp(newPos.z, 1.6f, t));
            t += speed * Time.deltaTime;
            // newPos.z = 0.8f;

            //Debug.Log(Vector3.Lerp(curPos, new Vector3(curPos.x, curPos.y, 0.8f), t));
        }
        else
        {
            transform.position = newPos;
            t = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        _burst.Play();
        _clap.Play();

        _gameManager.UpdateScore(1);
    }
}