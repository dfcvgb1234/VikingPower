using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cOLLECT : MonoBehaviour {

	public Text score;
	static public int scroew = 0;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "rav") {
			scroew++;
			score.text = "Gigant Rav : " + scroew;

            other.gameObject.transform.position = new Vector3(Random.Range(64.77667f, 3161f), Random.Range(-1501f, -52f));

			//other.GetComponent<SpriteRenderer> ().sprite = null;
			//Destroy (other);
		}
	}
}
