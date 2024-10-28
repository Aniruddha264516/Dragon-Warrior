
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
   public static NewBehaviourScript instance { get; private set;}
    private AudioSource source;
    private AudioSource MusicSource;
    private void Awake()
    {
        source = GetComponent<AudioSource>();
        MusicSource = transform.GetChild(0).GetComponent<AudioSource>();
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }

        changeMusicVolume(0);
        ChangesoundVolume(0);

    }

    public void PlaySound(AudioClip _sound)
    {
      source.PlayOneShot(_sound);
    }

   

    public void ChangesoundVolume(float _change)
    {
        changesourceVolume(1 , "SoundVolume" , _change , source);
    }

    public void changemusicVolume(float _change)
    {
        changesourceVolume(0.3f , "MusicVolume" , _change , MusicSource);
    }

    public void changeMusicVolume(float _change)
    {
        changesourceVolume(0.3f , "MusicVolume" , _change , MusicSource);
    }
    private void changesourceVolume(float baseVolume , string VolumeName , float Change , AudioSource source)
    {
        float currentVolume = PlayerPrefs.GetFloat(VolumeName , 1);
        currentVolume += Change;

        if (currentVolume > 1)
        {
            currentVolume = 0;
        }
        else if (currentVolume < 0)
        {
            currentVolume = 1;
        }

        float finalVolume = currentVolume * baseVolume;
        source.volume = finalVolume;

        PlayerPrefs.SetFloat(VolumeName , currentVolume);
    }
   
}
