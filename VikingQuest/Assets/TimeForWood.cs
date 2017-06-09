using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeForWood : MonoBehaviour {

    public float timeLeft = 60.0f;

    public Text timeText;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeText.text = "Tid Tilage:" + Mathf.Round(timeLeft);
        if (timeLeft < 0)
        {
            SceneManager.LoadScene("GameOver_wood");
        }
    }
}
