using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public BulletController bullet;

    public int playerNum;

    public float timeBetweenShots;
    private float shotCounter;
    private float gunAngle;

    private float hVal;
    private float vVal;

    private float gunAngleHoriz;
    private float gunAngleVert;

    public Transform firePoint;
    public GameObject player;

    string hor;
    string ver;
    string shot;
    int team;
    Color color;

    public int damage;
    public int speed;

    //public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = 0;

        playerNum = player.GetComponent<PlayerController>().playerNum;

        team = player.GetComponent<PlayerController>().teamNum;

        if (team == 1)
            color = new Color(1, 1, 1);
        if (team == 2)
            color = new Color(1, 0.6792453f, 0.6792453f);

        switch (playerNum)
        {
            case 1:
                hor = "RightHoriz";
                ver = "RightVert";
                shot = "Shoot";
                break;
            case 2:
                hor = "RightHoriz2";
                ver = "RightVert2";
                shot = "Shoot2";
                break;
            case 3:
                hor = "RightHoriz3";
                ver = "RightVert3";
                shot = "Shoot3";
                break;
            case 4:
                hor = "RightHoriz4";
                ver = "RightVert4";
                shot = "Shoot4";
                break;
        }

        /*if (playerOne)
        {
            hor = "RightHoriz";
            ver = "RightVert";
            shot = "Shoot";
            owner = "p1";
            color = new Color(1, 1, 1);
        } else
        {
            hor = "RightHoriz2";
            ver = "RightVert2";
            shot = "Shoot2";
            owner = "p2";
            color = new Color(1, 0.6792453f, 0.6792453f);
        }*/

    }

    // Update is called once per frame
    void Update()
    {

        hVal = Input.GetAxisRaw(hor);
        vVal = Input.GetAxisRaw(ver);

        Vector3 lookDirection = new Vector3(hVal, vVal, 0);
        
        if (hVal != 0 && vVal != 0)
            transform.eulerAngles = new Vector3(0, 0,Mathf.Atan2(vVal, hVal) * Mathf.Rad2Deg);

        //if (player.GetComponent<PlayerController>().direction.y > 0 && player.GetComponent<PlayerController>().direction.y >= Mathf.Abs(player.GetComponent<PlayerController>().direction.x))
        if(player.GetComponent<PlayerController>().facing.y > Mathf.Abs(player.GetComponent<PlayerController>().facing.x)
            || (player.GetComponent<PlayerController>().moveVector.y >= Mathf.Abs(player.GetComponent<PlayerController>().moveVector.x)
            && player.GetComponent<PlayerController>().moveVector.y > 0
            && hVal == 0 && vVal == 0))
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.3f);
        else
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

        if (transform.rotation.eulerAngles.z > 90 && transform.rotation.eulerAngles.z < 270)
            GetComponent<SpriteRenderer>().flipY = true;
        else
            GetComponent<SpriteRenderer>().flipY = false;

        if (Input.GetAxisRaw(shot) > 0)
        {
            
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                BulletController newBullet = Instantiate(bullet, firePoint.position, Quaternion.Euler(transform.eulerAngles)) as BulletController;
                newBullet.GetComponent<SpriteRenderer>().color = color;
                newBullet.owner = team;
                newBullet.damage = damage;
                newBullet.speed = speed;
                if (transform.rotation.eulerAngles.z < 135 && transform.rotation.eulerAngles.z > 45)
                    newBullet.GetComponent<SpriteRenderer>().sortingOrder = 0;
                else
                    newBullet.GetComponent<SpriteRenderer>().sortingOrder = 2;
            }
        }
        if (shotCounter>0)
            shotCounter -= Time.deltaTime;
    }
}
