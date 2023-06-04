using UnityEngine;
using UnityEngine.UI;

public class EffectHitInPlayer : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] private float alfaImageStart;
    [SerializeField] private float decayRate = 1f;
    [SerializeField] private Image[] bloodEffect;
    private HealthPoints _healthPoints;

    private void OnEnable()
    {
        _healthPoints = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthPoints>();
        _healthPoints.OnTakeDamage += StartEffect;
    }

    private void OnDisable()
    {
        _healthPoints.OnTakeDamage -= StartEffect;
    }

    private void Update()
    {
        if (bloodEffect[0].color.a < 0) return;

        for (var i = 0; i < bloodEffect.Length; i++)
        {
            var colorEffect = bloodEffect[i].color;

            bloodEffect[i].color = new Color(colorEffect.r, colorEffect.g, colorEffect.b,
                colorEffect.a - (Time.deltaTime * decayRate));
        }
    }

    public void StartEffect () 
    {
        for (var i = 0; i < bloodEffect.Length; i++)
        {
            var colorEffect = bloodEffect[i].color;

            bloodEffect[i].color = new Color(colorEffect.r, colorEffect.g, colorEffect.b, alfaImageStart);
        }
    }
}
