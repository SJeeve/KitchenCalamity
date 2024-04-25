using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Room : MonoBehaviour
{
    [SerializeField] GameObject topDoor;
    [SerializeField] GameObject bottomDoor;
    [SerializeField] GameObject rightDoor;
    [SerializeField] GameObject leftDoor;

    //SpecialRoom dictates whether a room will generate as a normal or special room
    /*
    0 -> normal room
    1 -> treasure room
    2 -> shop room
    3 -> boss room
    */
    private int SpecialRoom = 0;

    public Vector2Int RoomIndex { get; set; }

    public void OpenDoor(Vector2Int direction)
    {
        if(direction == Vector2Int.up)
        {
            topDoor.transform.GetChild(0).gameObject.SetActive(true);
        }

        if (direction == Vector2Int.down)
        {
            bottomDoor.transform.GetChild(0).gameObject.SetActive(true);
        }

        if (direction == Vector2Int.right)
        {
            rightDoor.transform.GetChild(0).gameObject.SetActive(true);
        }

        if (direction == Vector2Int.left)
        {
            leftDoor.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
