
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform player;
    [SerializeField] private float aheaddistance;
    [SerializeField] private float cameraspeed;
    private float lookahead;
    private float currentposx;
    private Vector3 velocity = Vector3.zero;
    private bool followplayer = true;


    private void Update()
    {
        if (followplayer)
        {
            //room camera//
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentposx, transform.position.y, transform.position.z), ref velocity, speed);

            //follow player
            transform.position = new Vector3(player.position.x + lookahead, transform.position.y, transform.position.z);

            lookahead = Mathf.Lerp(lookahead, (aheaddistance * player.localScale.x), Time.deltaTime * cameraspeed);
        }
       
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish Point"))  // Check if the player reached the finish point
        {
            followplayer = false;  // Stop following the player
        }
    }

    public void Movetonewroom(Transform _newroom)
    {
        currentposx = _newroom.position.x;
    }

  
}
