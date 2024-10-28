
using UnityEngine;

public class RainSound : MonoBehaviour
{
    public ParticleSystem rainParticles; // Reference to the Particle System
    public AudioSource rainSound; // Reference to the Audio Source

    void Start()
    {
        if (rainParticles == null)
        {
            rainParticles = GetComponent<ParticleSystem>();
        }

        if (rainSound == null)
        {
            rainSound = GetComponent<AudioSource>();
        }

        // Start the rain effect
        StartRainEffect();
    }

    void Update()
    {
        // Optionally, control the rain effect based on certain conditions (e.g., weather, player location)
        // For now, it just runs continuously
    }

    public void StartRainEffect()
    {
        // Play the particle system
        if (!rainParticles.isPlaying)
        {
            rainParticles.Play();
        }

        // Play the rain sound if it's not already playing
        if (!rainSound.isPlaying)
        {
            rainSound.Play();
        }
    }

    public void StopRainEffect()
    {
        // Stop the particle system
        if (rainParticles.isPlaying)
        {
            rainParticles.Stop();
        }

        // Stop the rain sound
        if (rainSound.isPlaying)
        {
            rainSound.Stop();
        }
    }
}
