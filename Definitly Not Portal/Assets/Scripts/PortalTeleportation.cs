using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleportation : MonoBehaviour
{
    public GameObject spawnLocation;
    public GameObject teleportLocationGameObject;
    Rigidbody rb;

    public Vector3 contactPoint;
    public float offset;
    public Vector3 contactNormal;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "FPSController" && GameController.twoPortals == true)
        {
            rb = col.gameObject.GetComponent<Rigidbody>();
            float rbForceMagnitude = rb.velocity.magnitude;

            if (this.gameObject == GameController.portal1)
            {
                teleportLocationGameObject = GameController.portal2;
                spawnLocation = teleportLocationGameObject.transform.Find("SpawnLocation").gameObject;
                col.gameObject.transform.position = spawnLocation.transform.position;
                Vector3 rbForceDirectionWorld = -(teleportLocationGameObject.transform.forward);
                
                rb.AddForce(rbForceDirectionWorld * rbForceMagnitude, ForceMode.Force);
            }
            else
            {
                teleportLocationGameObject = GameController.portal1;
                spawnLocation = teleportLocationGameObject.transform.Find("SpawnLocation").gameObject;
                col.gameObject.transform.position = spawnLocation.transform.position;
                Vector3 rbForceDirectionWorld = -(teleportLocationGameObject.transform.forward);

                rb.AddForce(rbForceDirectionWorld * rbForceMagnitude, ForceMode.Force);
            }
        }
    }
}