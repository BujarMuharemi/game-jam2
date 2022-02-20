using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigi;
    public float movementSpeed = 3.0f;
    float horizontalMove = 0f;
    bool jumpAllowed = false;
    public float jumpHeight = 3.0f;

    public float xrayCooldown = 0f;
    public bool xrayUsed = false;
    bool playerDead = false;

    SpriteRenderer spriteRenderer;
    public int health = 3;

    void Start()
    {
        this.rigi = this.gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            playerDead = true;
        }

        if (!playerDead)
        {
            horizontalMove = Input.GetAxis("Horizontal") * movementSpeed;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
            Debug.DrawRay(transform.position, -Vector2.up, Color.green);

            if (hit.collider != null)
            {
                //Debug.Log(hit.point);
            }

            if (xrayUsed)
            {
                xrayCooldown += Time.deltaTime;
                if (xrayCooldown > 2)
                {
                    xrayUsed = false;
                    xrayCooldown = 0f;
                    spriteRenderer.enabled = true;
                }
            }

            if (Input.GetKeyDown("space") && jumpAllowed)
            {
                jumpAllowed = false;
                rigi.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
            }
            else if (Input.GetKeyDown("e") && xrayCooldown == 0f)
            {
                xrayUsed = true;
                spriteRenderer.enabled = false;
            }
        }
        

    }
    void FixedUpdate()
    {
        if (!playerDead)
        {
            Vector2 a = new Vector2(horizontalMove + movementSpeed * Time.fixedDeltaTime, 0);
            rigi.AddForce(a);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {  
        jumpAllowed = true;
        if (collision.gameObject.tag == "Bullet")
        {
            health--;
        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        jumpAllowed = false;
    }

}
