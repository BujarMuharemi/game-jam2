using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableSound : MonoBehaviour
{
    AudioSource audioSource;
    float velocityPositive;
    Rigidbody2D rigidbody;
    bool playerTouched;
    bool playingSound;
    void Start()
    {        
        audioSource = gameObject.GetComponent<AudioSource>();
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {   
        //making the velocity in body directions positive
        velocityPositive = rigidbody.velocity.x < 0 ? (rigidbody.velocity.x * -1f) : rigidbody.velocity.x;
        
        if (velocityPositive < 0.2f )
        {
            audioSource.Stop();
            playerTouched = false;
            playingSound = false;
        }
        else if(playerTouched && !playingSound)
        {
            audioSource.Play();
            playingSound = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            playerTouched = true;         
        }

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        audioSource.loop = true;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerTouched = false;
            playingSound = false;
            audioSource.Stop();
        }

    }
}
