using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangeMovement : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {


    }

    //loads the scene after the given time
    IEnumerator WaitBeforeFiring(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);

        //SceneManager.LoadScene(SceneToGoTo);

    }

}
