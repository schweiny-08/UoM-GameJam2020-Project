using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    public float waitTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait(waitTime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //loads the scene after the given time
    IEnumerator Wait(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);

        Destroy(gameObject);
    }
}
