using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(Waiter());
    }
    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(1);
        Object.Destroy(this.gameObject);
    }
}
