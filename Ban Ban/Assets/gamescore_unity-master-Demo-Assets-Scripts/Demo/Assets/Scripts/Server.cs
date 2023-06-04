using UnityEngine;
using GameScore;
using TMPro;

public class Server : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    // Все методы вызываются через UI - Time Button
    // All methods are called via UI - Time Button

    public void Time()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        Debug.Log(GS_Server.Time());
         _text.text = GS_Server.Time().ToString();
#endif
    }


}
