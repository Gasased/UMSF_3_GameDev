using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drive : MonoBehaviour
{

    [SerializeField]
    private float speed = 20;
    
    [SerializeField]
    private float steerSpeed = 45;

    private float forwardInput;
    private float horizontalInput;

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, steerSpeed * horizontalInput * Time.deltaTime);
    }
}
