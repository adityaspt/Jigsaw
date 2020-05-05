using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Kakera;
using UnityEngine.UI;
using TMPro;

public class puzzleSelector : MonoBehaviour
{
    public DontDestoryOnLoadScript script;
    public PickerController pickScript;
    public GameObject selfImageText;
    public GameObject SelfButton;
    public GameObject ImagePlayButton;

    // Start is called before the first frame update
    void Start()
    {
        //SelfButton.gameObject.tag = "Select";


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelectSelfImg()
    {
        var go = EventSystem.current.currentSelectedGameObject;
        if (go.gameObject.tag == "Select")
        {
            selfImageText.SetActive(false);
            //SelfButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Play this";
            // script.puzzleNumber = 1000;
            //go.gameObject.tag = "OwnImage";
            pickScript.OnPressShowPicker();
            SelfButton.SetActive(false);
            ImagePlayButton.SetActive(true);

        }
    }


    public void OnLevelClick()
    {
        var go = EventSystem.current.currentSelectedGameObject;
        if (go != null)
        {
            Debug.Log("Clicked on : " + go.gameObject.tag);
            if(go.gameObject.tag=="Balloon")
            {
                script.puzzleNumber = 0;
            }
            else if (go.gameObject.tag == "Spongebob")
            {
                script.puzzleNumber = 1;
            }
            if (go.gameObject.tag == "House")
            {
                script.puzzleNumber = 2;
            }
            if (go.gameObject.tag == "Image")
            {
                script.puzzleNumber = 1000;
            }
        }
        else
            Debug.Log("currentSelectedGameObject is null");
        //PickerController.img.sprite = null;
        SceneManager.LoadScene(1);
    }
}
