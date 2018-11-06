using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{

    public GameObject projectilePrefab = null; // Reference variable to the cannon ball prefab.

    public Transform spawnLocation = null; // Reference variable to the Transform component of the spawn location.

    public float projectileVelocity = 25.0F;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetMouseButtonDown(0))
        {

            GameObject projectileClone = null;

            Vector3 forceDir = spawnLocation.TransformDirection(Vector3.forward);
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, forceDir);
            projectileClone = Instantiate(projectilePrefab, spawnLocation.position, rot);

            //Set Game object to active
            projectileClone.SetActive(true);


            Rigidbody projectileRigidbody = projectileClone.GetComponent<Rigidbody>();
            projectileRigidbody.velocity = projectileRigidbody.transform.forward * projectileVelocity;

            Destroy(projectileClone, 5.0f);
        }
    }
}
