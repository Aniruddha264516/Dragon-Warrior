using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fader : MonoBehaviour
{
    public Image fadePanel;          // Assign the fade image in the inspector
                                     //  public GameObject playerHealthBar; // Assign the player health bar GameObject
    public GameObject bossHealthBar;   // Assign the boss health bar GameObject
    public GameObject creditsPanel;    // Assign the credits panel GameObject
    public float fadeDuration = 2f;   // Time it takes to fade out

    private bool isFading = false;

    void Start()
    {
        // Ensure the panel is transparent at the start
        Color color = fadePanel.color;
        color.a = 0;
        fadePanel.color = color;

        // Ensure the credits panel is hidden at the start
        creditsPanel.SetActive(false);
    }

    public void StartFadeOut()
    {
        if (!isFading)
        {
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeOut()
    {
        isFading = true;

        // Disable the health bars before starting the fade
        //   playerHealthBar.SetActive(false);
        bossHealthBar.SetActive(false);

        float elapsedTime = 0f;
        Color color = fadePanel.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadePanel.color = color;
            yield return null;
        }

        // Ensure the fade panel is fully opaque
        color.a = 1;
        fadePanel.color = color;

        // After fade, show the credits
        ShowCredits();
    }

    void ShowCredits()
    {
        creditsPanel.SetActive(true);  // Show the credits panel
    }
}

