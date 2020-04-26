using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPuzzle : MonoBehaviour
{
    public Sprite[] img;
    Sprite spriteImg;
    //public GameObject dontdestroyedObject;
    public DontDestoryOnLoadScript DontDestroyScript;
    private void Awake()
    {
        spriteImg = GameObject.Find("PickerController").GetComponent<PickerController>().carryForward;
        //dontdestroyedObject = GameObject.Find("DontDestroyObject");
        DontDestroyScript = GameObject.Find("DontDestroyObject").GetComponent<DontDestoryOnLoadScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (DontDestroyScript.puzzleNumber != 1000)
        {
            for (int i = 0; i < 36; i++)
            {
                GameObject.Find("Piece (" + i + ")").transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = img[DontDestroyScript.puzzleNumber];
            }
        }
        else
        {
            for (int i = 0; i < 36; i++)
            {
                GameObject.Find("Piece (" + i + ")").transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = spriteImg;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
