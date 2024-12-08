using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public Button startButton;
    public Button optionsButton;
    public Button exitButton;
    public Button backButton;
    public bool isGameActive;
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(StartGame);
        btn.onClick.AddListener(OptionsMenu);
        btn.onClick.AddListener(ExitGame);
        btn.onClick.AddListener(BackButton);
    }

    // main menu and option buttons

    public void StartGame()
    {
        SceneManager.LoadScene("Main Game");
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene("Options Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackButton()
    {
        SceneManager.LoadScene("Title Screen");
    }

    void Update()
    {
        
    }
}
