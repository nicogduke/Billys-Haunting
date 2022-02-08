using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{

    public GameObject Default;
    public GameObject Sniper;

    public float waitTime = 5;
    //private bool spawnedPlayer1 = false;
    //private bool spawnedPlayer2 = false;

    private int blueRoom;
    private int redRoom;

    RoomTemplates roomsList;

    GameObject Player1;
    GameObject Player2;

    // Start is called before the first frame update
     void Start() {

        roomsList = GetComponent<RoomTemplates>();

        while (waitTime < 0) { 
            waitTime -= Time.deltaTime;
        }
        for (int i = 0; i < roomsList.rooms.Count; i++)
        {
            if (roomsList.rooms[i].GetComponent<AddRoom>().endRoom == true)
            {
                blueRoom = i;
                i = roomsList.rooms.Count;
            }
        }
        redRoom = roomsList.rooms.Count - 1;

        switch (SpawnController.p2Select)
        {
            case "default":
                Player2 = Instantiate(Default, roomsList.rooms[redRoom].transform.position, Default.transform.rotation) as GameObject;
                break;
            case "sniper":
                Player2 = Instantiate(Sniper, roomsList.rooms[redRoom].transform.position, Default.transform.rotation) as GameObject;
                break;
        }
        PlayerController player2control = Player2.GetComponent<PlayerController>();
        //player2control.playerOne = false;

        switch (SpawnController.p1Select)
        {
            case "default":
                Player1 = Instantiate(Default, roomsList.rooms[blueRoom].transform.position, Default.transform.rotation) as GameObject;
                break;
            case "sniper":
                Player1 = Instantiate(Sniper, roomsList.rooms[blueRoom].transform.position, Default.transform.rotation) as GameObject;
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        GameObject homeButton = GameObject.Find("HomeButton");
        homeButton.transform.position = new Vector3(Screen.width / 2, Screen.height - 50, 0);
        /**
         roomsList = GetComponent<RoomTemplates>();

         if (waitTime <= 0 && (spawnedPlayer1 == false || spawnedPlayer2 == false))
         {
             for (int i = 0; i < roomsList.rooms.Count; i++)
             {
                 if (i == roomsList.rooms.Count - 1)
                 {
                     
                     switch (SpawnController.p2Select)
                     {
                         case "default":
                     Player2 = Instantiate(Default, roomsList.rooms[i].transform.position, Default.transform.rotation) as GameObject;
                             break;
                     
                         case "sniper":
                             Player2 = Instantiate(Sniper, roomsList.rooms[i].transform.position, Sniper.transform.rotation) as GameObject;
                             break;
                     
                     }

                     PlayerController player2control = Player2.GetComponent<PlayerController>();
                         player2control.playerOne = false;
                         spawnedPlayer2 = true;
                 }
                 if (roomsList.rooms[i].GetComponent<AddRoom>().endRoom == true && spawnedPlayer1 == false)
                 {
                 
                 switch (SpawnController.p1Select)
                 {
                     case "default":
                     Player1 = Instantiate(Default, roomsList.rooms[i].transform.position, Default.transform.rotation) as GameObject;
                               break;
                  
                       case "sniper":
                           Player1 = Instantiate(Sniper, roomsList.rooms[i].transform.position, Sniper.transform.rotation) as GameObject;
                           break;
                       
                         }
                     spawnedPlayer1 = true;
                 }
             }

         }
         else
         {
             waitTime -= Time.deltaTime;
         }
             **/

    }
}
