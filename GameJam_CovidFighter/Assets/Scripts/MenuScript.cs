using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{

    public string SceneToGoTo;
    public float waitTime = 0;

    public GameObject optionsMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Takes User To A Specific Scene
    public void goToScene()
    {
        StartCoroutine(LoadSceneAfter(waitTime));
    }

    //loads the scene after the given time
    IEnumerator LoadSceneAfter(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(SceneToGoTo);

    }

    //Opens the optionsmenu gameObject
    public void enableOptions()
    {

        optionsMenu.SetActive(true);

    }

    //Closes the optionsmenu gameObject
    public void disableOptions()
    {
        StartCoroutine(disableOptionsAfter(waitTime));
    }

    //loads the scene after the given time
    IEnumerator disableOptionsAfter(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);

        optionsMenu.SetActive(false);

    }

    //Closes the application
    public void closeApp()
    {

        Application.Quit();
        Debug.Log("Closing Game");

    }
}
