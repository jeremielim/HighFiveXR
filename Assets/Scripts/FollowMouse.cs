using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    public void Update()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        transform.position = ray.GetPoint(0.5f);
    }
}