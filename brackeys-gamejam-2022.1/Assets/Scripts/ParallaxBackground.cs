using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField]private Vector2 parallaxEffectMultiplier;
    private Transform cameraTransform;
    private Vector3 lastCamPos;
    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCamPos = cameraTransform.position;
    }

    
    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCamPos;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y,deltaMovement.z);
        lastCamPos = cameraTransform.position;
    }
}
