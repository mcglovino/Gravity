using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour {

    public Material skin1;
    public Material skin2;
    public Material skin3;
    public Material skin4;
    public Material skin5;
    public Material skin6;
    public Material skin7;
    public Material skin8;
    public Material skin9;

    public Rigidbody rb;
    const float Gravity = 667.4f;

    public static List<Attractor> Attractors;

    //if the planet is going to start moving towards the center, or too high up or down, readjust the path
    Vector3 rayc(Vector3 randT, int iT)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, randT);

        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log("Ray");
            if (hit.collider.name != "AngleR")
            {
                return randT;
            }
            else
            {
                iT += 1;
                if (iT < 10)
                {
                    //Debug.Log("AngleR");
                    randT = Random.onUnitSphere;
                    //recursion to keep trying randomly until it meets conditions, but will only tey a certain amount of times
                    //as is something spawns within the sphere later in the game, the loop cannot end.
                    randT = rayc(randT, iT);
                    ray = new Ray(transform.position, randT);
                    return randT;
                }
            }
        }
        return randT;
    }


    private void FixedUpdate()
    {
        //in each attractor in the attractor list
        foreach (Attractor attractor in Attractors)
        {
            if (attractor != this)
            {
                //attract it
                Attract(attractor);
            }
        }
    }

    void OnEnable()
    {
        //initialize list, if not already done
        if (Attractors == null)
        {
            Attractors = new List<Attractor>();
        }
        //whenever a planet is created it is registered to the attractors list
        Attractors.Add(this);

        //material
        if (this.gameObject.name != "big")
        {
            int skinRand = Random.Range(0, 9);
            switch (skinRand)
            {
                case 0:
                    this.GetComponent<Renderer>().material = skin1;
                    break;
                case 1:
                    this.GetComponent<Renderer>().material = skin2;
                    break;
                case 2:
                    this.GetComponent<Renderer>().material = skin3;
                    break;
                case 3:
                    this.GetComponent<Renderer>().material = skin4;
                    break;
                case 4:
                    this.GetComponent<Renderer>().material = skin5;
                    break;
                case 5:
                    this.GetComponent<Renderer>().material = skin6;
                    break;
                case 6:
                    this.GetComponent<Renderer>().material = skin7;
                    break;
                case 7:
                    this.GetComponent<Renderer>().material = skin8;
                    break;
                case 8:
                    this.GetComponent<Renderer>().material = skin9;
                    break;
            }
        }


        //initial force
        Vector3 rand = Random.onUnitSphere;
        int i = 1;
        rand = rayc(rand, i);

        if (this.name == "x small")
        {
            rb.AddForce(rand * Random.Range(0.2f, 0.1f), ForceMode.Impulse);
        }
        else if (this.name == "med")
        {
            rb.AddForce(rand * Random.Range(7000f, 5500f), ForceMode.Impulse);
        }
        else
        {
            rb.AddForce(rand * Random.Range(2500f, 1000f), ForceMode.Impulse);
        }    
    }

    void OnDisable()
    {
        //removes the object from list when disabled
        Attractors.Remove(this);
    }

 
    //maths for attraction
	void Attract (Attractor objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.rb;

        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        float forceMagnitude = Gravity*((rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2));
        Vector3 force = (direction.normalized * forceMagnitude) * Time.fixedDeltaTime;

        rbToAttract.AddForce(force);
    }

}
