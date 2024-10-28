
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpoint;
    private Transform currentCheckpoint;
    private Health playerHealth;
    private UIManager manager;


    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        manager = FindObjectOfType<UIManager>();
    }

    public void CheckRespawn()
    {

        if(currentCheckpoint == null)
        {
            manager.GameOver();
            return;
        }
        playerHealth.Respawn(); //Restore player health and reset animation
            transform.position = currentCheckpoint.position; //Move player to checkpoint location

            //Move the camera to the checkpoint's room
            Camera.main.GetComponent<Cameracontroller>().MoveToNewRoom(currentCheckpoint.parent);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            NewBehaviourScript.instance.PlaySound(checkpoint);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("Appear");
        }
    }
}
