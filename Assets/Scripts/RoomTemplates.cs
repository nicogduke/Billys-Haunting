using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] closedRoom;
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public List<GameObject> rooms;

    public float waitTime;

    GameObject Player1;
    GameObject Player2;
    GameObject Player3;
    GameObject Player4;

    public GameObject gameControl;
    public GameObject hud;

    int roomNum;

    bool spawned = true;

    void Update() { 
            
        if (waitTime <= 0 && spawned) {
        //     for (int i = 0; i < rooms.Count; i++)
        //     {
        //         if (rooms[i].GetComponent<AddRoom>().endRoom == true) {
        //             blueRoom = i;
        //             i = rooms.Count;
        //         }
        //     }
        //     redRoom = rooms.Count - 1;

        //     if (SpawnController.p1Team == 1)
        //         roomNum = blueRoom;
        //     else
        //         roomNum = redRoom;

        //     switch (SpawnController.p1Select)
        //     {
        //         case "default":
        //             Player1 = Instantiate(Default, rooms[roomNum].transform.position, Default.transform.rotation) as GameObject;
        //             break;
        //         case "sniper":
        //             Player1 = Instantiate(Sniper, rooms[roomNum].transform.position, Default.transform.rotation) as GameObject;
        //             break;
        //     }

        //     PlayerController player1control = Player1.GetComponent<PlayerController>();
        //     player1control.playerNum = 1;
        //     player1control.teamNum = SpawnController.p1Team;

        //     if (SpawnController.p2Team == 1)
        //         roomNum = blueRoom;
        //     else
        //         roomNum = redRoom;

        //     switch (SpawnController.p2Select)
        //     {
        //         case "default":
        //             Player2 = Instantiate(Default, rooms[roomNum].transform.position, Default.transform.rotation) as GameObject;
        //             break;
        //         case "sniper":
        //             Player2 = Instantiate(Sniper, rooms[roomNum].transform.position, Default.transform.rotation) as GameObject;
        //             break;
        //     }

        //     PlayerController player2control = Player2.GetComponent<PlayerController>();
        //     player2control.playerNum = 2;
        //     player2control.teamNum = SpawnController.p2Team;

        //     if (SpawnController.p3Team == 1)
        //         roomNum = blueRoom;
        //     else
        //         roomNum = redRoom;

        //     switch (SpawnController.p3Select)
        //     {
        //         case "default":
        //             Player3 = Instantiate(Default, rooms[roomNum].transform.position, Default.transform.rotation) as GameObject;
        //             break;
        //         case "sniper":
        //             Player3 = Instantiate(Sniper, rooms[roomNum].transform.position, Default.transform.rotation) as GameObject;
        //             break;
        //     }

        //     PlayerController player3control = Player3.GetComponent<PlayerController>();
        //     player3control.playerNum = 3;
        //     player3control.teamNum = SpawnController.p3Team;

        //     if (SpawnController.p4Team == 1)
        //         roomNum = blueRoom;
        //     else
        //         roomNum = redRoom;

        //     switch (SpawnController.p4Select)
        //     {
        //         case "default":
        //             Player4 = Instantiate(Default, rooms[roomNum].transform.position, Default.transform.rotation) as GameObject;
        //             break;
        //         case "sniper":
        //             Player4 = Instantiate(Sniper, rooms[roomNum].transform.position, Default.transform.rotation) as GameObject;
        //             break;
        //     }

        //     PlayerController player4control = Player4.GetComponent<PlayerController>();
        //     player4control.playerNum = 4;
        //     player4control.teamNum = SpawnController.p4Team;

        //     gameControl.GetComponent<SplitScreen>().enabled = true;

        //     Destroy(GameObject.Find("LoadScreen"));
        //     Instantiate(hud, new Vector3(0, 0, 0), Default.transform.rotation);

        //     spawned = false;
        //     //Destroy(this.gameObject);
        // }
        // else {
        //     waitTime -= Time.deltaTime;
        }
        
    }

    

}
