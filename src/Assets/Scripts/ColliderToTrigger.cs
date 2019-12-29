using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderToTrigger : MonoBehaviour {
    public Collider2D m_ObjectCollider;
    public DialogueManager diMa;
    public bool hasBeenOpen;

    // Update is called once per frame
    void Update () {
        if (diMa.isOpen)
            hasBeenOpen = true;
        if (hasBeenOpen && !diMa.isOpen)
            m_ObjectCollider.isTrigger = true;
    }
}
