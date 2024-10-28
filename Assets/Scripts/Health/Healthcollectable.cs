
using Unity.VisualScripting;
using UnityEngine;

public class Healthcollectable : MonoBehaviour
{
    [SerializeField] private float healthvalue;
    [SerializeField] private AudioClip pickupsound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        NewBehaviourScript.instance.PlaySound(pickupsound);  
        if(collision.tag == "Player")
            collision.GetComponent<Health>().AddHealth(healthvalue);
         gameObject.SetActive(false);
    }
}
