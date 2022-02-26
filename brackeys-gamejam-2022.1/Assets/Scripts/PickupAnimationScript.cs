using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAnimationScript : MonoBehaviour
{
    public bool upDown = true;
    public float upDownScale = 0.5f;
    Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (upDown)
        {
            transform.position = startPosition + new Vector3( 0.0f, Mathf.Sin(Time.time)*upDownScale, 0.0f);
        }
    }

    
}
