using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public int startHealth;
    public float moveSpeed;
    public Rigidbody2D rb;
    public Slider slider;
    

    string hor;
    string ver;
    string Rhor;
    string Rver;
    public int playerNum;
    public int teamNum;
    string enemyHUD;

    Vector3 spawn;
    public Vector2 moveVector;

    public Animator animator;

    private int health;

    public Vector2 facing;

    public Camera cam;

    void Start()
    {
        health = startHealth;

        spawn = transform.position;

        if (teamNum == 2)
        {
            this.gameObject.layer = 12;
            this.GetComponent<SpriteRenderer>().color = new Color(1, 0.6792453f, 0.6792453f);
        }

        switch (playerNum)
        {
            case 1:
                hor = "Horizontal";
                ver = "Vertical";
                Rhor = "RightHoriz";
                Rver = "RightVert";
                break;
            case 2:
                hor = "Horizontal2";
                ver = "Vertical2";
                Rhor = "RightHoriz2";
                Rver = "RightVert2";
                cam.name = "Second Camera";
                cam.GetComponent<AudioListener>().enabled = false;
                break;
            case 3:
                hor = "Horizontal3";
                ver = "Vertical3";
                Rhor = "RightHoriz3";
                Rver = "RightVert3";
                cam.name = "Third Camera";
                cam.GetComponent<AudioListener>().enabled = false;
                break;
            case 4:
                hor = "Horizontal4";
                ver = "Vertical4";
                Rhor = "RightHoriz4";
                Rver = "RightVert4";
                cam.name = "Fourth Camera";
                cam.GetComponent<AudioListener>().enabled = false;
                break;
        }
        
        /*if (playerOne)
        {
            hor = "Horizontal";
            ver = "Vertical";
            Rhor = "RightHoriz";
            Rver = "RightVert";
            playerNum = "p1";
            enemyHUD = "HUD2";
        } else
        {
            hor = "Horizontal2";
            ver = "Vertical2";
            Rhor = "RightHoriz2";
            Rver = "RightVert2";
            playerNum = "p2";
            this.gameObject.layer = 12;
            enemyHUD = "HUD1";
            this.GetComponent<SpriteRenderer>().color = new Color(1, 0.6792453f, 0.6792453f);
            GameObject player2Cam = GameObject.Find(this.name + "/Main Camera");
            player2Cam.name = "Second Camera";
            player2Cam.GetComponent<AudioListener>().enabled = false;

            GameObject ss = GameObject.Find("GameController");
            ss.GetComponent<SplitScreen>().Begin();

            GameObject h1 = GameObject.Find("HUD1");
            h1.GetComponent<HUD>().camName = "Main Camera";
            h1.GetComponent<HUD>().Begin();
            GameObject h2 = GameObject.Find("HUD2");
            h2.GetComponent<HUD>().camName = "Second Camera";
            h2.GetComponent<HUD>().Begin();

        }*/
    }

    private void Update()
    {
        moveVector = new Vector2(Input.GetAxisRaw(hor), Input.GetAxisRaw(ver));

        facing = new Vector2(Input.GetAxisRaw(Rhor), Input.GetAxisRaw(Rver));

        if (Input.GetAxisRaw(Rhor) == 0 && Input.GetAxisRaw(Rver) == 0)
        {
            animator.SetFloat("Horizontal", moveVector.x);
            animator.SetFloat("Vertical", moveVector.y);
            animator.SetFloat("Speed", moveVector.sqrMagnitude);
        }
        else
        {
            animator.SetFloat("Horizontal", facing.x);
            animator.SetFloat("Vertical", facing.y);
            animator.SetFloat("Speed", moveVector.sqrMagnitude);
        }

    }

    void FixedUpdate()
    { 

        if ((Input.GetAxisRaw(hor) > 0.1f || Input.GetAxisRaw(hor) < -0.1f)
            || (Input.GetAxisRaw(ver) > 0.1f || Input.GetAxisRaw(ver) < -0.1f))
        {
            rb.MovePosition(new Vector2(transform.position.x + moveVector.x * moveSpeed * Time.deltaTime,
                transform.position.y + moveVector.y * moveSpeed * Time.deltaTime));
            if (Mathf.Abs(Input.GetAxisRaw(hor)) > Mathf.Abs(Input.GetAxisRaw(ver)))
                animator.speed = Mathf.Abs(Input.GetAxisRaw(hor));
            else
                animator.speed = Mathf.Abs(Input.GetAxisRaw(ver));
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
            health -= collision.gameObject.GetComponent<BulletController>().damage;
        }

        if (collision.gameObject.name == "Health Pack(Clone)")
        {
            Destroy(collision.gameObject);
            health = startHealth;
        }
    }


    private void death ()
    {
        /*GameObject hudController2 = GameObject.Find(enemyHUD);
        HUD hud2 = hudController2.GetComponent<HUD>();
        hud2.score += 1;*/

        if (teamNum == 1)
            ScoreHandler.team2Score += 1;
        else
            ScoreHandler.team1Score += 1;

        transform.position = spawn;
        health = startHealth;
    }
}
