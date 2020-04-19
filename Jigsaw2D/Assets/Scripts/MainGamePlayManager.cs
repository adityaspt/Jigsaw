using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainGamePlayManager : MonoBehaviour
{
    public static MainGamePlayManager mainInstance;
    public int pieceRightPosCounter = 0;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        mainInstance = this;
       // canvas = GameObject.Find("Canvas");
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
            print("You win!!!");
        }
    }

    public void OnClickButton()
    {
        if(EventSystem.current.currentSelectedGameObject.name=="Replay")
        {
            SceneManager.LoadScene(1);
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "GoMainMenu")
        {
            Destroy(GameObject.Find("DontDestroyObject"));
            SceneManager.LoadScene(0);

        }
        else if(EventSystem.current.currentSelectedGameObject.name == "PauseB")
        {
            panel.gameObject.SetActive(true);
            panel.transform.GetChild(1).gameObject.SetActive(true);
            RemoveListener();
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "Resume")
        {
            //panel.transform.GetChild(1).gameObject.SetActive(false);
            panel.gameObject.SetActive(false);
            AddListener();
            
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
