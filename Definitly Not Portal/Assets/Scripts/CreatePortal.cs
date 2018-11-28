using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePortal : MonoBehaviour
{

    private GameController gc;
    public GameObject portalObject;
    public float portalOffset = 0.01f;

    private ContactPoint contact; //The location the projectile collided with
    
    private GameObject newPortalSpawned;
    //public static bool portalSpawn = false;
    

    // Use this for initialization
    void Start()
    {
        gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "InnerCol")
        {
            contact = collision.contacts[0]; //Grab contact point and store it in the collision structure
            Quaternion rot = Quaternion.FromToRotation(Vector3.back, contact.normal); //Assign a rotation to it using the normal vector
            //Vector3 pos = contact.point; //Assign a vector3 position
            Vector3 pos = contact.point + (contact.normal * portalOffset);
            newPortalSpawned = Instantiate(portalObject, pos, rot);//Create object

            gc.SetNewPortal(newPortalSpawned.GetComponent<PortalBehaviour>());

            //Destroy(this.gameObject); //Destroy the bullet
            //portalSpawn = true;
        }
        Destroy(this.gameObject); //Destroy the bullet
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "ShootingCol" || col.name == "Portal(Clone)")
        {
            Destroy(this.gameObject);
        }
        
    }

}
