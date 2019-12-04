using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    #region Action parametrised
    //public Action<int, int> Sum;

    //private void Start()
    //{
    //    Sum = (a, b) =>
    //    {
    //        var total = a + b;
    //        if (total < 100)
    //        {
    //            Debug.Log($"{total} is lower than 100");
    //        }
    //        else
    //            Debug.Log($"{total} is higher than 100");
    //    };

    //    Sum(5, 7);
    //}
    #endregion

    #region Action no parameters
    //public Action onGetName;
    //private void Start()
    //{
    //    onGetName = () => Debug.Log($"Name:{gameObject.name}");
    //    onGetName();
    //}
    #endregion

    #region Func with no params
    //public Func<int> onGetName;

    //private void Start()
    //{
    //    onGetName = () => this.gameObject.name.Length;
    //    var charCount = onGetName();
    //    Debug.Log($"Character count = {charCount}.");
    //}
    #endregion

    #region Func parametrised
    public Func<int, int, int> onCalculateSum;
    private void Start()
    {
        onCalculateSum = (a, b) => a + b;
        var sum = onCalculateSum(8, 8);
        Debug.Log($"Sum = {sum}");

        StartCoroutine(MyRoutine(() => 
            Debug.Log("The routine hase finished")
        ));
    }

    public IEnumerator MyRoutine(Action onComplete = null)
    {
        yield return new WaitForSeconds(5.0f);
        if (onComplete != null)
            onComplete();
    }

    #endregion

}
