using UnityEngine;

public class MobileUIController : MonoBehaviour
{
    [SerializeField] private GameObject[] mobileElementsUI;
    [SerializeField] private GameObject[] pcElementsUI;

    private void Start()
    {
        var isMobile = FindObjectOfType<PlatformManager>().IsMobile;

        foreach(var UI in mobileElementsUI)
        {
            UI.SetActive(isMobile);
        }
        
        foreach(var UI in pcElementsUI)
        {
            UI.SetActive(!isMobile);
        }
    }
}
