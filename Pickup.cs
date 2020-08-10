using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

	public string pickupType;

    public int pointValue = 10;

	public float fallSpeed = 1;
	public float fallSpeedMin = 5;
	public float fallSpeedMax = 10;

    public bool willSelfDestruct = true;
    public bool isFalling = true;

    public PickupSpawner spawner;


	private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
    	fallSpeed = Random.Range(fallSpeedMin, fallSpeedMax);
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFalling)
        {
            float newY = pos.y - (fallSpeed * Time.deltaTime);

            transform.position = new Vector3(pos.x, newY, pos.z);

            pos = transform.position;
        }
        else
        {
            // check selfDestructCountdown

        }
    }

    public void Remove()
    {
        spawner.RemovePickup(this);
        Destroy(this.gameObject);
    }
}
