using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, out hit))
            {
                if (hit.collider.tag == "Cube")
                {
                    ICommand click = new ClickCommand(hit.collider.gameObject, new Color(
                        Random.value,
                        Random.value,
                        Random.value));
                    click.Execute();
                    CommandManager.Instance.AddCommand(click);
                }
            }
        }
    }
}
