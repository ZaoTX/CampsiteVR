using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pointer : MonoBehaviour
{
    public GameObject CurrentObject;
    Text myText;
    int currentID;
    bool mouseover = false;
    public float fadeTime = 0.01f;
    public Canvas canvas;
    string inhalt;
    //for viewToVR
    private Processor processor;
    public viveSettingCamp viveSettingCamp;
    public Vector3 hitPointPos;
    //for selection
    public Material normal_mat;
    public Material selected_material;
    GameObject LastCube;//define the Last Camp you selected
    //public VR

    private void Start()
    { 
        CurrentObject = null;
        currentID = 0;
        processor = gameObject.GetComponent(typeof(Processor)) as Processor;
        //viveSettingCamp = gameObject.GetComponent(typeof(viveSettingCamp)) as viveSettingCamp;
        LastCube = null;
    }
    void Update()
    {

        viewToVR();
        rayHits();
    }
    void viewToVR() 
    {
            //check the hit object
            RaycastHit[] hits;
            hits = Physics.RaycastAll(transform.position, transform.forward, 3000f);
            for (int i = 0; i < hits.Length; i++)
            {

                RaycastHit hit = hits[i];
                hitPointPos=new Vector3(hit.point.x, hit.point.y, hit.point.z);
                viveSettingCamp.PointerPos = hitPointPos;
                //Debug.Log(hitPointPos);
            }
        
    }
    void rayHits() 
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, 300f);
        for (int i = 0; i < hits.Length; i++) {

            RaycastHit hit = hits[i];
            int id = hit.collider.gameObject.GetInstanceID();
            if (currentID != id) {
                currentID = id;
                CurrentObject = hit.collider.gameObject;
            }
            name = CurrentObject.name;
            //Debug.Log("NoNONO");
            if (name == "3DCube") {
                Debug.Log("Yes you hit the cube");


                //get text
                myText = CurrentObject.transform.parent.gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<Text>();
                inhalt = myText.text;

                if (LastCube == null)//initial situation
                {
                    LastCube = CurrentObject;
                }
                else {
                    LastCube.GetComponent<Renderer>().material = normal_mat;
                }
                CurrentObject.GetComponent<Renderer>().material = selected_material;
                LastCube = CurrentObject;
                showText();
                FadeText();
                break;
            }
            //easter egg
            if (name == "hid") {
                inhalt = "Congratulations! You find the screct of Konstanz!";
                viveSettingCamp.isfound = true;
                showText();
                FadeText();
                break;
            }
           
        }
        Debug.Log("Now you are not hitting the cube");
        mouseover = false;
    }
    void showText() {
        
        Debug.Log(inhalt);
        mouseover = true;
        
    }
    void FadeText()
    {
        if (mouseover)
        {
            //myText.enabled = true;
            canvas.transform.GetChild(0).GetComponent<Text>().text = inhalt;
            //myText.color = Color.Lerp(myText.color, Color.black, fadeTime * Time.deltaTime);
        }
        else
        {
            //myText.enabled = false;
            //myText.color = Color.Lerp(myText.color, Color.clear, fadeTime * Time.deltaTime);
            canvas.transform.GetChild(0).GetComponent<Text>().text = " ";
        }
    }
}
