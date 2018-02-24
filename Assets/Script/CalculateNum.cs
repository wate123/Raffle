using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateNum : MonoBehaviour {
    public int startNum = 1886923;
    public int endNum;
    public char[] charArr;
    public GameObject num;
    float speed = 0.1f;
    public bool switchs = false;

    public static Dictionary<int, UnityEngine.Object> objectList = new Dictionary<int, UnityEngine.Object>();
    private static UnityEngine.Object emptyObj;
    private static Vector3[] spawnPositions = new[] {new Vector3(-1245, -1096, -1520),
        new Vector3(-905,-1096,-1520), new Vector3(-552,-1096,-1520), new Vector3(-191, -1096, -1520),
        new Vector3(166, -1096, -1520),new Vector3(524, -1096, -1520),new Vector3(886, -1096, -1520)};

    public static void LoadAll(string pPath)
    {
        UnityEngine.Object[] ObjectArray = Resources.LoadAll(pPath);

        foreach (UnityEngine.Object o in ObjectArray)
            objectList.Add(o.name.GetHashCode(), (UnityEngine.Object)o);
    }

    public static UnityEngine.Object getPrefab(string objName)
    {
        UnityEngine.Object obj;

        if (objectList.TryGetValue(objName.GetHashCode(), out obj))
            return obj;
        else
        {
            Debug.Log("Object not found");
            return (emptyObj);
        }
    }

    public static void ShuffleArray<T>(T[] arr)
    {
        for (int i = arr.Length - 1; i > 0; i--)
        {
            int r = UnityEngine.Random.Range(0, i);
            T tmp = arr[i];
            arr[i] = arr[r];
            arr[r] = tmp;
        }
    }

    void CreateWorld()
    {
        int count = -4;
        //yield return new WaitForSeconds(speed);
            for (int z = 0; z < 7; z++)
            {
                //yield return new WaitForSeconds(speed);
             GameObject block = Instantiate(getPrefab(charArr[z].ToString()), new Vector3(-4, 0, (float)-4.8), num.transform.rotation) as GameObject;
            block.transform.parent = transform;
             block.transform.localScale = new Vector3(18 , 18, 18);
             block.transform.localPosition = new Vector3(count, 0, (float)-4.8);
            count += 14;
            switchs = true;

        }
    }

    void random()
    {
        int size = endNum - startNum;
        string[] arr = new string[size];
        for (int i = 0; i < size; i++)
        {
            arr[i] = (startNum ++).ToString();
        }
        ShuffleArray(arr);
        string ranNum = arr[(int)UnityEngine.Random.Range(0f, (float)size)];
        charArr = ranNum.ToCharArray();
    }
    // Use this for initialization
    void Start () {
        random();
        LoadAll("prefab");
        
        
    }

	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateWorld();
        }
    }
}
