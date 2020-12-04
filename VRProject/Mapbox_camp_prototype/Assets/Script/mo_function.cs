using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mo_function : MonoBehaviour
{
    //public string myString = "This is a White Cube";
    public Text myText;
    public bool mouseover = false;
    public float fadeTime = 0.01f;
    int count = 1;
    // Start is called before the first frame update
    void Start()
    {
        //transform: 3DCube
        //parent: camp3DIcon, 
        //GetChild(1): Canvas,
        //GetChild(0): Text
        myText = transform.parent.gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<Text>();

        myText.color = Color.clear;
    }
    // Update is called once per frame
    void Update()
    {
        FadeText();
    }
    void FadeText()
    {
        
        if (mouseover)
        {
            myText.color = Color.Lerp(myText.color, Color.black, fadeTime * Time.deltaTime);
        }
        else
        {
            myText.color = Color.Lerp(myText.color, Color.clear, fadeTime * Time.deltaTime);
        }
    }
    void OnMouseOver()
    {
        mouseover = true;
    }
    void OnMouseExit()
    {
        mouseover = false;
    }
}
