
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadscene : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Quit()
    {
        Debug.Log("quit successfull");
        Application.Quit();
      //  UnityEditor.EditorApplication.isPlaying = false;
    }
}
