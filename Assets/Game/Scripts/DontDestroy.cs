using UnityEngine;
using YG;

public class DontDestroy : MonoBehaviour
{
    private static DontDestroy dontDestroy;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            YandexGame.savesData.savesCompletedLevels = 122;
            YandexGame.SaveProgress();
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(this);

        if (dontDestroy == null)
        {
            dontDestroy = this;
        }
        else
        {
            Object.Destroy(gameObject);
        }
    }
}
