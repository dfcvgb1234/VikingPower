using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
    public GameObject follow;
    public float offset;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.position = follow.transform.position + new Vector3(0, 0, offset);
        Mathf.Clamp(follow.transform.position.x,400,2825);
        Mathf.Clamp(follow.transform.position.y, -2000, -178);

	}
}
