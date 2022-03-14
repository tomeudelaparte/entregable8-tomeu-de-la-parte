using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    public GameObject title;
    public AudioClip[] audioClips;
    public string[] audioNames;

    private int audioIndex = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = audioClips[audioIndex];

        ShowAudioName();
    }

    public void nextAudio()
    {
        audioIndex++;

        if (audioIndex >= audioClips.Length)
        {
            audioIndex = 0;
        }

        audioSource.clip = audioClips[audioIndex];

        StartAudio();
    }

    public void backAudio()
    {
        audioIndex--;

        if (audioIndex < 0)
        {
            audioIndex = audioClips.Length - 1;
        }

        StartAudio();
    }

    public void PlayAudio()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void PauseAudio()
    {
        audioSource.Pause();
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }

    public void RandomAudio()
    {
        int randomIndex = Random.Range(0, audioClips.Length);

        audioIndex = randomIndex;

        StartAudio();
    }

    public void StartAudio()
    {
        audioSource.clip = audioClips[audioIndex];

        StopAudio();
        PlayAudio();

        ShowAudioName();
    }

    private void ShowAudioName()
    {
        title.GetComponent<TextMeshProUGUI>().text = audioNames[audioIndex];
    }
}
