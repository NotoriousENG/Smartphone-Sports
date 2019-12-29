using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopNotification : MonoBehaviour {

    //Fetch the Animator
    Animator m_Animator;
    // Use this for deciding if the GameObject can walk or not
    bool isPresent;
    public AudioClip mySound;
    public GameObject player;
    public Text myText;
    //public int mySize;
    public string[] array = new string[3];
    public int[] actvateXPos = new int[3];
    float timeSince;
    int i = 0;


    // Use this for initialization
    void Start () {
        //This gets the Animator, which should be attached to the GameObject you are intending to animate.
        m_Animator = gameObject.GetComponent<Animator>();
        // The GameObject cannot jump
        isPresent = false;

        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = mySound;
        
    }
  
    // Update is called once per frame
    void Update () {
        float posx = player.transform.position.x;
        if (posx > actvateXPos[i] -1 && posx < actvateXPos[i] +1)
        {
            myText.text = array[i];

            if (!isPresent)
                timeSince = Time.timeSinceLevelLoad;

            isPresent = true;


            if (i == actvateXPos.Length - 1)
                i = 0;

            if (i < actvateXPos.Length)
                i++;

            GetComponent<AudioSource>().Play();
            m_Animator.SetBool("NotifyMe", true);

        }

        if (isPresent && timeSince + 2.5 < Time.timeSinceLevelLoad)
        {
            isPresent = false;
            m_Animator.SetBool("NotifyMe", false);
        }

    }
        
       // Debug.Log(posx + " Is the position ");
       /* if (((posx >  -32 && posx < 0)|| (posx > 10 && posx < 25) || posx > 40) && isPresent == false)
        {
            Debug.Log("Made it" + i + "times");
            myText.text = array[i];
            i++;

            if (i == 3)
                i = 0;

            isPresent = true;
            GetComponent<AudioSource>().Play();
            m_Animator.SetBool("NotifyMe", true);
        }

        if (!((posx > -32 && posx < 0) || (posx > 10 && posx < 25) || posx > 40))
        {
            isPresent = false;
            m_Animator.SetBool("NotifyMe", false);
        }
        */
    
}
