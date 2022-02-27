using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    TODO: split player Movement and Player Controller seperatly ??
 */

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
    public Slider xraySlider;

    public bool playerDead = false;
    AudioSource playerAS;
    AudioListener audioListener;
    GameObject playerBase;

    SpriteRenderer spriteRenderer;
    public int health = 3;
    //HealthbarController healthbarControler;
    PlayerAudio pAudio;
    bool playerRolling;
    float velocityPositive;
    public float rollingSpeed = 6f;
    public bool gameStarted = false;
    GameObject a;

    void Start()
    {
        this.rigi = this.gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        playerAS = gameObject.GetComponent<AudioSource>();
        audioListener = gameObject.GetComponent<AudioListener>();
        audioListener.enabled = false;

        xraySlider = GameObject.Find("XrayBar").transform.GetChild(0).GetComponent<Slider>();

        playerBase = transform.GetChild(0).gameObject;
        //healthbarControler = GameObject.Find("Healthbar").GetComponent<HealthbarController>();
        pAudio = gameObject.GetComponent<PlayerAudio>();

        a = GameObject.Find("playerGlasses");
        Debug.Log(a.name);
       
    }

    // Update is called once per frame
    void Update()
    {
        a.SetActive(true);
        velocityPositive = rigi.velocity.x < 0 ? (rigi.velocity.x * -1f) : rigi.velocity.x;
        

        if (health == 0 && !playerDead)
        {
            playerAS.PlayOneShot(pAudio.audioArray[1]); //hit sound
            playerAS.Play(); //death sound
            playerDead = true;
            
        }

        if (Input.anyKey)
        {
            audioListener.enabled = true;
        }

        if (!playerDead && gameStarted)
        {
            horizontalMove = Input.GetAxis("Horizontal") * movementSpeed;
            
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
            //Debug.DrawRay(transform.position, -Vector2.up, Color.green);

            if (hit.collider != null)
            {
                //Debug.Log(hit.point);
            }

            //if (xrayUsed)
            //{
            //    xrayCooldown += Time.deltaTime;
            //    if (xrayCooldown > 2)
            //    {
            //        xrayUsed = false;
            //        xrayCooldown = 0f;
            //        spriteRenderer.enabled = true;
            //    }
            //}

            if (Input.GetKeyDown("w") && jumpAllowed)
            {
                jumpAllowed = false;
                playerAS.PlayOneShot(pAudio.audioArray[0], 0.2f); //jumping sound
                rigi.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);


            }           
            else if (Input.GetKey("m"))
            {
                if (xraySlider.value > 0)
                {
                    xrayUsed = true;
                    xraySlider.value -= Time.deltaTime;
                }
                else
                {
                    xrayUsed = false;
                }
                
            }
            else if (Input.GetKeyUp("m"))
            {
                xrayUsed = false;
            }
            else if(velocityPositive < 0.02f && (Input.GetKey("a") || Input.GetKey("d")))
            {
                playerRolling = true;
                playerAS.clip = pAudio.audioArray[3];               
                playerAS.loop = true;
                playerAS.Play(); //jumping sound

            }
            else if (Input.GetKeyUp("a") || Input.GetKeyUp("d"))
            {
                
                   playerAS.clip = pAudio.audioArray[4]; //setting back to playerDead audio clip               
                   playerAS.loop = false;
                   playerAS.Stop(); //jumping sound
                   playerRolling = false;
                               
            }            
        }
        else
        {
            playerBase.transform.GetChild(2).gameObject.SetActive(false);
        }
        

    }
    void FixedUpdate()
    {
        if (!playerDead)
        {
            Vector2 a = new Vector2(horizontalMove + movementSpeed * Time.fixedDeltaTime, 0);
            rigi.AddForce(a);
            playerBase.transform.RotateAround(transform.position, Vector3.back, Input.GetAxis("Horizontal") * rollingSpeed );


        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {  
        jumpAllowed = true;
        

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 3;
            //healthbarControler.decreaseHealth(health,1);
        }
        else
        {
            playerAS.PlayOneShot(pAudio.audioArray[2],0.3f); //hitplatform sound
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spikes")
        {
            health-=3;
            //healthbarControler.decreaseHealth(health,1);
        }else if (collision.gameObject.tag == "Health")
        {
            Destroy(collision.gameObject);
            xraySlider.value += 1;
            playerAS.PlayOneShot(pAudio.audioArray[5]);                  


            //health++;
            //healthbarControler.increaseHealth(health, 1);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        jumpAllowed = false;
    }

}
