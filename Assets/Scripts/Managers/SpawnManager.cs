using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public static int enemyCount = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-5f, 5f), 2, Random.Range(-5f, 5f)), Quaternion.identity);
        }
    }

    private void OnEnable()
    {
        PlayerMovement.onDeath += ResetPlayer;
    }

    public void ResetPlayer()
    {
        Debug.Log("Player resurected");
    }
}
