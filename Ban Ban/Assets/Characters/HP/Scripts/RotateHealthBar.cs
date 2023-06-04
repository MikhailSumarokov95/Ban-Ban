using UnityEngine;

public class RotateHealthBar : MonoBehaviour
{
    private void Update()
    {
        LookAtCamera();
    }

    private void LookAtCamera()
    {
        var v = transform.position - Camera.main.transform.position;
        v.x = v.z = 0f;
        transform.LookAt(Camera.main.transform.position - v);
    }
}
