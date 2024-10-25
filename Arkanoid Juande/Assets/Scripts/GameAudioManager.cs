using UnityEngine;

public class GameAudioManager : MonoBehaviour
{
    public AudioClip brickBreakSound; // Sonido para romper un bloque
    private AudioSource audioSource; // Fuente de audio

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // Añade un AudioSource al GameObject
        audioSource.playOnAwake = false; // No reproducir automáticamente
    }

    public void PlayBrickBreakSound()
    {
        audioSource.PlayOneShot(brickBreakSound); // Reproduce el sonido
    }
}

