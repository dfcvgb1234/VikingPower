using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WoodCutting : MonoBehaviour {


    public GameObject[] Button;
    public Text points;
    public GameObject missed;
    public static int point;
    bool found;
    int indexOfFound;
    string[] textToSearch;
    float fade = 1;
    string text;


	// Use this for initialization
	void Start () {
        textToSearch = new string[Button.Length];
        GameObject[] tmp = GameObject.FindGameObjectsWithTag("Player");
        if(tmp.Length != 1)
        {
            while(tmp.Length != 1)
            {
                Destroy(tmp[tmp.Length-1]);
            }
        }
        point = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            ResetButton(2);
        }
        fade -= Time.deltaTime / 3;
        FadeButton(fade);

        if(fade <= 0)
        {
            GetNextButton();
            fade = 1;
        }

        if (Input.anyKeyDown)
        {
            found = false;
            print(Input.inputString);
            for (int i = 0; i < textToSearch.Length; i++)
            {
                if(Input.inputString == textToSearch[i])
                {
                    found = true;
                    indexOfFound = i;
                    textToSearch[i] = "+";
                    break;
                }
                else
                {
                    found = false;
                }
            }

            //meme
            if(!found)
            {
                StartCoroutine(ShowMissed());
                GetNextButton();
                print("FORKERT");
                CheckAllButtons();
            }
            if(found)
            {
                Button[indexOfFound].SetActive(false);
                found = false;
                indexOfFound = 0;
                CheckAllButtons();
            }
        }

    }
        
    public void GetNextButton()
    {
        fade = 1;

        int[] rand = new int[Button.Length];

        for (int i = 0; i < Button.Length; i++)
        {
            rand[i] = Random.Range(1, 10);
        }

        for (int i = 0; i < Button.Length; i++)
        {
            switch (rand[i])
            {
                case 1:
                    text = "A";
                    textToSearch[i] = "a";
                    break;

                case 2:
                    text = "G";
                    textToSearch[i] = "g";
                    break;

                case 3:
                    text = "H";
                    textToSearch[i] = "h";
                    break;

                case 4:
                    text = "J";
                    textToSearch[i] = "j";
                    break;

                case 5:
                    text = "B";
                    textToSearch[i] = "b";
                    break;

                case 6:
                    text = "T";
                    textToSearch[i] = "t";
                    break;

                case 7:
                    text = "S";
                    textToSearch[i] = "s";
                    break;

                case 8:
                    text = "E";
                    textToSearch[i] = "e";
                    break;

                case 9:
                    text = "Y";
                    textToSearch[i] = "y";
                    break;
            }
            Button[i].GetComponentInChildren<Text>().text = text;
        }

        for (int i = 0; i < Button.Length; i++)
        {
            Button[i].transform.localPosition = new Vector2(Random.Range(-509, 509), Random.Range(-196,196));
            Button[i].SetActive(true);
        }
    }

    public void FadeButton(float x)
    {
        for (int i = 0; i < Button.Length; i++)
        {
            Button[i].GetComponent<Image>().color = new Color(1,1,1,x);
            Button[i].GetComponentInChildren<Text>().color = new Color(0,0,0,x);
        }
    }

    private void ResetButton(int index)
    {
        Button[index].GetComponent<Image>().color = new Color(1, 1, 1, 1);
        Button[index].GetComponentInChildren<Text>().color = new Color(0, 0, 0, 1);
    }

    IEnumerator ShowMissed()
    {
        missed.SetActive(true);
        yield return new WaitForSeconds(2);
        missed.SetActive(false);
    }

    void CheckAllButtons()
    {
        GameObject[] listOfButtons = GameObject.FindGameObjectsWithTag("Image");
        if (listOfButtons.Length == 0)
        {
            GetNextButton();
            point++;
            points.text = string.Format("Du har hugget {0} stykker brænde", point);
        }
    }
}
