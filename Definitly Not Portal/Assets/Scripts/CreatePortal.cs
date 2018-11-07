using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePortal : MonoBehaviour
{

    ContactPoint contact; //The location the projectile collided with
    public GameObject portalObject;
    public static GameObject portalClone;
    public static bool portalSpawn = false;
    public float portalOffset = 0.01f;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "InnerCol")
        {
            contact = collision.contacts[0]; //Grab contact point and store it in the collision structure
            Quaternion rot = Quaternion.FromToRotation(Vector3.back, contact.normal); //Assign a rotation to it using the normal vector
            //Vector3 pos = contact.point; //Assign a vector3 position
            Vector3 pos = contact.point + (contact.normal * portalOffset);
            portalClone = Instantiate(portalObject, pos, rot);//Create object

            //Destroy(this.gameObject); //Destroy the bullet
            portalSpawn = true;
        }
        Destroy(this.gameObject); //Destroy the bullet
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Portal(Clone)")
        {
            Destroy(this.gameObject);
        }
        
    }

}
