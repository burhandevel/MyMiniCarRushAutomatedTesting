using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggered : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (CustomID.testingInstance.GetGameObject("playerCar").name == "Player" && this.gameObject.tag.Equals("PickupCoin"));
        {
            this.gameObject.SetActive(false);
            PlayerPrefs.SetInt("COINS", PlayerPrefs.GetInt("COINS") + 1);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
