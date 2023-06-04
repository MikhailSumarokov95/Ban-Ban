using UnityEngine;

public class RewardImage : MonoBehaviour
{
    [SerializeField] private float speedMove;
    [SerializeField] private float timeMove;
    private float _timerMove;
    private Transform _transform;

    private void OnEnable()
    {
        _transform = transform;
        _timerMove = 0;
        _transform.localPosition = Vector3.zero;
    }

    private void OnDisable()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (timeMove > _timerMove)
        {
            _transform.Translate(speedMove * Vector3.up * Time.unscaledDeltaTime);
            _timerMove += Time.unscaledDeltaTime;
        }

        else
        {
            _timerMove = 0;
            gameObject.SetActive(false);
        }
    }
}