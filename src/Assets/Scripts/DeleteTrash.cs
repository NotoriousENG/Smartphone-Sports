using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTrash : MonoBehaviour
{

    //Fetch the Animator
    //Animator m_Animator;
    // Use this for deciding if the GameObject can walk or not
    bool isColide;
    public AudioClip mySound;
    public Collider2D other;
    public Vector3 offset;

    // Use this for initialization
    void Start()
    {

        //This gets the Animator, which should be attached to the GameObject you are intending to animate.
        //m_Animator = gameObject.GetComponentInChildren<Animator>();
        // The GameObject cannot jump
        isColide = false;

        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = mySound;
    }

    // Update is called once per frame
    void Update()
    {
        OnTriggerEnter2D(other);
        if (isColide == true)
        {
            // m_Animator.SetBool("collide", true

            GetComponent<AudioSource>().Play();
            enabled = false;

            // move far behind in z
            transform.position = new Vector3(offset.x, offset.y, offset.z);

            return;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "trashbin")
        {
            //Debug.Log("Got Collision");
            isColide = true;
            // playerCollides with the Enemy
        }
        if (other.tag == "bad")
            isColide = true;
    }
}
