using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doooon : MonoBehaviour
{
    // Reference to the GameObjects, no direct Rigidbody2D references needed
    public GameObject circle1;
    public GameObject circle2;
    public GameObject circle3;

    void Update()
    {
        if (transform.position.y > 1.74f)
        {
            ApplyGravityScale(-1);
        }
        if(transform.position.y > 10.0f)
        {
            ApplyDestroy();
        }
    }

    void ApplyGravityScale(float scale)
    {
        // Get and set the Rigidbody2D gravityScale for each circle directly
        if(circle1) circle1.GetComponent<Rigidbody2D>().gravityScale = scale;
        if(circle2) circle2.GetComponent<Rigidbody2D>().gravityScale = scale;
        if(circle3) circle3.GetComponent<Rigidbody2D>().gravityScale = scale;
    }

    void ApplyDestroy()
    {
        // Destroy the GameObjects
        Destroy(circle1);
        Destroy(circle2);
        Destroy(circle3);
    }
}
