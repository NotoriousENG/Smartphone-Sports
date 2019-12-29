using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : MonoBehaviour {
    public GameObject patroller;
    public float speed;
    public bool flip;
    public float wait;

    // Use this for initialization
    void Start () {
        if (flip)
        {
            Vector3 newScale = patroller.transform.localScale;
            newScale.x *= -1;
            patroller.transform.localScale = newScale;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(flip)
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Edge")
        {
            Debug.Log("Did it!");

            if (wait + .5 <= Time.timeSinceLevelLoad)
            {
                flip = !flip;
                Vector3 newScale = patroller.transform.localScale;
                newScale.x *= -1;
                patroller.transform.localScale = newScale;
                wait = Time.timeSinceLevelLoad;
            }
            
                
            
        }
    }
    }
