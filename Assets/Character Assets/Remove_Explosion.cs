using System.Collections;
using UnityEngine;

public class Remove_Explosion : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(Waiter());
    }
    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(0.3f);
        Object.Destroy(this.gameObject);
    }
}
