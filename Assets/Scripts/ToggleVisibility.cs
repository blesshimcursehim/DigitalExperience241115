using System.Collections.Generic;
using UnityEngine;

public class ToggleVisibility : MonoBehaviour
{
    public List<GameObject> objects; // List of objects to toggle visibility
    private int currentIndex = 0;

    void Start()
    {
        // Set all objects to inactive initially, except for the first one
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].SetActive(i == currentIndex);
        }
    }

    public void ToggleLeft()
    {
        // Deactivate the current object
        objects[currentIndex].SetActive(false);
        // Move to the previous index (wrap around if necessary)
        currentIndex = (currentIndex - 1 + objects.Count) % objects.Count;
        // Activate the new object
        objects[currentIndex].SetActive(true);
    }

    public void ToggleRight()
    {
        // Deactivate the current object
        objects[currentIndex].SetActive(false);
        // Move to the next index (wrap around if necessary)
        currentIndex = (currentIndex + 1) % objects.Count;
        // Activate the new object
        objects[currentIndex].SetActive(true);
    }
}
