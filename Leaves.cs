using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaves : MonoBehaviour
{
	public GameObject leavesPrefab;
    // Start is called before the first frame update
    void Start()
    {
    	Invoke("DropLeaves",2.0f);
        DropLeaves();
    }
    void DropLeaves()
    {
    	GameObject leaves = Instantiate <GameObject >(leavesPrefab);
    	leaves.transform.position = transform.position;
    	Invoke("DropLeaves",1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
