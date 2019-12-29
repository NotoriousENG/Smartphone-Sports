using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {

    public GameObject Car;
    public Vector3 offset;
    public float speed;
    public bool vertical;
    public bool opposite;
    public bool usingAudio;

    public AudioClip boom;    // Add your Audi Clip Here;

    // Use this for initialization
    void Start () {
        if(usingAudio)
        {
            GetComponent<AudioSource>().playOnAwake = false;
            GetComponent<AudioSource>().clip = boom;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //Repos();
        if (!vertical)
            moveForward();
        if (vertical)
            moveVertical();
        
    }
    
    void moveForward()
    {
        transform.Translate(Vector3.right * Time.deltaTime *  speed);
    }
    void moveVertical()
    {
        if(!opposite)
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        if(opposite)
            transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "CarBar")
        {
            //Debug.Log("Got my Collision");
            Car.transform.position = new Vector3(offset.x, offset.y, offset.z);
            // playerCollides with the Enemy
        }
        if (other.tag == "bad" && usingAudio)
        {
            GetComponent<AudioSource>().Play();
            Debug.Log("Works");
            Destroy(other.gameObject);
        }
        
    }
}
