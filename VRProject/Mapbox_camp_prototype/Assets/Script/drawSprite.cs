using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawSprite : MonoBehaviour
{
    private float startX;
    private float startY;
    private bool isHeld = false;
    
    // Update is called once per frame
    void Update()
    {
        /*if (isHeld == true) {
            this.gameObject.transform.localPosition = new Vector3(mousePos.x, mousePos.y, 0);
        }*/
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))// primary button clicked
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            isHeld = true;
        }
    }
    private void OnMouseUp()
    {
        isHeld = false;
    }
}
