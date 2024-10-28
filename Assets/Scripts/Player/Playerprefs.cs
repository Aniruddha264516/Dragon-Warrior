using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    public int playerHealth = 3; // Default health value

    void Start()
    {
        LoadHealth();
    }

    void Update()
    {
        // Update health here based on your game logic
        // For demonstration purposes, we'll just save health when it's updated.
        if (Input.GetKeyDown(KeyCode.S)) // Example: Save health when 'S' is pressed
        {
            SaveHealth();
            Debug.Log("playerhealth saved");
        }
    }

    public void SaveHealth()
    {
        PlayerPrefs.SetInt("PlayerHealth", playerHealth);
        PlayerPrefs.Save();
    }

    public void LoadHealth()
    {
        if (PlayerPrefs.HasKey("PlayerHealth"))
        {
            playerHealth = PlayerPrefs.GetInt("PlayerHealth");
        }
    }

    void OnApplicationQuit()
    {
        SaveHealth(); // Save health when the game is closed
    }
}
