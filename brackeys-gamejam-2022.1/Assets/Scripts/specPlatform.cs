using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specPlatform : MonoBehaviour
{
    GameController gc;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gc.xrayState)
        {
            spriteRenderer.enabled = true;
        }
        else
        {
            spriteRenderer.enabled = false;
        }
    }
}
