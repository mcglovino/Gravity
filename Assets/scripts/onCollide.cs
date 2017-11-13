using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollide : MonoBehaviour {



	void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag != "DontDestroy" && col.gameObject.name != "big")
        {
            if (this.gameObject.activeSelf)
            {
                //with ints max condition is exclusive
                int rand = Random.Range(0, 4);
                //breaks the pieces up, 1/4 chance
                if (rand == 0)
                {
                    if (this.gameObject.name != "big")
                    {
                        Vector3 pos = this.transform.position;
                        float mass = this.GetComponent<Rigidbody>().mass;
                        float colmass = col.gameObject.GetComponent<Rigidbody>().mass;

                        col.gameObject.SetActive(false);
                        Destroy(col.gameObject);
                        this.gameObject.SetActive(false);
                        Destroy(this.gameObject);

                        //breaks into pieces of mass equal to the origional pieces
                        //the plus 50 is the mass of the xsmall prefab
                        for (int i = 0; i < mass + colmass; i += 50)
                        {
                            Instantiate(Resources.Load("x small"), (pos + new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f))), Quaternion.identity);
                        }
                    }
                    else
                    {
                        //the sun doesnt split, so it will absorb instead
                        rand = 2;
                    }
                }
                //merges them, 1/4 chance
                if (rand > 0)
                {
                    //I have the sun set to be twice as dense as other obects, so it doesnt rapidly increase in size as much
                    if (this.gameObject.name == "big")
                    {
                        this.GetComponent<Rigidbody>().mass += col.gameObject.GetComponent<Rigidbody>().mass/2;
                        this.transform.localScale += (col.gameObject.transform.localScale/4);
                        col.gameObject.SetActive(false);
                        Destroy(col.gameObject);
                    }
                    else
                    {
                        this.GetComponent<Rigidbody>().mass += col.gameObject.GetComponent<Rigidbody>().mass;
                        this.transform.localScale += (col.gameObject.transform.localScale);
                        col.gameObject.SetActive(false);
                        Destroy(col.gameObject);
                    }
                }
            }
        }
        else if(col.gameObject.name == "plane")
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
