using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AudioManager : MonoBehaviour
{
    // AudioSource del GameObject
    private AudioSource audioSource;

    // Título del audio actual
    public GameObject title;

    // Array de AudioClips y nombres de los audios
    public AudioClip[] audioClips;
    public string[] audioNames;

    // Index de los clips
    private int audioIndex = 0;

    // Al empezar
    void Start()
    {
        // Obtiene la componente AudioSource
        audioSource = GetComponent<AudioSource>();

        // Inserta el clip correspondiente al Index
        audioSource.clip = audioClips[audioIndex];

        // Muestra el título del audio
        ShowAudioName();
    }

    // Cambia y reproduce el siguiente clip
    public void NextAudio()
    {
        // Aumenta el Index +1
        audioIndex++;

        // Si el Index es igual o mayor al número de clips en total
        if (audioIndex >= audioClips.Length)
        {
            // Index se reinicia a O
            audioIndex = 0;
        }

        // Reproduce el audio
        StartAudio();
    }

    // Cambia y reproduce al anterior clip
    public void PreviousAudio()
    {
        // Disminuye el Index -1
        audioIndex--;

        // Si el Index es menor a 0
        if (audioIndex < 0)
        {
            // Index obtiene el número total de clips
            audioIndex = audioClips.Length - 1;
        }

        // Reproduce el audio
        StartAudio();
    }

    // Empieza y reanuda el clip actual
    public void PlayAudio()
    {
        // Si el audio no se está reproduciendo
        if (!audioSource.isPlaying)
        {
            // Reproduce el clip
            audioSource.Play();
        }
    }

    // Pausa el clip actual
    public void PauseAudio()
    {
        audioSource.Pause();
    }

    // Detiene y reinicia el clip actual
    public void StopAudio()
    {
        audioSource.Stop();
    }

    // Reproduce una clip aleatorio
    public void RandomAudio()
    {
        // Obtiene un valor aleatorio entre 0 y el número total de clips
        int randomIndex = Random.Range(0, audioClips.Length);

        // Index recibe el valor aleatorio
        audioIndex = randomIndex;

        // Reproduce el audio
        StartAudio();
    }

    // Muestra el nombre del audio
    private void ShowAudioName()
    {
        // Cambia el título correspondiente al Index
        title.GetComponent<TextMeshProUGUI>().text = audioNames[audioIndex];
    }

    // Reproduce el audio
    public void StartAudio()
    {
        // Inserta el clip correspondiente al Index
        audioSource.clip = audioClips[audioIndex];

        // Detiene y reproduce el audio
        StopAudio();
        PlayAudio();

        // Muestra el nombre del audio
        ShowAudioName();
    }
}