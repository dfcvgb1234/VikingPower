using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingScript : MonoBehaviour {
    public Sprite walkingSprite;
    public Sprite upSprite;
    public Sprite downSprite;
    public int speed = 100;
    SpriteRenderer sr;

	// Use this for initialization
	void Start () {
        sr = this.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        MoveWASD();
	}

    void MoveWASD()
    {
        if(Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(new Vector3(-2, 0) * Time.deltaTime * speed);
            sr.flipX = true;
            sr.sprite = walkingSprite;
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(new Vector3(2, 0) * Time.deltaTime * speed);
            sr.flipX = false;
            sr.sprite = walkingSprite;
        }
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(new Vector3(0, 2) * Time.deltaTime * speed);
            sr.sprite = upSprite;
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(new Vector3(0, -2) * Time.deltaTime * speed);
            sr.sprite = downSprite;
        }
    }
}
