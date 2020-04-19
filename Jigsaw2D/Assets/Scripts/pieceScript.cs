using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pieceScript : MonoBehaviour
{
    public string Mytag;
    public bool inRightPos = false;
    private Vector3 rightPos;
    public bool isSelected=false;
    // Start is called before the first frame update
    void Start()
    {
        rightPos = transform.position;
        //transform.position = new Vector3(UnityEngine.Random.Range(7.5f, 16.5f), UnityEngine.Random.Range(-6.7f, 1.53f));
        transform.position = new Vector3(Random.Range(0.6f, 4f), Random.Range(-1.5f, 1.5f));
    }

    // Update is called once per frame
    void Update()
    {
        if (!inRightPos && Mytag != "" && !isSelected)
        {
            GameObject closestObj = FindNearestObjects(transform.position, Mytag);
            print(closestObj);
            if (Vector3.Distance(transform.position, closestObj.transform.position) < 0.5f)
            {
              
                    transform.position = closestObj.transform.position;
                
            }
        }


        if(Vector3.Distance(transform.position,rightPos)<0.5f && !inRightPos)
        {
            if (!isSelected)
            {
                transform.position = rightPos;
                inRightPos = true;
                MainGamePlayManager.mainInstance.pieceRightPosCounter++;
            }
        }


    }

   public GameObject FindNearestObjects(Vector3 nearestPos,string myTag)
    {
        GameObject[] gobjs;
        //print(gobjs.gameObject.name + " name");
        //gobjs=GameObject.FindObjectsOfType(GetComponent<pieceScript>().Mytag = myTag) ;
        gobjs = GameObject.FindGameObjectsWithTag(myTag);
        
        //print(gobjs[0].gameObject.name+ " name");
        float distance = Mathf.Infinity;
        GameObject closest = null;
        Vector3 currposition = nearestPos;
        foreach (GameObject gobj in gobjs)
        {
            Vector3 diff = gobj.transform.position - currposition;
            float currDistance = diff.sqrMagnitude;
            if(currDistance<distance)
            {
                closest = gobj;
                distance = currDistance;
            }
        }
        return closest;
    }
}
