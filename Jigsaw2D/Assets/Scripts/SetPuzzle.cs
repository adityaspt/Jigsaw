using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPuzzle : MonoBehaviour
{
    public Sprite[] img;

    //public GameObject dontdestroyedObject;
    public DontDestoryOnLoadScript DontDestroyScript;
    private void Awake()
    {
        //dontdestroyedObject = GameObject.Find("DontDestroyObject");
        DontDestroyScript = GameObject.Find("DontDestroyObject").GetComponent<DontDestoryOnLoadScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<36; i++)
        {
            GameObject.Find("Piece (" + i + ")").transform.GetChild(0).GetComponent<SpriteRenderer>().sprite=img[DontDestroyScript.puzzleNumber]; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
