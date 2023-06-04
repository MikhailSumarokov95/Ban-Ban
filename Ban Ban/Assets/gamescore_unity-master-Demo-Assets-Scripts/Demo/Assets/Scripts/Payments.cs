using UnityEngine;
using GameScore;
public class Payments : MonoBehaviour
{
    private void OnEnable()
    {
        GS_Payments.OnPaymentsPurchase += OnPaymentsPurchase;
    }

    private void OnDisable()
    {
        GS_Payments.OnPaymentsPurchase -= OnPaymentsPurchase;
    }

    public void FetchProducts()
    {
        GS_Payments.FetchProducts();
    }

    public void GoldPurchase(string idOrTag)
    {
        //EXTRA_GOLD
        GS_Payments.Purchase(idOrTag);
    }

    public void VipPurchase(string idOrTag)
    {
        //VIP
        GS_Payments.Purchase(idOrTag);
    }

    public void VipConsume(string idOrTag)
    {
        GS_Payments.Consume(idOrTag);
    }

    private void OnPaymentsPurchase(string purchasedIdOrTag)
    {
        if (purchasedIdOrTag == "EXTRA_GOLD")
            Player.Instance.GoldPurchased();

        if (purchasedIdOrTag == "VIP")
            Player.Instance.VipPurchased();
    }
}
