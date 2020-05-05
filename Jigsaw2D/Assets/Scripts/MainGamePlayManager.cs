using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class MainGamePlayManager : MonoBehaviour
{
    public TextMeshProUGUI timetext;
    public static MainGamePlayManager mainInstance;
    public int pieceRightPosCounter = 0;
    public GameObject panel;
    public float seconds, minutes; 
    // Start is called before the first frame update
    void Start()
    {
        minutes = Time.time;
        seconds = Time.time;
        //timetext.text = "00:00";
        mainInstance = this;
       
       // canvas = GameObject.Find("Canvas");
    }
    void ResetTimer()
    {

    }

    private void Update()
    {
        minutes = (int)(Time.time / 60f);
        seconds = (int)(Time.time % 60f);
        timetext.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(pieceRightPosCounter>=36)
        {
            panel.gameObject.SetActive(true);
            panel.transform.GetChild(0).gameObject.SetActive(true);
            panel.transform.GetChild(1).gameObject.SetActive(true);
            panel.transform.GetChild(3).gameObject.SetActive(false);
            Time.timeScale = 0.0f;
            print("You win!!!");
        }
    }

    public void OnClickButton()
    {
        if(EventSystem.current.currentSelectedGameObject.name=="Replay")
        {
            if (Time.timeScale == 0.0f)

                Time.timeScale = 1.0f;

            SceneManager.LoadScene(1);
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "GoMainMenu")
        {
            if (Time.timeScale == 0.0f)

                Time.timeScale = 1.0f;

           // Destroy(GameObject.Find("DontDestroyObject"));
            //Destroy(GameObject.Find("PickerController"));
            SceneManager.LoadScene(0);

        }
        else if(EventSystem.current.currentSelectedGameObject.name == "PauseB")
        {
            panel.gameObject.SetActive(true);
            panel.transform.GetChild(1).gameObject.SetActive(true);
            RemoveListener();
            if (Time.timeScale == 1.0)
                Time.timeScale = 0.0f;
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "Resume")
        {
            //panel.transform.GetChild(1).gameObject.SetActive(false);
            panel.gameObject.SetActive(false);
            AddListener();
            if (Time.timeScale == 0.0f)
          
                Time.timeScale = 1.0f;

        }
    }

    void AddListener()
    {
        for (int i = 0; i < 36; i++)
        {
            GameObject.Find("Piece (" + i + ")").GetComponent<BoxCollider2D>().enabled = true;
        }
        GameObject.Find("PauseB").GetComponent<Button>().interactable = true;
    }
    void RemoveListener()
    {
        for (int i = 0; i < 36; i++)
        {
            GameObject.Find("Piece (" + i + ")").GetComponent<BoxCollider2D>().enabled = false;
        }
        GameObject.Find("PauseB").GetComponent<Button>().interactable = false;
    }
}
