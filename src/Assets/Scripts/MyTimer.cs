using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyTimer : MonoBehaviour {
    public float time;
    public Text displayedTime;

	// Use this for initialization
	void Start () {
     
	}
	
	// Update is called once per frame
	void Update () {
        time+= Time.deltaTime;
        displayedTime.text = "Time: " + Mathf.FloorToInt(time).ToString();
	}

}
