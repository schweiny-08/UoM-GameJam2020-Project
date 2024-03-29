﻿using System.Collections;
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
        
        if(gui.unifectedCounter >= gui.uninfectedGoal && SceneManager.GetActiveScene().name != "BossScene" && SceneManager.GetActiveScene().name != "UpgradeSystem" &&SceneManager.GetActiveScene().name != "WinScreen"){
            ToUpgradeScene();
        }
    }   

    public void ToUpgradeScene(){
        
        SceneManager.LoadScene("UpgradeSystem");
    }

    public void ToNextLevel(){
        currentSceneIndex++;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
