using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject[] enemyesPool;
    private int enemyesNumber;

    private void Start()
    {
        enemyesPool = GameObject.FindGameObjectsWithTag("Bacteria");
        
        for(int i = 0; i < enemyesPool.Length; i++)
        {
            enemyesNumber++;
        }
    }

    public void Kills()
    {
        enemyesNumber--;

        if(enemyesNumber <= 0)
        {
            Invoke("CallCanvas", 1.2f);
        }
    }

    private void CallCanvas()
    {
        GameObject mainCanvasObject = GameObject.FindGameObjectWithTag("MainCanvas");
        MainCanvas mainCanvasScript = mainCanvasObject.GetComponent<MainCanvas>();
        mainCanvasScript.OpenSuccessMenu();
    }
}