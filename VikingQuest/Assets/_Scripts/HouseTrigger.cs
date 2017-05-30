using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HouseTrigger : MonoBehaviour {
    
    void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.tag == "Player")
		{
			if(this.tag == "House_1")
			{
				SceneManager.LoadScene ("House_1");
				Debug.Log("Loaded level House_1");
			}

			else if (this.tag == "House_2")
			{
				SceneManager.LoadScene ("House_2");
				Debug.Log("Loaded level House_2");
			}

			else if(this.tag == "Long_House_1")
			{
				SceneManager.LoadScene ("Long_House_1");
				Debug.Log("Loaded level Long_House_1");
			}
		}
    }
}
