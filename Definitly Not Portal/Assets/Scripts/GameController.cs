using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameObject portal1;
    public static GameObject portal2;
    public int p1 = 0;
    public int p2 = 0;
    public static bool twoPortals = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(CreatePortal.portalSpawn == true)
        {
            if(p1 == 0)
            {
                portal1 = CreatePortal.portalClone;
                CreatePortal.portalSpawn = false;
                p1++;
            }
            else if(p2 == 0)
            {
                portal2 = CreatePortal.portalClone;
                CreatePortal.portalSpawn = false;
                twoPortals = true;
                p2++;
                
            }
            else
            {
                Destroy(portal1);
                portal1 = portal2;
                portal2 = CreatePortal.portalClone;
                CreatePortal.portalSpawn = false;
            }
        }
	}
}
