using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpin : MonoBehaviour {
    private Quaternion rotateAngal;
	// Use this for initialization
	void Start () {
        Time.timeScale = 0;
        rotateAngal = transform.rotation;
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(MyUpdate());
        }
        StartCoroutine(waitStart());

    }
    IEnumerator waitStart()
    {
        yield return new WaitForSeconds((float)0.1);
        rotateAngal *= Quaternion.AngleAxis(45, Vector3.right);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotateAngal, 12 * Random.Range(2.0f, 5.0f)
            * Time.deltaTime);
    }


    IEnumerator MyUpdate()
    {
        float timer = 0f;
        float time = 0f;
        while (timer < time)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        // Here do anything that needs be done after 5s
        enabled = false;
    }

}
