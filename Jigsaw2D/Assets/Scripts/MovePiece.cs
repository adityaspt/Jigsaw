﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePiece : MonoBehaviour
{
    private bool pieceLocked ;
    private bool piecePickedUp;
    private static MovePiece instance;
    // Start is called before the first frame update
    void Start()
    {
       // instance = this;
        pieceLocked = false;
        piecePickedUp = false;
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
       // if (Input.GetMouseButtonDown(0))
            piecePickedUp = true;
    }
    private void OnMouseUp()
    {
       // if(Input.GetMouseButtonUp(0))
        piecePickedUp = false;
    }
    void Update()
    {

        if (!pieceLocked && piecePickedUp) {
            Vector2 mousePos=new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 newPos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = newPos;
                }
        //if (!pieceLocked && piecePickedUp)
        //{
        //    Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //    Vector2 objPos = Camera.main.ScreenToWorldPoint(mousePos);
        //    this.transform.position = objPos;
        //}


        //if (Input.GetMouseButtonUp(0))
        //{
        //    piecePickedUp = false;
        //}


    }

     bool DoesPieceMatchWithPlace(string a,string b)
    {
        if(b.Contains(a) )
        {
            return true;
        }
        else /*if(!b.Contains(a) && !b.Contains("place"))*/
        {
            return false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!piecePickedUp)
        {
            if(collision.gameObject.CompareTag(gameObject.tag))
            //if (collision.gameObject.name ==gameObject.name)
            //if(DoesPieceMatchWithPlace(gameObject.name,collision.gameObject.name))
            {
               // print(collision.gameObject.name + " collsion " + gameObject.name + " obj");
                pieceLocked = true;
                transform.position = collision.transform.position;
                GetComponent<BoxCollider2D>().enabled = false;
                collision.GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
               print(collision.gameObject.name + " collsion " + gameObject.name + " obj");
                //if (!piecePickedUp)
                //{
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .5f);
                    transform.position = collision.transform.position;
                //collision.GetComponent<BoxCollider2D>().enabled = false;
                // }

            }
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
           // collision.GetComponent<BoxCollider2D>().enabled = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name != gameObject.name)
        //if (!DoesPieceMatchWithPlace(gameObject.name, collision.gameObject.name))
        {

            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);

        }
    }

}
