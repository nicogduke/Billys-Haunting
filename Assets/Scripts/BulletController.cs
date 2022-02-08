using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float speed;
    public int owner;
    public int damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        if (owner == 2)
            this.gameObject.layer = 13;
    }

    void Update()
    {
        //Debug.Log(score1);
        transform.Translate(new Vector3(speed * Time.deltaTime, 0f, 0f));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
