using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class twoDimensionalAnimationStateController : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    float velocityZ = 0.0f;
    float velocityX = 0.0f;
    public float acceleration = 2.0f;
    public float deceleration = 2.0f;

    void Start()
    {
        animator = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey("w");
        bool leftPressed = Input.GetKey("a");
        bool rightPressed = Input.GetKey("d");
        bool runPressed = Input.GetKey("left shift");

        // move forward
        if (forwardPressed && velocityZ < 0.5f)
        {
            velocityZ += Time.deltaTime * acceleration;
        }

        // incraese vel in left
        if (leftPressed && velocityX > -0.5f && !runPressed)
        {
            velocityX -= Time.deltaTime * acceleration;
        }
            
        // increase vel in right
        if (rightPressed && velocityX < 0.5f && !runPressed)
        {
            velocityX += Time.deltaTime * acceleration;
        }

        // decrease velZ
        if (!forwardPressed && velocityZ > 0.0f)
        {
            velocityZ -= Time.deltaTime * deceleration;
        }

        // reset velZ (if decel overshoots)
        if (!forwardPressed && velocityZ < 0.0f)
        {
            velocityZ = 0.0f;
        }

        // if velX if left is not forwardPressed 
        if (!leftPressed && velocityX < 0.0f)
        {
            velocityX += Time.deltaTime * deceleration;
        }

        // if velX if left is not forwardPressed 
        if (!rightPressed && velocityX > 0.0f)
        {
            velocityX -= Time.deltaTime * deceleration;
        }

        // reset velX
        if (!leftPressed && !rightPressed && velocityX != 0.0f && (velocityX > -0.05f && velocityX < 0.05f))
        {
            velocityX = 0.0f;
        }



        animator.SetFloat("Velocity Z", velocityZ);
        animator.SetFloat("Velocity X", velocityX);
    }
}
