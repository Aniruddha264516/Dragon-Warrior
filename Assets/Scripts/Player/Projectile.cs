
using UnityEngine;

public class Projecttile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private AudioClip ExplodeSound;
    private float direction;
    private bool hit;
    private Animator anim;
    private BoxCollider2D boxcollider;
    private float lifetime;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxcollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (hit) return;
            float movementspeed = speed * Time.deltaTime * direction;
        transform.Translate(movementspeed , 0 , 0);


        lifetime += Time.deltaTime;
        if (lifetime > 5) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        NewBehaviourScript.instance.PlaySound(ExplodeSound);
        hit = true;
        boxcollider.enabled = false;
        anim.SetTrigger("explode");

        if (collision.tag == "Enemy")
        {
            if(collision.GetComponent<EnemyHealth>() != null)
                collision.GetComponent<EnemyHealth>().TakeDamage(1);
            if(collision.GetComponent<BossHealth>() != null)
                collision.GetComponent <BossHealth>().TakeDamage(1);
        }


    }
    

    public void setdirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxcollider.enabled = true;

        float localscalex = transform.localScale.x;
        if(Mathf.Sign(localscalex) != _direction)
            localscalex = -localscalex;

        transform.localScale = new Vector3(localscalex, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
