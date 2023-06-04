using GameScore;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private bool isMobile;
    public bool IsMobile { get { return isMobile; } private set { isMobile = value; } }

    private void Awake()
    {
        if (!Application.isEditor) IsMobile = GS_Device.IsMobile();
    }
}
