using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;


public class NetworkPlayerController : NetworkBehaviour
{
    public bool playerOne;
    public int health;
    public float moveSpeed;
    public Rigidbody2D rb;
    public Slider slider;

    string hor;
    string ver;
    //string enemy;
    string enemyHUD;

    Vector3 spawn;

    void Start()
    {
        health = 100;

        if (playerOne)
        {
            hor = "Horizontal";
            ver = "Vertical";
            //enemy = "p2";
            enemyHUD = "HUD2";
            spawn = new Vector3(0, 0, 0);
        }
        else
        {
            hor = "Horizontal2";
            ver = "Vertical2";
            //enemy = "p1";
            enemyHUD = "HUD1";
            spawn = new Vector3(15, 0, 0);
            this.GetComponent<SpriteRenderer>().color = new Color(1, 0.6792453f, 0.6792453f);
        }
    }

    void FixedUpdate()
    {
        var moveVector = new Vector3(Input.GetAxisRaw(hor), Input.GetAxisRaw(ver), 0);
        if (this.isLocalPlayer)
        {
            if ((Input.GetAxisRaw(hor) > 0.1f || Input.GetAxisRaw(hor) < -0.1f)
            || (Input.GetAxisRaw(ver) > 0.1f || Input.GetAxisRaw(ver) < -0.1f))
            {
                rb.MovePosition(new Vector2(transform.position.x + moveVector.x * moveSpeed * Time.deltaTime,
                    transform.position.y + moveVector.y * moveSpeed * Time.deltaTime));
                Debug.Log(ver);
            }
        }

        rb.velocity = new Vector2(0.0f, 0.0f);

        slider.value = health;

        if (health < 1)
            death();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //if (collision.gameObject.GetComponent<BulletController>().player == enemy)
                health -= collision.gameObject.GetComponent<BulletController>().damage;
        }
    }

    private void death()
    {
        GameObject hudController2 = GameObject.Find(enemyHUD);
        //HUD hud2 = hudController2.GetComponent<HUD>();
        //hud2.score += 1;

        transform.position = spawn;
        health = 100;
    }
}
