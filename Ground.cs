using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CollectPoints")
        {
            Debug.Log("Collision");
            Pickup pickup = collision.gameObject.GetComponent<Pickup>();

            if (pickup == null)
            {
                Debug.Log(collision.gameObject.name + " is MISSING Pickup script!");
                return;
            }

            if (pickup.willSelfDestruct)
            {
                //Destroy(collision.gameObject);
                pickup.Remove();
            }
            else
            {
                pickup.isFalling = false;
            }
        }

        else if (collision.gameObject.tag == "Rock")
        {
            Debug.Log("Collision");
            Pickup pickup = collision.gameObject.GetComponent<Pickup>();

            if (pickup == null)
            {
                Debug.Log(collision.gameObject.name + " is MISSING Pickup script!");
                return;
            }

            if (pickup.willSelfDestruct)
            {
                //Destroy(collision.gameObject);
                pickup.Remove();
            }
            else
            {
                pickup.isFalling = false;
            }
        }
    }
}
