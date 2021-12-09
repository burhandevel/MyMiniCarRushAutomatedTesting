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

    string[] cars = { "Modular", "Dynamo", "Alloy", "Tazion" };
    public Text currentCar;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyCarMethod()
    {
        popupHandler.OpenThePopUp("AttemptedPurchase");
    }

    public void PurchaseModularCar()
    {
        if (PlayerPrefs.GetInt(ModularPlayerPref) == 0)
        {
            PlayerPrefs.SetInt(ModularPlayerPref, 1);
        }
    }

    public void PurchaseDynamoCar()
    {
        if (PlayerPrefs.GetInt(DynamoPlayerPref) == 0)
        {
            PlayerPrefs.SetInt(DynamoPlayerPref, 1);
        }
    }

    public void PurchaseAlloyCar()
    {
        if(PlayerPrefs.GetInt(AlloyPlayerPref) == 0)
        {
            PlayerPrefs.SetInt(AlloyPlayerPref, 1);
        } 
    }

    public void PurchaseTazionCar()
    {
        if (PlayerPrefs.GetInt(TazionPlayerPref) == 0)
        {
            PlayerPrefs.SetInt(TazionPlayerPref, 1);
        }
    }

    public void PurchaseCar()
    {
        //string currentCarString = currentCar.ToString();
        //currentCarString = cars[Random.Range(0, 5)];
        if(currentCar.text == "Modular")
        {
            PurchaseModularCar();
        }
        else if(currentCar.text == "Dynamo")
        {
            PurchaseModularCar();
        }
        else if(currentCar.text == "Alloy")
        {
            PurchaseAlloyCar();
        }
        else if (currentCar.text == "Tazion")
        {
            PurchaseTazionCar();
        }

        /*if (currentCarString.Equals("Modular"))
        {
            PurchaseModularCar();
        }
        else if (currentCarString.Equals("Dynamo"))
        {
            PurchaseDynamoCar();
        }
        else if (currentCarString.Equals("Alloy"))
        {
            PurchaseAlloyCar();
        }
        else if(currentCarString.Equals("Tazion"))
        {
            PurchaseTazionCar();
        }*/
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
