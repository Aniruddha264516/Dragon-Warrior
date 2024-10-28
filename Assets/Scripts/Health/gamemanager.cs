using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int playerHealth = 3;
    public UIHealthManager uiHealthManager; // Reference to the UIHealthManager script

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadHealth();
        UpdateHealthUI();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateHealthUI();
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

    private void UpdateHealthUI()
    {
        if (uiHealthManager != null)
        {
            uiHealthManager.UpdateHealthUI(); // Ensure UI is updated
        }
    }

    private void OnApplicationQuit()
    {
        SaveHealth();
    }
}
