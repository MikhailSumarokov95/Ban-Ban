using UnityEngine;

public class TargetMoveBot : MonoBehaviour
{
    public Transform GetTarget()
    {
        if (gameObject.CompareTag("Enemy")) return GameObject.FindGameObjectWithTag("Player").transform;
        else
        { 
            return null;
        }
    }
}
