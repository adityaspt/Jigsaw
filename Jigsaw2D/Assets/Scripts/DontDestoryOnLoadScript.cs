using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestoryOnLoadScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int puzzleNumber;
    public Sprite theSprite;
    public static DontDestoryOnLoadScript instance;
    private void Awake()
    {

        DontDestroyOnLoad(this);
        instance = this;
        if (GameObject.Find(gameObject.name) && GameObject.Find(gameObject.name) != this.gameObject)
        {
            Destroy(GameObject.Find(gameObject.name));
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
