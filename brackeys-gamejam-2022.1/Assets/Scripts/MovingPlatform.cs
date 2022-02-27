using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MovingPlatform : MonoBehaviour
{
    public float travalDistance = 1f;
    public float travelSpeed = 1f;
    Vector3 desiredPosition;
    public bool xAxis = true;
    public bool yAxis = false;
    

    void Start()
    {
        if (xAxis)
        {
            desiredPosition = new Vector3(transform.position.x + travalDistance, transform.position.y);
        }else if (yAxis)
        {
            desiredPosition = new Vector3(transform.position.x,transform.position.y + travalDistance );
        }
       
    }

 
    void Update()
    {
        Debug.DrawLine(transform.position, desiredPosition,Color.black,20f);
        Vector3 smoothedPosition = Vector3.MoveTowards(transform.position, desiredPosition, travelSpeed * Time.deltaTime);

        transform.position = smoothedPosition;


        if (xAxis)
        {
            if (Mathf.Abs(transform.position.x - desiredPosition.x) < 0.2f)
            {
                if (transform.position.x - desiredPosition.x < 0)
                {
                    desiredPosition.Set(desiredPosition.x -= travalDistance, desiredPosition.y, desiredPosition.z);
                }
                else
                {
                    desiredPosition.Set(desiredPosition.x += travalDistance, desiredPosition.y, desiredPosition.z);
                }
            }
        }
        else if (yAxis)
        {
            if (Mathf.Abs(transform.position.y - desiredPosition.y) < 0.2f)
            {
                if (transform.position.y - desiredPosition.y < 0)
                {
                    desiredPosition.Set(desiredPosition.x, desiredPosition.y -= travalDistance, desiredPosition.z);
                }
                else
                {
                    desiredPosition.Set( desiredPosition.x, desiredPosition.y += travalDistance, desiredPosition.z);
                }
            }
        }          
    }
}
