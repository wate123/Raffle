using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchMesh : MonoBehaviour {
    CalculateNum cal = new CalculateNum();

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
	}
}
