﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CanvasSetter : MonoBehaviour
{
    public Image[] masks;

    public TMP_Text countdown, levelCounter;

    public int unifectedGoal;

    public AudioClip bossSong;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("GameMaster").GetComponent<GUI>().masks = null;
        GameObject.Find("GameMaster").GetComponent<GUI>().masks = masks;
        GameObject.Find("GameMaster").GetComponent<GUI>().countdown = countdown;
        GameObject.Find("GameMaster").GetComponent<GUI>().levelCounter = levelCounter;   
        GameObject.Find("GameMaster").GetComponent<GUI>().uninfectedGoal = unifectedGoal;     
        GameObject.Find("GameMaster").GetComponent<GUI>().unifectedCounter = 0;
        GameObject.Find("GameMaster").GetComponent<PlayerHealth>().currentHealth = GameObject.Find("GameMaster").GetComponent<PlayerHealth>().maxHealth;
        GameObject.Find("GameMaster").GetComponent<PlayerHealth>().lowhealth = false;

        if(SceneManager.GetActiveScene().name == "BossScene")
            GameObject.Find("GameMaster").GetComponent<AudioSource>().clip = bossSong;
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
