using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public Button settingsButton;
    public Button savesButton;
    public Button quitButton;

    void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        settingsButton.onClick.AddListener(ShowSettings);
        savesButton.onClick.AddListener(ShowSaves);
        quitButton.onClick.AddListener(QuitGame);
    }

    void PlayGame()
    {
        Debug.Log("Play button pressed.");
        // Добавьте свой код здесь для переключения на сцену игры
    }

    void ShowSettings()
    {
        Debug.Log("Settings button pressed.");
        // Добавьте свой код здесь для показа настроек
    }

    void ShowSaves()
    {
        Debug.Log("Saves button pressed.");
        // Добавьте свой код здесь для показа сохранений
    }

    void QuitGame()
    {
        Debug.Log("Quit button pressed.");
        Application.Quit();
    }
}
