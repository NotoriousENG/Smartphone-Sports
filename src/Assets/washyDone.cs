using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class washyDone : MonoBehaviour
{

    public GameObject doneObj;
    public GameObject washy2;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Washy")
        {
            //Debug.Log("Got my Collision");
            Destroy(other.gameObject);
            washy2.SetActive(true);
            // playerCollides with the Enemy
        }


    }
}
