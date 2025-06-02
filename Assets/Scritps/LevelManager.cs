using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private const int mainMenuIndex = 0;

    private int currentLevel;


    [SerializeField] private LevelUI levelUi;

    private void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    public void OnPlayerDeath() => levelUi.ShowGameLoseUI();
    public void OnLevelComplete() => LoadNextLevel();
    public void RestartLevel() => SceneManager.LoadScene(currentLevel);
    public void LoadMainMenu() => SceneManager.LoadScene(mainMenuIndex);


    private void LoadNextLevel()
    {
        int nextSceneIndex = currentLevel + 1;
        int totalNumberOfScenes = SceneManager.sceneCountInBuildSettings;

        if (nextSceneIndex < totalNumberOfScenes)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            levelUi.ShowGameWinUI();
        }
    }

}
