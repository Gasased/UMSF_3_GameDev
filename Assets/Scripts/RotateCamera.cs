using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5;
    private float horizontalInput;
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
