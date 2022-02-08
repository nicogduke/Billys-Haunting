using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockController : MonoBehaviour
{
    public int health;

    public Slider slider;

    public GameObject hp;
    public GameObject reset;

    public Vector3 spawn;

    public GameObject[] respawns;

    // Start is called before the first frame update
    void Start()
    {
        respawns = GameObject.FindGameObjectsWithTag("Item");

        foreach (GameObject respawn in respawns)
        {
            if (respawn.transform.position.x == transform.position.x && respawn.transform.position.y == transform.position.y)
            {
                Destroy(respawn.gameObject);
            }
        }

        health = 50;
        spawn.x = transform.position.x;
        spawn.y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
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

        if (collision.gameObject.tag == "Player")
        {

            Vector3 direction = transform.position - collision.gameObject.transform.position;
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {

                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

            }
            else
            {

                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }

        }
    }
    

    private void death()
    {
        float tempX = transform.position.x;
        float tempY = transform.position.y;
        Destroy(this.gameObject);
        Instantiate(hp, new Vector3(tempX, tempY, 0), Quaternion.identity);
        GameObject spawner = Instantiate(reset, new Vector3(0, 0, 0), Quaternion.identity);
        spawner.GetComponent<Timer>().blockSpawn = spawn;
    }
}
