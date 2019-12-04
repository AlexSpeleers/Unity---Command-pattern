using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
                instance = new UIManager();
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
    }
    public Text enemyCount;

    public void UpdateCount()
    {
        enemyCount.text = $"Enemy count: {SpawnManager.enemyCount.ToString()}";
    }

}
