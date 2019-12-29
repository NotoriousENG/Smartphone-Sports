using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    internal static object main;
    public Transform player;
    public Vector3 offset;
    public bool lockposy;
    public bool lockposx;

    public bool lockall;

    void Update()
    {
        if (lockposy == true && !lockall)
            transform.position = new Vector3(player.position.x + offset.x, /*player.position.y +*/ offset.y, offset.z); // Camera follows the player with specified offset position

        if(lockposy == false && !lockall && !lockposx)
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position

        if (lockposx == true && !lockall)
            transform.position = new Vector3(/*player.position.x +*/ offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position

        if (lockposx == false && !lockall && !lockposy)
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position

    }
}
