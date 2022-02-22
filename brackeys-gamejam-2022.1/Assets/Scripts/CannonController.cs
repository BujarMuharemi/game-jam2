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
            //creating the pos for the cannon, putting it 1f on the z axis so its behind the canonn
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, 1f);
            GameObject bullet = Instantiate(Bullet, pos, Quaternion.identity);            
            bulletTime = 0f;
        }
        
    }
}
