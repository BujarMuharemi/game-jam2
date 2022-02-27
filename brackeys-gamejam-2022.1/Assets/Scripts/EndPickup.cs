using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPickup : MonoBehaviour
{
    public bool gameWon = false;   

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            gameWon = true;
        }
    }
}
