using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float bulletSpeed = 5f;
    float bulleKillTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulleKillTimer += Time.deltaTime;
        if (bulleKillTimer > 3f)
        {
            Destroy(gameObject);
        }
        transform.position = transform.position + Vector3.up*Time.deltaTime* bulletSpeed;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("bullet hit");
        Destroy(gameObject);
    }
}
