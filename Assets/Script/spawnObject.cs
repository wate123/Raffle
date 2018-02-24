using System.Collections;
using System;
using UnityEngine;

public class spawnObject : MonoBehaviour {
    public Rigidbody rb;
    public GameObject block1;
    Vector3 gravity;
    public float thrust;

    public int worldWidth;
    public int people;

    public float spawnSpeed = 0;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        StartCoroutine(CreateWorld());
        
    }

    IEnumerator CreateWorld()
    {
        for (int x = 0; x < worldWidth; x++)
        {
            yield return new WaitForSeconds(spawnSpeed);
            for (int z = 0; z < Math.Ceiling(Math.Sqrt(people)); z++)
            {
                GameObject block = Instantiate(block1, new Vector3(0+2*z,0,0), block1.transform.rotation) as GameObject;
                
                block.transform.parent = transform;
                block.transform.localPosition = new Vector3(x*1.1F, 0, z*1.1F);
            }
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.forward * thrust, ForceMode.Acceleration);
        Physics.gravity = gravity;

        if (Input.GetMouseButtonDown(0))
        {
            rb.isKinematic = false;
            rb.detectCollisions = true;
            gravity.x = 0;
            gravity.y = -20;
            gravity.z = 0;
        }
    }

}
