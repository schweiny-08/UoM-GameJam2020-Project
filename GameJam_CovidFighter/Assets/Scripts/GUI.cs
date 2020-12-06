using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{

    public Image[] masks;
    public PlayerHealth ph;

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
}
