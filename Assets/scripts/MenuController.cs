using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;
    void Start()
    {
        playButton.Select();
    }

    // Update is called once per frame
    void Update()
    {
        playButton.onClick.AddListener(NextScene);
        quitButton.onClick.AddListener(Quit);
    }

    void NextScene()
    {
        SceneManager.LoadScene(1);
    }

    void Quit()
    {
        Application.Quit();
    }
}
