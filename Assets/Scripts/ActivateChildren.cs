using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateChildren : MonoBehaviour
{
    private List<GameObject> childObjects;
    private int currentIndex = 0;

    void Start()
    {
        childObjects = new List<GameObject>();
        foreach (Transform child in transform)
        {
            childObjects.Add(child.gameObject);
            child.gameObject.SetActive(false); // Deactivate all child objects on start
        }

        ActivateNextChild();
    }

    public void ActivateNextChild()
    {
        if (currentIndex < childObjects.Count)
        {
            childObjects[currentIndex].SetActive(true);
            currentIndex++;
        }
    }
}
