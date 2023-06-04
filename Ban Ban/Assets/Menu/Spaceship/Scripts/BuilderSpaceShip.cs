using UnityEngine;
using TMPro;
using UnityEngine.UI;
using GameScore;

public class BuilderSpaceShip : MonoBehaviour, IShopPurchase
{
    [SerializeField] private GameObject[] shipParts;
    [SerializeField] private GameObject effect;
    [SerializeField] private TMP_Text freePartsText;
    [SerializeField] private Button getOffThePlanetButton;

    private void Start()
    {
        foreach (var part in shipParts) 
            part.SetActive(false);

        var shipAssemblyStage = Progress.GetShipAssemblyStage();
        for (var i = 0; i < shipAssemblyStage; i++)
        {
            shipParts[i].SetActive(true);
        }
        RefreshTextFreeParts();
        RefreshStateGetOffThePlanetButton();
    }

    public void AddShipAssemblyStage()
    {
        var shipAssemblyStage = Progress.GetShipAssemblyStage();
        if (shipAssemblyStage < Progress.GetNumberPartsFoundShip() && shipAssemblyStage < shipParts.Length)
        {
            shipAssemblyStage++;
            Progress.SetShipAssemblyStage(shipAssemblyStage);
            var part = shipParts[shipAssemblyStage - 1];
            part.SetActive(true);
            Instantiate(effect, part.transform);
        }
        RefreshTextFreeParts();
        RefreshStateGetOffThePlanetButton();
    }

    public void TryPurchase()
    {
        GSConnect.Purchase(GSConnect.PurchaseTag.PartSpaceShip, this);
    }

    public void RewardPerPurchase()
    {
        AddParts();
        AddShipAssemblyStage();
    }

    [ContextMenu("AddParts")]
    public void AddParts()
    {
        Progress.SetNumberPartsFoundShip(Progress.GetNumberPartsFoundShip() + 1);
    }

    private void RefreshTextFreeParts()
    {
        freePartsText.text = (Progress.GetNumberPartsFoundShip() - Progress.GetShipAssemblyStage()).ToString();
    }

    private void RefreshStateGetOffThePlanetButton()
    {
        getOffThePlanetButton.gameObject
            .SetActive(Progress.GetShipAssemblyStage() >= shipParts.Length);
    }
}
