using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSelector : MonoBehaviour
{
    // List to hold the game objects
    public List<GameObject> gameObjects;

    // Function to return a random game object from the list
    public GameObject GetRandomObject()
    {
        int randomIndex = Random.Range(0, gameObjects.Count);
        return gameObjects[randomIndex];
    }
}
