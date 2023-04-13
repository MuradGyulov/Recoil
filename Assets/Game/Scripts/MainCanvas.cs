using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor;
using YG;

public class MainCanvas : MonoBehaviour
{
    private static MainCanvas mainCanvas;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject defeatMenu;
    [SerializeField] private GameObject succesMenu;
    [SerializeField] private GameObject levelsMenu;
    [SerializeField] private GameObject allGamesMenu;


    private void Start()
    {
        DontDestroy();
    }

    private void DontDestroy()
    {
        DontDestroyOnLoad(this);

        if (mainCanvas == null) 
        {
            mainCanvas = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    public void btn_OpenLevelsMenu()
    {
        GetObjectComponent(mainMenu).SetTrigger("HideMenu");
        GetObjectComponent(levelsMenu).SetTrigger("ShowMenu");
    }

    public void btn_CloseLevelsMenu()
    {
        GetObjectComponent(levelsMenu).SetTrigger("HideMenu");
        GetObjectComponent(mainMenu).SetTrigger("ShowMenu");
    }

    public void OpenAllGamesMenu()
    {
        GetObjectComponent(allGamesMenu).SetTrigger("ShowMenu");
    }

    public void AllGames_NO()
    {
        GetObjectComponent(allGamesMenu).SetTrigger("HideMenu");
    }

    public void AllGames_YES()
    {
        GetObjectComponent(allGamesMenu).SetTrigger("HideMenu");
    }

    public void btn_LoadSelectedLevel(int levelIndex)
    {
        StartCoroutine(LoadLevelAsync(levelIndex, levelsMenu, gameMenu));
    }

    public void btn_PauseGame()
    {
        Time.timeScale = 0;
        GetObjectComponent(gameMenu).SetTrigger("HideMenu");
        GetObjectComponent(pauseMenu).SetTrigger("ShowMenu");
    }

    public void btn_ResumeGame()
    {
        Time.timeScale = 1;
        GetObjectComponent(pauseMenu).SetTrigger("HideMenu");
        GetObjectComponent(gameMenu).SetTrigger("ShowMenu");
    }

    public void btn_LoadNextLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(LoadLevelAsync(sceneIndex, succesMenu, gameMenu));
    }

    public void OpenSuccessMenu()
    {
        GetObjectComponent(gameMenu).SetTrigger("HideMenu");
        GetObjectComponent(succesMenu).SetTrigger("ShowMenu");
        Time.timeScale = 0;
    }

    public void btn_RestartLevel(GameObject menu)
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        switch (menu.name)
        {
            case "PauseMenu":
                StartCoroutine(LoadLevelAsync(sceneIndex, pauseMenu, gameMenu));
                break;
            case "DefeatMenu":
                StartCoroutine(LoadLevelAsync(sceneIndex, defeatMenu, gameMenu));
                break;
            case "SuccessMenu":
                StartCoroutine(LoadLevelAsync(sceneIndex, succesMenu, gameMenu));
                break;
        }

        Time.timeScale = 1;
    }

    public void btn_BackToMainMenu(GameObject menu)
    {
        switch (menu.name)
        {
            case "PauseMenu":
                StartCoroutine(LoadLevelAsync(0, pauseMenu, mainMenu));
                break;
            case "DefeatMenu":
                StartCoroutine(LoadLevelAsync(0, defeatMenu, mainMenu));
                break;
            case "SuccessMenu":
                StartCoroutine(LoadLevelAsync(0, succesMenu, mainMenu));
                break;
        }

        Time.timeScale = 1;
    }


    private Animator GetObjectComponent(GameObject menu)
    {
        Animator animator = menu.GetComponent<Animator>();
        return animator;
    }

    private IEnumerator LoadLevelAsync(int index, GameObject hideMenu, GameObject showMenu)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index);

        while (!asyncLoad.isDone)
        {
            yield return null;
            Time.timeScale = 1;

            GetObjectComponent(hideMenu).SetTrigger("HideMenu");
            GetObjectComponent(showMenu).SetTrigger("ShowMenu");
        }
    }
}