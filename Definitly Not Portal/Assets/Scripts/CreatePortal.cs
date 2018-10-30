using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePortal : MonoBehaviour
{

    ContactPoint contact; //The location the projectile collided with
    public GameObject portalObject;
    public GameObject portalClone;

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
            Vector3 pos = contact.point; //Assign a vector3 position
            portalClone = Instantiate(portalObject, pos, rot);//Create object
            portalClone.SetActive(true);//Turn on the game object
            Destroy(this.gameObject); //Destroy the bullet
        }
        else if(collision.gameObject.tag == "OuterCol") //Portal cannot be spawned
        {
            Destroy(this.gameObject); //Destroy the bullet
        }
    }
}
