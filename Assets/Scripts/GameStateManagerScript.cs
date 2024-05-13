using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public DetectionZone detection_script;
    public Room doors_script;
    public Sprite upOpen;
    public Sprite downOpen;
    public Sprite leftOpen;
    public Sprite rightOpen;

    void Start()
    {
        detection_script = GetComponent<DetectionZone>();
        doors_script = GetComponent<Room>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (detection_script.detectedObject.Count == 0)
        {
            if (doors_script.topDoor.transform.GetChild(0).gameObject.activeInHierarchy)
            {
                doors_script.topDoor.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = upOpen;
                doors_script.topDoor.GetComponent<BoxCollider2D>().enabled = false;
            }
            if (doors_script.bottomDoor.transform.GetChild(0).gameObject.activeInHierarchy)
            {
                doors_script.bottomDoor.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = downOpen;
                doors_script.bottomDoor.GetComponent<BoxCollider2D>().enabled = false;
            }
            if (doors_script.rightDoor.transform.GetChild(0).gameObject.activeInHierarchy)
            {
                doors_script.rightDoor.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = rightOpen;
                doors_script.rightDoor.GetComponent<BoxCollider2D>().enabled = false;
            }
            if (doors_script.leftDoor.transform.GetChild(0).gameObject.activeInHierarchy)
            {
                doors_script.leftDoor.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = leftOpen;
                doors_script.leftDoor.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}
