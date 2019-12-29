using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretUI : MonoBehaviour
{
    public DialogueManager diMa;
    public Animator animator;

    void Update()

    {

        if (diMa.isOpen)
            animator.SetBool("IsOpen", true);
        else
            animator.SetBool("IsOpen", false);
    }
}

