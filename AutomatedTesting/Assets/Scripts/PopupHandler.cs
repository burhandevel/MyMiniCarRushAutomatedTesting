using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupHandler : MonoBehaviour
{
    public GameObject[] Popups;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenThePopUp(string popupName)
    {
        foreach(GameObject popup in Popups)
        {
            if (popup.gameObject.name == popupName)
            {
                popup.SetActive(true);
            }
            else
            {
                popup.SetActive(false);
            }
        }
    }

    public void CloseThePopUp(string popupName)
    {
        foreach(GameObject popup in Popups)
        {
            if (popup.gameObject.name == popupName)
            {
                popup.SetActive(false);
            }
        }
    }
}
