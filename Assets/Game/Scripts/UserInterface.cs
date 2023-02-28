using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UserInterface : MonoBehaviour
{
    private static UserInterface userInterfaceInstance;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject levelsMenu;
    [SerializeField] private GameObject gameMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject defeatMenu;
    [SerializeField] private GameObject successMenu;

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.T)) { SceneManager.LoadScene(1); }
    }
    private void Start()
    {
        DontDestroyOnLoad(this);

        if(userInterfaceInstance == null)
        {
            userInterfaceInstance = this;
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
        SceneManager.LoadScene(levelIndex);
        GetObjectComponent(levelsMenu).SetTrigger("HideMenu");
        GetObjectComponent(gameMenu).SetTrigger("ShowMenu");
    }
    #endregion

    #region GameMenu
    public void btn_Pause()
    {
        GetObjectComponent(gameMenu).SetTrigger("HideMenu");
        GetObjectComponent(pauseMenu).SetTrigger("ShowMenu");
    }
    #endregion

    #region PauseMenu
    public void btn_Continue()
    {
        GetObjectComponent(pauseMenu).SetTrigger("HideMenu");
        GetObjectComponent(gameMenu).SetTrigger("ShowMenu");
    }

    public void btn_Restart()
    {
        GetObjectComponent(pauseMenu).SetTrigger("HideMenu");
        GetObjectComponent(gameMenu).SetTrigger("ShowMenu");
    }

    public void btn_Home()
    {
        GetObjectComponent(pauseMenu).SetTrigger("HideMenu");
        GetObjectComponent(mainMenu).SetTrigger("ShowMenu");
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
        GetObjectComponent(defeatMenu).SetTrigger("HideMenu");
        GetObjectComponent(mainMenu).SetTrigger("ShowMenu");
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
        GetObjectComponent(successMenu).SetTrigger("HideMenu");
        GetObjectComponent(mainMenu).SetTrigger("ShowMenu");
    }
    #endregion

    private Animator GetObjectComponent(GameObject obj)
    {
        Animator animator = obj.GetComponent<Animator>();
        return animator;
    }
}
