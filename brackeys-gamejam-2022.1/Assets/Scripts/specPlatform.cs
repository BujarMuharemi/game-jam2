using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specPlatform : MonoBehaviour
{
    GameController gc;
    SpriteRenderer spriteRenderer;
    float visibleTime = 5f;
    float countTimer = 0f;
    bool spriteEnabled = false;
    AudioSource hitPlatform;

    void Start()
    {
        gc = GameObject.Find("_GameController").GetComponent<GameController>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        hitPlatform = gameObject.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gc.xrayState)
        {
            spriteRenderer.enabled = true;
            spriteRenderer.color = setSpriteAlpha(1f, spriteRenderer.color);
        }

        //handling the sprite enable when the player touches the platform
        else if (spriteEnabled)
        {
            countTimer += Time.deltaTime;
            if (countTimer < visibleTime)
            {
                spriteRenderer.enabled = true;
                //decreasing the normalized alpha value                
                float alphaNormalized = (5f-countTimer-0f) / (5f-0f);                
                spriteRenderer.color = setSpriteAlpha(alphaNormalized, spriteRenderer.color);
            }
            else
            {
                spriteRenderer.enabled = false;
                spriteEnabled = false;
                countTimer = 0f;
            }
        }
        else
        {
            spriteRenderer.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            spriteEnabled = true;
            hitPlatform.Play();
        }
    }

    private Color setSpriteAlpha(float alpha,Color ogSpriteColor)
    {
        Color ogColor = ogSpriteColor;
        ogColor.a = alpha;
        return ogColor;
    }
}
