using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource soundFXSource;

    public AudioClip LevelCompleteAudio;
    public AudioClip GameOverAudio;
    public AudioClip ButtonClickAudio;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        PlayBackGroundMusic();
    }

    public void PlayLevelCompleteAudio()
    {
        if (soundFXSource != null && LevelCompleteAudio != null)
        {
            soundFXSource.PlayOneShot(LevelCompleteAudio);
        }
    }
    public void PlayGameOverAudio()
    {
        if (soundFXSource != null && ButtonClickAudio != null)
        {
            soundFXSource.PlayOneShot(ButtonClickAudio);
        }
    }
    public void PlayButtonClickAudio()
    {
        if (soundFXSource != null && GameOverAudio != null)
        {
            soundFXSource.PlayOneShot(GameOverAudio);
        }
    }
    public void PlayBackGroundMusic()
    {
        if (bgmSource != null && bgmSource.clip != null && !bgmSource.isPlaying)
        {
            bgmSource.Play();
        }
    }
    public void DestroySoundManager()
    {
        Destroy(gameObject);
    }
}
