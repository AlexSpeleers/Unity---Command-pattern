using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private string uiManager = "UIManager";
    private UIManager ui;
    public void OnEnable()
    {
        ui = GameObject.Find(uiManager).GetComponent<UIManager>();
        SpawnManager.enemyCount++;
        ui.UpdateCount();
        Die();
    }

    public void OnDisable()
    {
        SpawnManager.enemyCount--;
        ui.UpdateCount();
    }

    void Die()
    {
        Destroy(this.gameObject, Random.Range(2f, 5f));
    }
}
