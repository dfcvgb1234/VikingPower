using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetDataFromWood : MonoBehaviour {

    public Button newGameButton;
    public Text textshit;

    void Awake()
    {
        textshit.text = "Du huggede " + WoodCutting.point + " stykker brænde!";
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
        SceneManager.LoadScene("WoodCuttingScene");
    }
}
