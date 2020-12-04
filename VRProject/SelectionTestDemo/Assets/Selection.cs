using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    float clickTime = 0f;
    float delay = 0.1f;
    //The start and end coordinates of the square we are making
    Vector3 squareStartPos;
    Vector3 squareEndPos;
    //The selection square we draw when we drag the mouse to select units
    //public RectTransform selectionSquareTrans;
    public SpriteRenderer spriterender;
    public Camera camera;
    //Sprite sp = spriterender.sprite;
    //public Sprite sp;
    // private Sprite sp;



    void Start()
    {
       // spriterender.sprite = sp;
    }

    // Update is called once per frame
    void Update()
    {
        SelectUnits();
    }
    void SelectUnits()
    {
        bool isHolding = false;
        //Click the mouse button
        if (Input.GetMouseButtonDown(0))
        {
            clickTime = Time.time;

            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                //Transform objectHit = hit.transform;
                squareStartPos = hit.point;
                // Do something with the object that was hit by the raycast.
            }

            //Debug.Log("Down");
        }
        //Holding down the mouse button
        if (Input.GetMouseButton(0))
        {
            if (Time.time - clickTime > delay)
            {
                isHolding = true;
            }
        }
        //Release the mouse button
        if (Input.GetMouseButtonUp(0))
        {
            isHolding = false;
            //Store the Endposition & disable the sprite
            spriterender.enabled=false;
            //Debug.Log("Up");
        }

        //Drag the mouse to select all units within the square
        if (isHolding)
        {

            //update coordinate of the square
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                //Transform objectHit = hit.transform;
                squareEndPos = hit.point;
                // Do something with the object that was hit by the raycast.
            }


            //Display the selection with a GUI image
            DisplaySquare();
            spriterender.enabled = true;
        }
    }
    void DisplaySquare()
    {


        Vector3 middle = (squareStartPos + squareEndPos) / 2f;
        
        spriterender.transform.position = new Vector3 (middle.x,0,middle.z);

        float scale = Vector3.Distance(squareStartPos, squareEndPos);

        spriterender.transform.localScale = new Vector3(scale, scale, scale);

        
    }
}
