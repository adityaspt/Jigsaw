using System.Collections;
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
        instance = this;
        pieceLocked = false;
        piecePickedUp = false;
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        piecePickedUp = true;
    }
    private void OnMouseUp()
    {
        piecePickedUp = false;
    }
    void Update()
    {

        if (piecePickedUp) {

            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = newPos;
                }
        if (!pieceLocked && piecePickedUp)
        {
            Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPos = Camera.main.ScreenToWorldPoint(mousePos);
            this.transform.position = objPos;
        }


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
            //if (collision.gameObject.name ==gameObject.name)
            if(DoesPieceMatchWithPlace(gameObject.name,collision.gameObject.name))
            {
                pieceLocked = true;
                transform.position = collision.transform.position;
                GetComponent<BoxCollider2D>().enabled = false;
                collision.GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
                //if (!piecePickedUp)
                //{
                    GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .5f);
                    transform.position = collision.transform.position;
               // }
               
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!DoesPieceMatchWithPlace(gameObject.name, collision.gameObject.name))
        {

            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);

        }
    }

}
