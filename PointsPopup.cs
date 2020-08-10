using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsPopup : MonoBehaviour
{
    private float lifeSpan = 0.5f;

    private float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SelfDestruct", lifeSpan);
    }

    private void SelfDestruct()
    {
        Destroy(this.gameObject);
    }

    
    // Update is called once per frame
    void Update()
    {
        float newY = transform.position.y + (moveSpeed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

    }
    
}
