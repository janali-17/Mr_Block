using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    private const int firstLevel = 1;
    [SerializeField]private SoundManager soundManager;
    
    public void Play()
    {
        soundManager.PlayButtonClickAudio();
        SceneManager.LoadScene(firstLevel);
    }

    public void Quit()
    {
        soundManager.PlayButtonClickAudio();
        Application.Quit();
    }
}
