using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBehaviour : MonoBehaviour
{
    private GameController gc;

    private Transform thisSpawnLocation;
    private PortalBehaviour otherPortal;

    // Use this for initialization
    void Start ()
    {
        gc = FindObjectOfType<GameController>();
        thisSpawnLocation = transform.Find("SpawnLocation").transform;
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    // ...
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "RigidBodyFPSController" && gc.TwoPortalsSpawned() )
        {
            Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
            float rbForceMagnitude = rb.velocity.magnitude;

            if (this == gc.GetPortal1() )
            {
                otherPortal = gc.GetPortal2();
            }
            else
            {
                otherPortal = gc.GetPortal1();
            }
            Transform otherSpawnLocation = otherPortal.thisSpawnLocation;
            col.gameObject.transform.position = otherSpawnLocation.position; // Spawning: updating position of entering gameobject.

            Vector3 rbForceDirectionWorld = -(otherSpawnLocation.forward);
            rb.AddForce(rbForceDirectionWorld * rbForceMagnitude * 10.0F, ForceMode.Impulse);
        }
    }
}