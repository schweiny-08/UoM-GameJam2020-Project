using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{

    public string ExitSceneToGoTo;
    public float waitTime = 0.4f;

    public GameObject optionsMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //pauses
        if (Input.GetKeyDown("escape"))
        {
            optionsMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    //unpauses
    public void unpause()
    {
        optionsMenu.SetActive(false);
        Time.timeScale = 1;
    }

    //Takes User To A Specific Scene
    public void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    //Takes User To A Specific Scene
    public void exitToScene()
    {
        SceneManager.LoadScene(ExitSceneToGoTo);
        Destroy(GameObject.Find("GameMaster"));
    }

}
