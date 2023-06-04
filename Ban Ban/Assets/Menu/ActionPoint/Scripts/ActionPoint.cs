using InfimaGames.LowPolyShooterPack;
using UnityEngine;

public class ActionPoint : MonoBehaviour
{
    [SerializeField] private GameObject UIElement;
    [SerializeField] private Transform pointStayPlayer;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UIElement.SetActive(true);
            //FindObjectOfType<MenuManager>().OnPause(true);
            collision.GetComponent<Character>().SetPositionAndRotation(pointStayPlayer);
        }
    }
}
