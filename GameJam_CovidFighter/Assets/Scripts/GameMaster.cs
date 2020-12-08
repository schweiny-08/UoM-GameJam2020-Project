using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    private GUI gui;

    //public int upgradeSceneIndex;

    private int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(gui == null)
            gui = GetComponent<GUI>();
        
        if(gui.unifectedCounter >= gui.uninfectedGoal && SceneManager.GetActiveScene().name != "BossScene"){
            ToUpgradeScene();
        }
    }   

    public void ToUpgradeScene(){
        currentSceneIndex++;
        SceneManager.LoadScene("UpgradeSystem");
    }

    public void ToNextLevel(){
        SceneManager.LoadScene(currentSceneIndex);
    }
}
