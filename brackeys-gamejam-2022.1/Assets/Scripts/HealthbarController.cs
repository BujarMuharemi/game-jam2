using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthbarController : MonoBehaviour
{
    public Image[] images;
    
    public void decreaseHealth(int currentHealth, int healthPoints)
    {
        for(int i = currentHealth; i > currentHealth-healthPoints; i--)
        {
            images[i].enabled = false;
        }
    }

    public void increaseHealth(int currentHealth,int healthPoints)
    {
        Debug.Log((currentHealth - 1) + healthPoints);
        images[currentHealth-1].enabled = true;
    }
}
