using InfimaGames.LowPolyShooterPack;
using UnityEngine;
using UnityEngine.UI;

public class ShopWeapon : MonoBehaviour, IShopPurchase
{
    [SerializeField] private WeaponBehaviour.Name nameWeapon;
    [SerializeField] private Image buyWeaponImage;
    [SerializeField] private Image boughtWeaponImage;
    [SerializeField] private GameObject shopWeaponPanel;

    private void OnEnable()
    {
        InitShop();
    }

    public void BuyWeaponForMoney(int price)
    {
        if (Money.SpendMoney(price))
        {
            Progress.SetBuyWeapon(nameWeapon);
            InitShop();
        }
    }

    public void TryPurchase()
    {
        switch (nameWeapon)
        {
            case WeaponBehaviour.Name.GL01:
                GSConnect.Purchase(GSConnect.PurchaseTag.GrenadeLauncher, this);
                break;
            case WeaponBehaviour.Name.RL01:
                GSConnect.Purchase(GSConnect.PurchaseTag.RocketLauncher, this);
                break;
        }
    }

    public void RewardPerPurchase()
    {
        Progress.SetBuyWeapon(nameWeapon);
        InitShop();
    }

    public void StartAttachmentShop()
    {
        var shopAttachment = FindObjectOfType<ShopAttachment>(true);
        shopAttachment.gameObject.SetActive(true);
        shopAttachment.StartInitWeapons(nameWeapon);
        shopWeaponPanel.SetActive(false);
    }

    private void InitShop()
    {
        if (Progress.IsBoughtWeapon(nameWeapon))
        {
            boughtWeaponImage.gameObject.SetActive(true);
            buyWeaponImage.gameObject.SetActive(false);
        } 
        else
        {
            boughtWeaponImage.gameObject.SetActive(false);
            buyWeaponImage.gameObject.SetActive(true);
        }
    }
}