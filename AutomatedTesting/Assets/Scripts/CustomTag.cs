using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTag : MonoBehaviour
{
    public string testingTag;
    public static CustomTag testingTagInstance;

    private void Start()
    {
        testingTagInstance = this;
    }

    public List<GameObject> GetGameObjectsList(string tag)
    {
        List<GameObject> targets = new List<GameObject>();
        CustomTag[] Tags = GameObject.FindObjectsOfType<CustomTag>();
        foreach(CustomTag Tag in Tags)
        {
            if (Tag.testingTag.Equals(tag))
            {
                targets.Add(Tag.gameObject);
            }
        }
        return targets;
    }
}
