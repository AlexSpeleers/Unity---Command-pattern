using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    private bool onCoolDown = false;
    void OnEnable()
    {
        var col = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        gameObject.GetComponent<MeshRenderer>().material.color = col;
    }

    public void DoAction()
    {
        if (onCoolDown == false)
        {
            onCoolDown = true;
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse);
            StartCoroutine(HideRoutine());
        }
    }
    // Update is called once per frame
    IEnumerator HideRoutine()
    {
        yield return new WaitForSeconds(3f);
        this.gameObject.SetActive(false);
        //transform.rotation = PoolManager.Instance.bulletContainer.;
        transform.parent = PoolManager.Instance.bulletContainer.transform;
        onCoolDown = false;
    }
}
