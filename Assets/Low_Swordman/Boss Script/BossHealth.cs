using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{

	public int health = 50;

	public GameObject deathEffect;

	public bool isInvulnerable = false;

    public GameObject Healthbartotal;

	private float currentHealth;

    private Vector3 originalScale;

	private Image image;

	[SerializeField] private AudioClip hurt;

    public BossManager bossManager;

    [SerializeField] private AudioClip rageaudio;

    private void Awake()
    {
        currentHealth = health;
        originalScale = Healthbartotal.transform.localScale;
    }

    public void TakeDamage(int damage)
	{
		
		if (isInvulnerable)
			return;

        NewBehaviourScript.instance.PlaySound(hurt);

        health -= damage;

        Image healthBarImage = Healthbartotal.GetComponent<Image>();
        healthBarImage.fillAmount = (float)health / currentHealth;


        if (health <= 2)
		{
            NewBehaviourScript.instance.PlaySound(rageaudio);
			GetComponent<Animator>().SetBool("IsEnraged", true);
		}

		if (health <= 0)
		{
			Die();
        }
	}

	void Die()
	{
        if (gameObject.name == "BOSS")
        {
            bossManager.Boss1Died();
        }
        else if (gameObject.name == "BOSS 2")
        {
            bossManager.Boss2Died();
        }
    //    Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

}
