using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DragnDrog : MonoBehaviour
{
    public GameObject selectedPiece;
    int Order = 1; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.transform.CompareTag("Puzzle"))
            {
                if (!hit.transform.GetComponent<pieceScript>().inRightPos)
                {
                    
                    selectedPiece = hit.transform.gameObject;
                    selectedPiece.GetComponent<pieceScript>().isSelected = true;
                    selectedPiece.GetComponent<SortingGroup>().sortingOrder = Order;
                }
            }
            //else if(hit.transform.CompareTag("Untagged"))
            //{
            //    print("No piece");
            //}
            
        }
        if(Input.GetMouseButtonUp(0))
        {
            if (selectedPiece != null)
            {
                selectedPiece.GetComponent<SortingGroup>().sortingOrder = 0;
                selectedPiece.GetComponent<pieceScript>().isSelected = false;
                selectedPiece = null;
                
            }
        }
        if(selectedPiece !=null)
        {
            Vector3 newPos=(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            selectedPiece.transform.position = new Vector3(newPos.x,newPos.y,0);
        }
    }
}
