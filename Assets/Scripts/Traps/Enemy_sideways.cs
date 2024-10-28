
using UnityEngine;

public class Enemy_sideways : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float movementdistence;
    [SerializeField] private AudioClip SawSound;
    private bool movingleft;
    private float leftEdge;
    private float rightEdge;
    

    private void Awake()
    {
        leftEdge = transform.position.x - movementdistence; // 4.10 - 3 = 1.10
        rightEdge = transform.position.x + movementdistence; // 4.10 + 3 = 7.10
    }

   private void Update()
    {
        if(movingleft)
        {
            if(transform.position.x > leftEdge)
            {                                    // 4.10 - 5                                             // -3.72
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                movingleft = false;
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                movingleft = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Hitting something!");
        if(collision.tag == "Player")
        {
            NewBehaviourScript.instance.PlaySound(SawSound);
            collision.GetComponent<Health>().Takedamage(damage);
        }
    }
}
