using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GSPrice : MonoBehaviour {

    [SerializeField] string purchaseTag;

    void Awake() {
        Text text = GetComponent<Text>();
        if (text) text.text = GSConnect.GetPrice(purchaseTag);
        TextMeshProUGUI textMeshPro = GetComponent<TextMeshProUGUI>();
        if (textMeshPro) textMeshPro.text = GSConnect.GetPrice(purchaseTag);
    }

}