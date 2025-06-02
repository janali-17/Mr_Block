using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private GameObject levelPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private LevelManager levelManager;

    private SoundManager soundManager;
    public int levelNumber = 1;


    private void Awake()
    {
        AddListener();
    }

    private void Start()
    {
        UpdateLevelText();
        soundManager = FindObjectOfType<SoundManager>();

        if (soundManager == null)
        {
            Debug.Log("Sound Manager not Found");
        }
    }

    public void ShowGameWinUI()
    {
        SetGameOverPanel(true);
        gameOverText.text = "Game Completed !!!";
        gameOverText.color = Color.green;
        HideLevelPanel();
    }
    
    public void ShowGameLoseUI()
    {
        SetGameOverPanel(true);
        gameOverText.text = "Game Over !!!";
        gameOverText.color = Color.red;
        HideLevelPanel();
    }

    private void SetGameOverPanel(bool isActive)
    {
        gameOverPanel.SetActive(isActive);
    }

    private void AddListener()
    {
        restartButton.onClick.AddListener(RestartButton);
        mainMenuButton.onClick.AddListener(MainMenuButton);
    }

    private void MainMenuButton()
    {
        soundManager.PlayButtonClickAudio();
        soundManager.DestroySoundManager();
        levelManager.LoadMainMenu();
    }

    private void RestartButton()
    {
        soundManager.PlayButtonClickAudio();
        levelManager.RestartLevel();
        SetGameOverPanel(false);
    }


    private void HideLevelPanel()
    {
        levelPanel.SetActive(false);
    }

    private void UpdateLevelText()
    {
        levelText.text = "Level: " + levelNumber;   
    }
}
