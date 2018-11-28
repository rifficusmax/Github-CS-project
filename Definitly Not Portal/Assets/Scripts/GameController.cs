using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private PortalBehaviour portal1;
    private PortalBehaviour portal2;
    private int numPortals;

	// Use this for initialization
	void Start ()
    {
        numPortals = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    // Function to be called by the bullet, right after a new portal has been spawned.
    //      newPortal: reference to the GameObject of the newly spawned portal.
    public void SetNewPortal(PortalBehaviour newPortal)
    {
        if (newPortal != null)
        {
            if (numPortals == 0)
            {
                portal1 = newPortal;
                numPortals = 1;
            }
            else if (numPortals == 1)
            {
                portal2 = newPortal;
                numPortals = 2;
                SetPortalsVisuals();
            }
            else
            {
                Destroy(portal1.gameObject);
                portal1 = portal2;
                portal2 = newPortal;
                SetPortalsVisuals();
            }
        }
    }

    // ...
    public PortalBehaviour GetPortal1() { return portal1; }

    // ...
    public PortalBehaviour GetPortal2() { return portal2; }

    // ...
    public bool TwoPortalsSpawned() { return numPortals == 2; }

    // Function to configure materials and render textures of both portals.
    private void SetPortalsVisuals() { }

}


