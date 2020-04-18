using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pieceScript : MonoBehaviour
{
    public bool inRightPos = false;
    private Vector3 rightPos;
    public bool isSelected=false;
    // Start is called before the first frame update
    void Start()
    {
        rightPos = transform.position;
        //transform.position = new Vector3(UnityEngine.Random.Range(7.5f, 16.5f), UnityEngine.Random.Range(-6.7f, 1.53f));
        transform.position = new Vector3(UnityEngine.Random.Range(-0.6f, 3.5f), UnityEngine.Random.Range(-1.5f, 1.5f));
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,rightPos)<0.5f)
        {
            if (!isSelected)
            {
                transform.position = rightPos;
                inRightPos = true;
            }
        }


    }
}
