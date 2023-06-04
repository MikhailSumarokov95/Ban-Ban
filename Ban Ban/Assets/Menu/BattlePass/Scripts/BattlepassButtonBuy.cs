using UnityEngine;
using UnityEngine.UI;

public class BattlepassButtonBuy : MonoBehaviour
{
    [SerializeField] private Image isNotBoughtButton;
    [SerializeField] private Image isBoughtButton;

    private void OnEnable()
    {
        InitButton();
        GSConnect.OnPurchase += InitButton;
    }

    private void OnDisable()
    {
        GSConnect.OnPurchase -= InitButton;
    }

    public void TryPurchase()
    {
        FindObjectOfType<BattlePassRewarder>(true).TryPurchase();
    }

    private void InitButton()
    {
        if (Progress.IsBoughtBattlePass())
        {
            isNotBoughtButton.gameObject.SetActive(false);
            isBoughtButton.gameObject.SetActive(true);
        }
        else
        {
            isNotBoughtButton.gameObject.SetActive(true);
            isBoughtButton.gameObject.SetActive(false);
        }
    }
}
