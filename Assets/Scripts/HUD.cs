using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public int score;

    public string camName;

    public Camera cam;

    Text text;
    // Use this for initialization

    public void Begin()
    {
        cam = GameObject.Find(camName).GetComponent<Camera>();
    }

    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + score;

        text.transform.position = new Vector3(Screen.width * cam.rect.x + (Screen.width/4), Screen.height * 0.8f, 0);
    }
}
