using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectListener : MonoBehaviour
{
    bool isok = true;
    Vector3 curPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isok&&transform.position.y <= 10) {
            isok = false;
            curPos = transform.position;
        }
        if (transform.position.y<10&&!isok) {
            transform.position = new Vector3(curPos.x, 10, curPos.z);
            transform.localScale = new Vector3(10,10,10);
        }
    }
}
