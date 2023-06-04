using UnityEngine;
using UnityEngine.EventSystems;
using InfimaGames.LowPolyShooterPack;

public class ButtonAttack : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerUpHandler
{
    private Character _character;

    private void Start()
    {
        _character = FindObjectOfType<Character>(true);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _character.OnTryFireMobile(Character.PhaseFire.Started);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _character.OnTryFireMobile(Character.PhaseFire.Performed);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _character.OnTryFireMobile(Character.PhaseFire.Canceled);
    }
}
