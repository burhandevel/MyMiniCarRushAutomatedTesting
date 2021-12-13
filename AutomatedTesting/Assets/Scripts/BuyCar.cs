using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyCar : MonoBehaviour
{

    int i = 0;

    string ModularPlayerPref = "MODULAR";
    string DynamoPlayerPref = "DYNAMO";
    string AlloyPlayerPref = "ALLOY";
    string TazionPlayerPref = "TAZION";

    int ModularCost = 100;
    int DynamoCost = 500;
    int AlloyCost = 1000;
    int TazionCost = 2000;


    string[] cars = { "Modular", "Dynamo", "Alloy", "Tazion" };
    public Text currentCar;
    public Text Coins;

    PopupHandler popupHandler;
    // Start is called before the first frame update
    void Start()
    {
        popupHandler = FindObjectOfType<PopupHandler>();
        if (!PlayerPrefs.HasKey(ModularPlayerPref))
        {
            PlayerPrefs.SetInt(ModularPlayerPref, 0);
        }

        if (!PlayerPrefs.HasKey(DynamoPlayerPref))
        {
            PlayerPrefs.SetInt(DynamoPlayerPref, 0);
        }

        if (!PlayerPrefs.HasKey(AlloyPlayerPref))
        {
            PlayerPrefs.SetInt(AlloyPlayerPref, 0);
        }

        if (!PlayerPrefs.HasKey(TazionPlayerPref))
        {
            PlayerPrefs.SetInt(TazionPlayerPref, 0);
        }

        //currentCar.text = cars[Random.Range(0, 4)];
        currentCar.text = cars[0];
        Coins.text = "Coins : " + PlayerPrefs.GetInt("COINS");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyCarMethod()
    {
        popupHandler.OpenThePopUp("AttemptedPurchase");
    }


    public void PurchaseCar()
    {
        string carName = currentCar.text.ToUpper();
        PlayerPrefs.SetInt(carName, 1);
        Debug.Log(carName + " Purchased");
        if (carName.Equals(ModularPlayerPref))
        {
            PlayerPrefs.SetInt("COINS", PlayerPrefs.GetInt("COINS") - ModularCost);
            Coins.text = "Coins : " + PlayerPrefs.GetInt("COINS");
        }
        else if (carName.Equals(DynamoPlayerPref))
        {
            PlayerPrefs.SetInt("COINS", PlayerPrefs.GetInt("COINS") - DynamoCost);
            Coins.text = "Coins : " + PlayerPrefs.GetInt("COINS");
        }
        else if (carName.Equals(AlloyPlayerPref))
        {
            PlayerPrefs.SetInt("COINS", PlayerPrefs.GetInt("COINS") - AlloyCost);
            Coins.text = "Coins : " + PlayerPrefs.GetInt("COINS");
        }
        else if (carName.Equals(TazionPlayerPref))
        {
            PlayerPrefs.SetInt("COINS", PlayerPrefs.GetInt("COINS") - TazionCost);
            Coins.text = "Coins : " + PlayerPrefs.GetInt("COINS");
        }
    }

    public void Right()
    {
        //currentCar.text = cars[i];
        if(i == 3)
        {
            currentCar.text = cars[3];
        }
        else
        {
            i++;
            currentCar.text = cars[i];
        }
    }

    public void Left()
    {
        //currentCar.text = cars[i];
        if (i == 0)
        {
            currentCar.text = cars[0];
        }
        else
        {
            i--;
            currentCar.text = cars[i];
        }
    }
}
