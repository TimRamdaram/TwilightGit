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
        // �������� ���� ��� ����� ��� ������������ �� ����� ����
    }

    void ShowSettings()
    {
        Debug.Log("Settings button pressed.");
        // �������� ���� ��� ����� ��� ������ ��������
    }

    void ShowSaves()
    {
        Debug.Log("Saves button pressed.");
        // �������� ���� ��� ����� ��� ������ ����������
    }

    void QuitGame()
    {
        Debug.Log("Quit button pressed.");
        Application.Quit();
    }
}
