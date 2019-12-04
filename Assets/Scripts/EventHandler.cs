using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public delegate void Teleport(Vector3 pos);
    public static event Teleport onTeleport;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (onTeleport != null)
                onTeleport(new Vector3(Random.Range(-8.5f, 8.5f), 0.5f, Random.Range(-5.5f, 12f)));
        }
    }
}
