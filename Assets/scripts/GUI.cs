using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI : MonoBehaviour {

    public float gameSpeed = 1.0f;
    public GameObject GUIObj;
    bool active = true;

    public Mesh low;
    public Mesh med;
    public Mesh high;

    void Start()
    {
        foreach (Attractor attractor in Attractor.Attractors)
        {
            attractor.GetComponent<MeshFilter>().mesh = med;
            attractor.GetComponent<SphereCollider>().radius = 0.72f;
        }
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
        //Time.fixedDeltaTime = 2.0f;

        if(Input.GetKeyDown(KeyCode.M))
        {
            if (active == true)
            {
                active = false;
                GUIObj.SetActive(false);
            }
            else
            {
                active = true;
                GUIObj.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void AdjustSpeed(float SpeedT)
    {
        gameSpeed = SpeedT;
    }

    public void Small()
    {
        for (int i = 1; i <= 10; i++)
        {
            Instantiate(Resources.Load("x small"), (new Vector3(Random.Range(-1000.0f, 100.0f), Random.Range(-500.0f, 500.0f), Random.Range(-1000.0f, 1000.0f))), Quaternion.identity);
        }
    }
    public void Medium()
    {
        for (int i = 1; i <= 10; i++)
        {
            Instantiate(Resources.Load("small"), (new Vector3(Random.Range(-1000.0f, 100.0f), Random.Range(-500.0f, 500.0f), Random.Range(-1000.0f, 1000.0f))), Quaternion.identity);
        }
    }
    public void Large()
    {
        for (int i = 1; i <= 10; i++)
        {
            Instantiate(Resources.Load("med"), (new Vector3(Random.Range(-1000.0f, 100.0f), Random.Range(-500.0f, 500.0f), Random.Range(-1000.0f, 1000.0f))), Quaternion.identity);
        }
    }
    public void lowQ()
    {
        foreach (Attractor attractor in Attractor.Attractors)
        {
            attractor.GetComponent<MeshFilter>().mesh = low;
            attractor.GetComponent<SphereCollider>().radius = 0.68f;
        }
    }
    public void medQ()
    {
        foreach (Attractor attractor in Attractor.Attractors)
        {
            attractor.GetComponent<MeshFilter>().mesh = med;
            attractor.GetComponent<SphereCollider>().radius = 0.72f;
        }
    }
    public void highQ()
    {
        foreach (Attractor attractor in Attractor.Attractors)
        {
            attractor.GetComponent<MeshFilter>().mesh = high;
            attractor.GetComponent<SphereCollider>().radius = 0.74f;
        }
    }
}