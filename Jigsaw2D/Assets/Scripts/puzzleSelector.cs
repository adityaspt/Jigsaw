using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class puzzleSelector : MonoBehaviour
{
    public DontDestoryOnLoadScript script;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        }
        else
            Debug.Log("currentSelectedGameObject is null");
        SceneManager.LoadScene(1);
    }
}
