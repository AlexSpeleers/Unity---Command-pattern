using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    //public string name;
    private int currentScene;
    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            if (SceneManager.GetActiveScene().buildIndex != 1)
                SceneManager.LoadScene(currentScene + 1);
            else
                SceneManager.LoadScene(0);
        }
    }
    public override void Init()
    {
        base.Init();
        Debug.Log("Player created.");
    }
}
