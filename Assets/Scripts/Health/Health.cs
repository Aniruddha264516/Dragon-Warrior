
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startinghealth;
    public float currenthealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iframes")]
    [SerializeField] private float iframesduration;
    [SerializeField] private float numberofflashes;
    private SpriteRenderer spriteRend;


    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    private bool invulnerable;

    [Header("Death Sound")]
    [SerializeField] private AudioClip DeathSound;

    [Header("Hurt Sound")]
    [SerializeField] private AudioClip HurtSound;
    private void Awake()
    {
        currenthealth = startinghealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void Takedamage(float _damage)
    {
        currenthealth = Mathf.Clamp(currenthealth - _damage, 0, startinghealth);
       
        if(currenthealth > 0)
        {
            NewBehaviourScript.instance.PlaySound(HurtSound);
            anim.SetTrigger("hurt");
            StartCoroutine(invulnerability());
        }

        else
        {
            if(!dead)
            {
               
                anim.SetTrigger("die");


                // player
                 if(GetComponent<PlayerMovement>() != null)
                GetComponent<PlayerMovement>().enabled = false;

                 // Enemy
                 if(GetComponentInParent<EnemyPatrol>() != null)
                    GetComponentInParent<EnemyPatrol>().enabled = false;

                 if (GetComponentInParent<EnemyPatrol>() != null)
                 GetComponent<MeleeEnemy>().enabled = false;
                dead = true;

                NewBehaviourScript.instance.PlaySound(DeathSound);
            }
        }
    }

 public void AddHealth(float _value)
    {
        currenthealth = Mathf.Clamp(currenthealth + _value, 0, startinghealth);
    }



    private IEnumerator invulnerability()
    {
        Physics2D.IgnoreLayerCollision(10 , 11 , true);
        for(int i = 0; i < numberofflashes; i++)
        {
            spriteRend.color = new Color(1 ,0 , 0 , 0.5f);
            yield return new WaitForSeconds(iframesduration / (numberofflashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iframesduration / (numberofflashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
        invulnerable = false;
    }

    public void Respawn()
    {
        dead = false;
        AddHealth(startinghealth);
        anim.ResetTrigger("die");
        anim.Play("Idle");
        StartCoroutine(invulnerability());
        foreach (Behaviour component in components)
            component.enabled = true;
    }



    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

  
}
