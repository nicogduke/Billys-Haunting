using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreen : MonoBehaviour {

    public Camera cam1;
    public Camera cam2;
    public Camera cam3;
    public Camera cam4;
    

    public void Start()
    {
        cam1 = GameObject.Find("Main Camera").GetComponent<Camera>();
        cam2 = GameObject.Find("Second Camera").GetComponent<Camera>();
        cam3 = GameObject.Find("Third Camera").GetComponent<Camera>();
        cam4 = GameObject.Find("Fourth Camera").GetComponent<Camera>();

        cam3.rect = new Rect(0, 0, 0.5f, 0.5f);
        cam4.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
        cam1.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
        cam2.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            /*cam1 = GameObject.Find("Main Camera").GetComponent<Camera>();
            cam2 = GameObject.Find("Second Camera").GetComponent<Camera>();
            cam3 = GameObject.Find("Third Camera").GetComponent<Camera>();
            cam4 = GameObject.Find("Fourth Camera").GetComponent<Camera>();

            cam1.rect = new Rect(0, 0, 0.5f, 0.5f);
            cam2.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
            cam3.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
            cam4.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
            if (swtch)
            {
                cam1.rect = new Rect(0, 0, 1, 1);
                cam2.rect = new Rect(0, 0, 0, 1);
                swtch = false;
            }
            else
            {
                cam1.rect = new Rect(0, 0, 0.5f, 1);
                cam2.rect = new Rect(0.5f, 0, 0.5f, 1);
                swtch = true;
            }*/
        }
    }
}
