using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_mat : MonoBehaviour
{
    public Texture myTexture;
    public GameObject[] transs;
    public int num;
    // Start is called before the first frame update
    void Start()
    {
        
        var colors = new Color[num];
        // Instead if vertex.y we use uv.x
        for (var i = 0; i < num; i++) {
            GameObject trans = transs[i];
            //Find the Standard Shader
            Material myNewMaterial = new Material(Shader.Find("Standard"));
            //Set Texture on the material
            myNewMaterial.SetTexture("_MainTex", myTexture);
            //Apply to GameObject
            trans.GetComponent<MeshRenderer>().material = myNewMaterial;
            colors[i] = Color.Lerp(Color.red, Color.green, i);
            myNewMaterial.color = colors[i];
        }
        

}

    // Update is called once per frame
    void Update()
    {
        
    }
}
