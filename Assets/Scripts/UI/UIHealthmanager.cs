using UnityEngine;
using UnityEngine.UI;

public class UIHealthManager : MonoBehaviour
{
    public Image healthBarTotal;  // The static background health bar
    public Image healthBarCurrent; // The dynamic current health bar

    public float maxHealth = 3; // Maximum health value (set as needed)

    private void Start()
    {
        UpdateHealthUI();
    }

    public void UpdateHealthUI()
    {
        float currentHealth = GameManager.Instance.playerHealth;

        // Calculate fill amount based on the current health and maximum health
        float fillAmount = currentHealth / maxHealth;

        Debug.Log($"Current Health: {currentHealth}, Fill Amount: {fillAmount}");


        // Update the health bar current fill amount
        if (healthBarCurrent != null)
        {
            healthBarCurrent.fillAmount = fillAmount;
        }
    }
}
