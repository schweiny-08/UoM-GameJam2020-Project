using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GUI : MonoBehaviour
{

    public Image[] masks;
    public PlayerHealth ph;

    public TMP_Text countdown, levelCounter;

    public int unifectedCounter = 0, uninfectedGoal = 10;
    // Start is called before the first frame update


    void Start()
    {
        ph = GetComponent<PlayerHealth>();

        foreach(Image element in masks){
            element.enabled = false;
        }

        
        for(int i = 0; i < ph.currentHealth; i++){
            masks[i].enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CheckPlayerHealth());

        StartCoroutine(UninfectedCounter());
    }

    IEnumerator CheckPlayerHealth(){

        for(int i = 0; i < ph.maxHealth; i++){
            if(masks[i].enabled)
                masks[i].enabled = false;
        }

        for(int i = 0; i < ph.currentHealth; i++){
            masks[i].enabled = true;
        }

        yield return new WaitForSeconds(0.1f);
    }

    public void SetCounter(int time){
        countdown.text = "Time left to infection: " + (30-time);
    }

    public void ResetCounter(){
        ph.lowhealth = false;
        ph.currentHealth = ph.maxHealth;
        ph.timeTaken = 0;

        countdown.text = "";
    }

    IEnumerator UninfectedCounter(){

        levelCounter.text = "People to disinfect: " + unifectedCounter + "/" + uninfectedGoal;

        yield return new WaitForSeconds(.5f);
    }
}
