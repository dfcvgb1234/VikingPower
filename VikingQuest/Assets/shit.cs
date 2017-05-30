using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class shit : MonoBehaviour
{

    public Button newGameButton;
    public Text textshit;

    void Awake()
    {
        textshit.text = "Du samlede " + cOLLECT.scroew + " stykker rav!";
    }

    void OnEnable()
    {
        newGameButton.onClick.AddListener(delegate
        {
            OnNewGamePress();
        });
    }

    void OnNewGamePress()
    {
        SceneManager.LoadScene("World");
    }
}
