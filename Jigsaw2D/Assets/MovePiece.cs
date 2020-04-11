using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePiece : MonoBehaviour
{
    public string pieceStatus = "";
    public bool pieceLocked = false;
    public bool checkPiecePos = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            checkPiecePos = true;
        }

            if (!pieceLocked && checkPiecePos)
            {
                Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                Vector2 objPos = Camera.main.ScreenToWorldPoint(mousePos);
                transform.position = objPos;
            }
        
    
        if(Input.GetMouseButtonUp(0))
        {
            checkPiecePos = false;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == gameObject.name)
        {
            
            transform.position = collision.transform.position;
            pieceLocked = true; 
        }
    }
}
