using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObject : MonoBehaviour {
    public GameObject gold;

    enum ModeSwitching { Start, Acceleration };
    ModeSwitching m_ModeSwitching;

    Vector3 m_StartPos, m_StartForce;
    Vector3 m_NewForce;
    Rigidbody m_Rigidbody;

    public float gridX = 5f;
    public float gridY = 5f;
    public float spacing = 2f;
    string m_ForceXString, m_ForceYString;
    float m_ForceX, m_ForceY;
    float m_Result;

    private void spawn()
    {
        for (int y = 0; y < gridY; y++)
        {
            for (int x = 0; x < gridX; x++)
            {
                Vector3 pos = new Vector3(x, 0, y) * spacing;
                Instantiate(gold, pos, Quaternion.identity);
            }
        }
    }

    private void Start()
    {
        spawn();
    }
    private void Update()
    {
        //If the current mode is not the starting mode (or the GameObject is not reset), the force can change
        if (m_ModeSwitching != ModeSwitching.Start)
        {
            //The force changes depending what you input into the text fields
            m_NewForce = new Vector3(m_ForceX, m_ForceY, 0);
        }

        //Here, switching modes depend on button presses in the Game mode
        switch (m_ModeSwitching)
        {
            //This is the starting mode which resets the GameObject
            case ModeSwitching.Start:
                //This resets the GameObject and Rigidbody to their starting positions
                transform.position = m_StartPos;
                m_Rigidbody.transform.position = m_StartForce;
                //This resets the velocity of the Rigidbody
                m_Rigidbody.velocity = new Vector3(0f, 0f, 0f);
                break;

            //These are the modes ForceMode can force on a Rigidbody
            //This is Acceleration mode
            case ModeSwitching.Acceleration:
                //The function converts the text fields into floats and updates the Rigidbody’s force
                MakeCustomForce();
                //Use Acceleration as the force on the Rigidbody
                m_Rigidbody.AddForce(m_NewForce, ForceMode.Acceleration);
                break;
        }
    }

    void OnGUI()
    {
        //Getting the inputs from each text field and storing them as strings
        m_ForceXString = GUI.TextField(new Rect(300, 10, 200, 20), m_ForceXString, 25);
        m_ForceYString = GUI.TextField(new Rect(300, 30, 200, 20), m_ForceYString, 25);

        //Press the button to reset the GameObject and Rigidbody
        if (GUI.Button(new Rect(100, 0, 150, 30), "Reset"))
        {
            //This switches to the start/reset case
            m_ModeSwitching = ModeSwitching.Start;
        }

        //When you press the Acceleration button, switch to Acceleration mode
        if (GUI.Button(new Rect(100, 30, 150, 30), "Apply Acceleration"))
        {
            //Switch to Acceleration (apply acceleration force to GameObject)
            m_ModeSwitching = ModeSwitching.Acceleration;
        }
    }

    //Changing strings to floats for the forces
    float ConvertToFloat(string Name)
    {
        float.TryParse(Name, out m_Result);
        return m_Result;
    }

    //Set the converted float from the text fields as the forces to apply to the Rigidbody
    void MakeCustomForce()
    {
        //This converts the strings to floats
        m_ForceX = ConvertToFloat(m_ForceXString);
        m_ForceY = ConvertToFloat(m_ForceYString);
    }

}
