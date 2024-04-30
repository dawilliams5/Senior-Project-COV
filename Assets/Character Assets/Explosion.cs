using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour { 
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
