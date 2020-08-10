using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PickupSpawner : MonoBehaviour
{
    public GameObject[] pickupPrefabs;

    public float timerDelayMin = 2.0f;
    public float timerDelayMax = 10.0f;

    public int numPickups = 10;

    [SerializeField]
    private float timerDelay;

    [SerializeField]
    private List<Pickup> spawnedPickups = new List<Pickup>();
    
    private Collider colliderBox;

    private float xMin;
    private float xMax;
    private float zMin;
    private float zMax;

    private float yDefault;

    

    void Awake()
    {
        colliderBox = GetComponent<Collider>();
    }

    private void Start()
    {

        if (pickupPrefabs.Length == 0)
        {
            Debug.Log ("pickupPrefabs is empty");
            return;
        }
        xMin = colliderBox.bounds.min.x;
        xMax = colliderBox.bounds.max.x;
        zMin = colliderBox.bounds.min.z;
        zMax = colliderBox.bounds.max.z;

        yDefault = this.transform.position.y;

        /*
        for (int i = 0; i < numPickups; i++)
        {
            SpawnPickup();
        }
        //*/


        StartTimer();



    }


    private void SpawnPickup()
    {
        // if less than max num of objects to spawn
        if (spawnedPickups.Count < numPickups || numPickups == -1)
        {
            RandomPickup();
        }
        else
        {
            Debug.Log("Max number of pickups spawned!");
        }

        StartTimer();
    }

    private void RandomPickup()
    {

        float xRandPos = Random.Range(xMin, xMax);
        float zRandPos = Random.Range(zMin, zMax);

        Vector3 spawnPt = new Vector3(xRandPos, yDefault, zRandPos);

        int pickupIndex = Random.Range(0, pickupPrefabs.Length);
        Debug.Log("pickupIndex: " +pickupIndex);

        GameObject pickupPrefab = pickupPrefabs [pickupIndex];

        GameObject spawnedPrefab = Instantiate(pickupPrefab, spawnPt, pickupPrefab.transform.rotation);

        Pickup spawnedPickup = spawnedPrefab.GetComponent<Pickup>();

        if (spawnedPickup == null)
        {
            Debug.Log(spawnedPrefab.name + " is MISSING Pickup script!");
            return;
        }

        // buddy system
        spawnedPickup.spawner = this;

        spawnedPickups.Add(spawnedPickup);

        
    }

    private void RandomizeDelay()
    {
        timerDelay = Random.Range(timerDelayMin, timerDelayMax);
    }

    private void StartTimer()
    {
        RandomizeDelay();
        Invoke("SpawnPickup", timerDelay);

    }

    public void RemovePickup(Pickup pickupToRemove)
    {
        bool success = spawnedPickups.Remove(pickupToRemove);
        if (!success)
        {
            Debug.Log("Removal of " + pickupToRemove.name + " FAILED!!!");
        }
    }


    /*
    // Update is called once per frame
    void Update()
    {

    }
    */
}

