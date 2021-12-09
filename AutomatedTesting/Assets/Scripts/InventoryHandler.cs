using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
    string coinsPlayerPrefKey = "COINS";
    string diamondsPlayerPrefKey = "DIAMONDS";
    string MysteryBoxPlayerPrefKey = "MYSTERY_BOX";
    string BoostsPlayerPrefKey = "BOOSTS";
    string HeadStartPlayerPrefKey = "HEAD_START";

    int coinsAmountToAdd = 100;
    int coinsCostInDiamonds = 10;

    int diamondsAmountToAdd = 200;

    int boostAmountToAdd = 50;
    int boostAmountCostInCoins = 1000;

    int headStartAmountToAdd = 25;
    int headStartCostInCoins = 5;

    int mysteryBoxAmountToAdd = 10;
    int mysteryBoxCostInCoins = 20;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey(coinsPlayerPrefKey))
        {
            PlayerPrefs.SetInt(coinsPlayerPrefKey, 0);
        }

        if (!PlayerPrefs.HasKey(diamondsPlayerPrefKey))
        {
            PlayerPrefs.SetInt(diamondsPlayerPrefKey, 0);
        }

        if (!PlayerPrefs.HasKey(MysteryBoxPlayerPrefKey))
        {
            PlayerPrefs.SetInt(MysteryBoxPlayerPrefKey, 0);
        }

        if (!PlayerPrefs.HasKey(BoostsPlayerPrefKey))
        {
            PlayerPrefs.SetInt(BoostsPlayerPrefKey, 0);
        }

        if (!PlayerPrefs.HasKey(HeadStartPlayerPrefKey))
        {
            PlayerPrefs.SetInt(HeadStartPlayerPrefKey, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Can be purchased via diamonds
    public void BuyCoins(int amountToBuy, int cost)
    {
        PlayerPrefs.SetInt(diamondsPlayerPrefKey, PlayerPrefs.GetInt(diamondsPlayerPrefKey) - cost);
        PlayerPrefs.SetInt(coinsPlayerPrefKey, PlayerPrefs.GetInt(coinsPlayerPrefKey) + amountToBuy);
    }

    // Can be purchased via IAP
    public void BuyDiamonds(int amountToBuy)
    {
        PlayerPrefs.SetInt(diamondsPlayerPrefKey, PlayerPrefs.GetInt(diamondsPlayerPrefKey) + amountToBuy);
    }

    // Can be purchased via coins
    public void BuyBoosts(int amountToBuy, int cost)
    {
        PlayerPrefs.SetInt(coinsPlayerPrefKey, PlayerPrefs.GetInt(coinsPlayerPrefKey) - cost);
        PlayerPrefs.SetInt(BoostsPlayerPrefKey, PlayerPrefs.GetInt(BoostsPlayerPrefKey) + amountToBuy);
    }

    // Can be purchased via coins
    public void BuyHeadStart(int amountToBuy, int cost)
    {
        PlayerPrefs.SetInt(coinsPlayerPrefKey, PlayerPrefs.GetInt(coinsPlayerPrefKey) - cost);
        PlayerPrefs.SetInt(HeadStartPlayerPrefKey, PlayerPrefs.GetInt(HeadStartPlayerPrefKey) + amountToBuy);
    }

    // Can be purchased via coins
    public void BuyMysteryBox(int amountToBuy, int cost)
    {
        PlayerPrefs.SetInt(coinsPlayerPrefKey, PlayerPrefs.GetInt(coinsPlayerPrefKey) - cost);
        PlayerPrefs.SetInt(MysteryBoxPlayerPrefKey, PlayerPrefs.GetInt(MysteryBoxPlayerPrefKey) + amountToBuy);
    }

    public void PurchaseCoins()
    {
        BuyCoins(coinsAmountToAdd, coinsCostInDiamonds);
    }

    public void PurchaseDiamonds()
    {
        BuyDiamonds(diamondsAmountToAdd);
    }

    public void PurchaseBoosts()
    {
        BuyBoosts(boostAmountToAdd, boostAmountCostInCoins);
    }


    public void PurchaseHeadStart()
    {
        BuyHeadStart(headStartAmountToAdd, headStartCostInCoins);
    }

    public void PurchaseMysteryBox()
    {
        BuyMysteryBox(mysteryBoxAmountToAdd, mysteryBoxCostInCoins);
    }
}
