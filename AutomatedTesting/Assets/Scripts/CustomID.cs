using System.Collections.Generic;
using UnityEngine;

public class CustomID : MonoBehaviour
{
    public string testingID;
    public static CustomID testingInstance;

    private void Start()
    {
        testingInstance = this;
    }

    public GameObject GetGameObject(string id)
    {
        GameObject target = null;
        CustomID[] IDs = GameObject.FindObjectsOfType<CustomID>();
        foreach(CustomID ID in IDs)
        {
            if (ID.testingID.Equals(id))
            {
                target = ID.gameObject;
                break;
            }
        }
        return target;
    }
}
