using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLimiter : MonoBehaviour
{
    public float maxSpeed = 100f;
    private Rigidbody rigidbody;

    // Use this for initialization
    void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (rigidbody.velocity.magnitude > maxSpeed)
        {
            //rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxSpeed);
            rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
        }
    }
}
