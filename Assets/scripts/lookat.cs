using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookat : MonoBehaviour {

    public GameObject target;

    float minFov = 5f;
    float maxFov= 120f;
    //zoom sens
    float sensitivity = 15f;

    //looking around speed
    float speed = 150f;
    GameObject centerObj;

    void  Start() {
        centerObj = new GameObject();
        this.transform.parent = centerObj.transform;
    }

    void Update()
    {
        centerObj.transform.position = target.transform.position;

        if (Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2))
        centerObj.transform.Rotate(0.0f, (Input.GetAxis("Mouse X") * Time.deltaTime * speed), (-Input.GetAxis("Mouse Y") * Time.deltaTime * speed));

        //Rotate the camera every frame so it keeps looking at the target
        transform.LookAt(centerObj.transform.position);

        float fov = Camera.main.fieldOfView;
        fov -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }
}
