using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeScr : MonoBehaviour {

	public float timeLeft = 60.0f;

	public Text timeText;

	void Update()
	{
		timeLeft -= Time.deltaTime;
		timeText.text = "Tid Tilage:" + Mathf.Round(timeLeft);
		if(timeLeft < 0)
		{
			if(Application.loadedLevelName == "Rav"){
				SceneManager.LoadScene ("GameOver_rav");
			}
			if(Application.loadedLevelName == "WoodCuttingScene"){
				SceneManager.LoadScene ("GameOver_wood");
			}
		}
	}
}
