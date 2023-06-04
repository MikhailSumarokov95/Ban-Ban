using UnityEngine;

public class RotateLaser : MonoBehaviour
{
    [SerializeField] Transform laserTr;
    private Transform _mainCameraTr;
    private Life _life;

    private void Start()
    {
        _mainCameraTr = Camera.main.transform;
        _life = GetComponent<Life>();
    }

    private void LateUpdate()
    {
        if (_life.IsDid) return;

        laserTr.LookAt(_mainCameraTr.position - Vector3.up);
        laserTr.Rotate(Vector3.right, 270);
    }
}
