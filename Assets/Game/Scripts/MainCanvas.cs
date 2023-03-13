using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    private static MainCanvas mainCanvas;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject levelsMenu;
    [SerializeField] private GameObject gameMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject defeatMenu;
    [SerializeField] private GameObject successMenu;

    private int levelToLoad;

    public static UnityEvent pauseGame = new UnityEvent();
    public static UnityEvent continueGame = new UnityEvent();


    private void Start()
    {
        DontDestroyOnLoad(this);

        if(mainCanvas == null)
        {
            mainCanvas = this;
        }
        else
        {
            Object.Destroy(gameObject);
        }
    }

    #region MainMenu
    public void btn_PlayButton() 
    {
        GetObjectComponent(mainMenu).SetTrigger("HideMenu");
        GetObjectComponent(levelsMenu).SetTrigger("ShowMenu");
    }

    public void btn_AllGames()
    {
        //Open confirmation menu;
    }
    #endregion

    #region LevelsMenu
    public void btn_ExitLevels()
    {
        GetObjectComponent(levelsMenu).SetTrigger("HideMenu");
        GetObjectComponent(mainMenu).SetTrigger("ShowMenu");
    }

    public void btn_LoadLevel(int levelIndex)
    {
        StartCoroutine(LoadLevelAsync(levelIndex));
    }

    public IEnumerator LoadLevelAsync(int index )
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index);

        while (!asyncLoad.isDone)
        {
            yield return null;
            GetObjectComponent(levelsMenu).SetTrigger("HideMenu");
            GetObjectComponent(gameMenu).SetTrigger("ShowMenu");
        }
    }
    #endregion

    #region GameMenu
    public void btn_Pause()
    {
        GetObjectComponent(gameMenu).SetTrigger("HideMenu");
        GetObjectComponent(pauseMenu).SetTrigger("ShowMenu");
        pauseGame.Invoke();
    }
    #endregion

    #region PauseMenu
    public void btn_Continue()
    {
        GetObjectComponent(pauseMenu).SetTrigger("HideMenu");
        GetObjectComponent(gameMenu).SetTrigger("ShowMenu");

        continueGame.Invoke();
    }

    public void btn_Restart()
    {
        StartCoroutine(RestartLevelAsinc());
    }

    public IEnumerator RestartLevelAsinc()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

        while (!asyncLoad.isDone)
        {
            yield return null;
            GetObjectComponent(pauseMenu).SetTrigger("HideMenu");
            GetObjectComponent(gameMenu).SetTrigger("ShowMenu");
        }
    }

    public void btn_Home()
    {
        StartCoroutine(LoadHomeAsync());
    }

    public IEnumerator LoadHomeAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0);

        while (!asyncLoad.isDone)
        {
            yield return null;
            GetObjectComponent(pauseMenu).SetTrigger("HideMenu");
            GetObjectComponent(mainMenu).SetTrigger("ShowMenu");
        }
    }

    public void btn_Sounds()
    {

    }

    public void btn_Music()
    {

    }

    public void btn_AD()
    {

    }
    #endregion

    #region DeadMenu
    public void btn_RestartDead()
    {
        GetObjectComponent(defeatMenu).SetTrigger("HideMenu");
        GetObjectComponent(gameMenu).SetTrigger("ShowMenu");
    }

    public void btn_HomeDead()
    {
        StartCoroutine(DeadHomeAsync());
    }

    public IEnumerator DeadHomeAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0);

        while (!asyncLoad.isDone)
        {
            yield return null;
            GetObjectComponent(defeatMenu).SetTrigger("HideMenu");
            GetObjectComponent(mainMenu).SetTrigger("ShowMenu");
        }
    }
    #endregion

    #region SuccessMenu
    public void btn_NextLevelSuccess()
    {
        GetObjectComponent(successMenu).SetTrigger("HideMenu");
        GetObjectComponent(gameMenu).SetTrigger("ShowMenu");
    }

    public void btn_RestartSuccess()
    {
        GetObjectComponent(successMenu).SetTrigger("HideMenu");
        GetObjectComponent(gameMenu).SetTrigger("ShowMenu");
    }

    public void btn_HomeSuccess()
    {
        StartCoroutine(SuccessLevelAsync());
    }

    public IEnumerator SuccessLevelAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0);

        while (!asyncLoad.isDone)
        {
            yield return null;
            GetObjectComponent(successMenu).SetTrigger("HideMenu");
            GetObjectComponent(mainMenu).SetTrigger("ShowMenu");
        }
    }
    #endregion

    private Animator GetObjectComponent(GameObject obj)
    {
        Animator animator = obj.GetComponent<Animator>();
        return animator;
    }
}
