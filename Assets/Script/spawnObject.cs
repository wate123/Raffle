using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class spawnObject : MonoBehaviour {
    public Rigidbody rb;
    public GameObject block1;
    Vector3 gravity;

    public int worldWidth = 40;
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
                GameObject block = Instantiate(block1, Vector3.zero, block1.transform.rotation) as GameObject;
                block.transform.parent = transform;
                block.transform.localPosition = new Vector3(x*1.1F, 0, z*1.1F);
            }
        }
    }

    void Update()
    {
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
