using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDir;
    //1 -> bottom door
    //2 -> top door
    //3 -> left door
    //4 -> right door

    private RoomTemplates templates;
    private int rand;
    public bool spawned = false;
    public GameObject marker;
    public List<GameObject> distance;

    //public float waitTime = 4f;
   

    void Start(){

        //Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    void Spawn() {
        if (spawned == false){
            if (openingDir == 1)
            {
                //Need a bottom door room
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], new Vector3(transform.position.x, transform.position.y, 0), templates.bottomRooms[rand].transform.rotation);

                //TESTING DOOR AGAINST WALL PROBLEM
                //distance = GameObject.FindGameObjectsWithTag("SpawnPointRoom");
                //if (Physics.CheckSphere(new Vector3(transform.position.x + 10, transform.position.y, 0), 1f))   {
                    //distance.Add(this.gameObject);
                //}

            }
            else if (openingDir == 2)
            {
                //Need a top door
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], new Vector3(transform.position.x, transform.position.y, 0), templates.topRooms[rand].transform.rotation);

            }
            else if (openingDir == 3)
            {
                //Need a left door
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], new Vector3(transform.position.x, transform.position.y, 0), templates.leftRooms[rand].transform.rotation);

            }
            else if (openingDir == 4)
            {
                //Need a right door
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], new Vector3(transform.position.x, transform.position.y, 0), templates.rightRooms[rand].transform.rotation);

            }
            spawned = true;
        }
        

           
    }


    //To ensure room spawn in case of double destroy of two seperate spawn points
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("SpawnPointRoom")){ 
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(templates.closedRoom[0], transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
