using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCar : MonoBehaviour
{
    PopupHandler popupHandler;
    // Start is called before the first frame update
    void Start()
    {
        popupHandler = FindObjectOfType<PopupHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyCarMethod()
    {
        popupHandler.OpenThePopUp("AttemptedPurchase");
    }
}
