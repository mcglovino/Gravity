using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBox : MonoBehaviour {

    public Material skybox1;
    public Material skybox2;
    public Material skybox3;

    void Start () {
        //with ints max condition is exclusive
        int rand = Random.Range(0, 3);
        //Debug.Log(rand);
        switch (rand)
        {
            case 0:
                RenderSettings.skybox = skybox1;
                break;
            case 1:
                RenderSettings.skybox = skybox2;
                break;
            case 2:
                RenderSettings.skybox = skybox3;
                break;
        } 
    }
	
	void Update () {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            RenderSettings.skybox = skybox1;
            DynamicGI.UpdateEnvironment();
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            RenderSettings.skybox = skybox2;
            DynamicGI.UpdateEnvironment();
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            RenderSettings.skybox = skybox3;
            DynamicGI.UpdateEnvironment();
        }
    }
}
