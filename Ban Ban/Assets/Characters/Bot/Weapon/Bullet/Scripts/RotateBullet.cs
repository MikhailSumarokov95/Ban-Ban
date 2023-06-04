using UnityEngine;

public class RotateBullet : MonoBehaviour
{
    [SerializeField] private Transform model;
    [SerializeField] float speed = 360f;

    private void Update()
    {
        model.Rotate(Vector3.right, Time.deltaTime * speed, Space.Self);
    }
}
