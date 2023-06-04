using UnityEngine;
using UnityEngine.EventSystems;
using InfimaGames.LowPolyShooterPack;

public class TouchAiming : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private float maxTimeBeetwenTouched = 1f;
    private float _timer;
    private bool _isTouched;
    private Character _character;

    private void Start()
    {
        _character = FindObjectOfType<Character>(true);
    }

    private void Update()
    {
        if (_timer > maxTimeBeetwenTouched)
        {
            _isTouched = false;
            _timer = 0;
        }

        if (_isTouched) _timer += Time.deltaTime;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_isTouched)
        {
            _character.OnTryAimingMobile();
            _isTouched = false;
            _timer = 0;
        }
        else _isTouched = true;
    }
}