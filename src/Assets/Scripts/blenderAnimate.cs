using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blenderAnimate : MonoBehaviour {

    public shake shakeObj;
    public Animator animator;
    public Collider2D m_ObjectCollider;

    void Update()

    {

        if (shakeObj.shook)
        {
            animator.SetBool("blend", true);
            m_ObjectCollider.isTrigger = true;
        }
            
        else
            animator.SetBool("blend", false);
    }
}