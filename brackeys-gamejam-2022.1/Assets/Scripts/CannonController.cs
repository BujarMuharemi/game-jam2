using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject Bullet;
    public float bulletShootingTime = 1f;
    float bulletTime = 1f;

    
    void Start()
    {
        
    }
    void Update()
    {
        bulletTime += Time.deltaTime;
        if(bulletTime > bulletShootingTime)
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);           
            bulletTime = 0f;
        }
        
    }
}
