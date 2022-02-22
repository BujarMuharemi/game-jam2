using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationAnimation : MonoBehaviour
{
    public float RotationSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * (RotationSpeed * Time.deltaTime));
    }
}
