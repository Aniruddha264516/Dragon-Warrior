
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform previousroom;
    [SerializeField] private Transform nextroom;
    [SerializeField] private camerafollow cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "player")
        {
            if (collision.transform.position.x < transform.position.x)

            {
                cam.Movetonewroom(nextroom);
                nextroom.GetComponent<Room>().ActiveRoom(true);
                previousroom.GetComponent <Room>().ActiveRoom(false);
            }
            else
            {
                cam.Movetonewroom(previousroom);
                previousroom.GetComponent<Room>().ActiveRoom(true);
                nextroom.GetComponent <Room>().ActiveRoom(false);
            }
        }
    }

}
