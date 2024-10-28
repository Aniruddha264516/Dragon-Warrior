
using UnityEngine;

public class EnemyProjectile : EnemiesDamage
{
    [SerializeField] private float speed;
    [SerializeField] private float resetime;
    private float lifetime;
    private Animator anim;
    private bool hit;
    private BoxCollider2D coll;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }
    public void ActiveProjectile()
    {
        hit = false;
        lifetime = 0;
        gameObject.SetActive(true);
        coll.enabled = true;
    }

    private void Update()
    {
        if (hit) return;
        float movementspeed = speed * Time.deltaTime;
        transform.Translate(movementspeed, 0, 0);

        lifetime += Time.deltaTime;
        if(lifetime > resetime)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        base.OnTriggerEnter2D(collision);
        coll.enabled = false;


        if (anim != null)
            anim.SetTrigger("explode");
        else
            gameObject.SetActive(false);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
