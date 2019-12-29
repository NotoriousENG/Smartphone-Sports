
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    Vector3 targetPosition;
    public Transform PlayerTransform;
    public bool auto;
    public Vector3 offset;

    //float someScale;

    //Fetch the Animator
    Animator m_Animator;
    // Use this for deciding if the GameObject can walk or not
    bool isWalking;
    public bool rotateMe;
    public Collider2D collider2d;
    Vector3 Nextpos;

    public bool canMove = true;

    public static PlayerMovement instance;

    void Start()
    {
        instance = this;

        //This gets the Animator, which should be attached to the GameObject you are intending to animate.
        m_Animator = gameObject.GetComponent/*InChildren*/<Animator>();
        // The GameObject cannot jump
        isWalking = false;
        targetPosition = PlayerTransform.position;

        //someScale = transform.localScale.x; // assuming this is facing right
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && canMove)
        {
            Nextpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Nextpos.z = Nextpos.z - Nextpos.z;  
            targetPosition = Nextpos;
        }

        if (targetPosition != PlayerTransform.position && canMove)
        {
            if (auto)
            {
                targetPosition.x = targetPosition.x + 1;
            }
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
            isWalking = true;
        }
        if (targetPosition == PlayerTransform.position && canMove)
        {
            if (auto)
            {
                isWalking = true;
                Nextpos = PlayerTransform.position;
                Nextpos.x += 1;
                targetPosition = Nextpos; 
            }
            if (!auto)
            {
                isWalking = false;
            }


        }
        //If the GameObject is not jumping, send that the Boolean “Jump” is false to the Animator. The jump animation does not play.
        if (isWalking == false || !canMove)
            m_Animator.SetBool("IsWalking", false);

        //The GameObject is jumping, so send the Boolean as enabled to the Animator. The jump animation plays.
        if (isWalking == true && canMove)
            m_Animator.SetBool("IsWalking", true);

        if (rotateMe == true)
            m_Animator.SetBool("IsWalkingUp", true);

        if (targetPosition.x < PlayerTransform.position.x)
        {
            if (rotateMe)
                transform./*GetChild(0).*/eulerAngles = new Vector3(0, 180, 270); // Flipped
            else
                transform./*GetChild(0).*/eulerAngles = new Vector3(0, 180, 0); // Flipped
            
        }
        else
        {
            if (rotateMe)
                transform./*GetChild(0).*/eulerAngles = new Vector3(0, 0, 270); // Flipped
            else
                transform./*GetChild(0).*/eulerAngles = new Vector3(0, 0, 0); // Normal
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bad")
        {
            Debug.Log("Got Collision");
            PlayerTransform.transform.position = new Vector3(offset.x, offset.y, offset.z);
            targetPosition = PlayerTransform.position;
            // playerCollides with the Enemy
        }
    }
}
