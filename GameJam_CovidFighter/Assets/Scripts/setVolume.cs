using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class setVolume : MonoBehaviour
{
    public AudioSource audioSourceToEffect;
    public float po = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSourceToEffect = GameObject.Find("GameMaster").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setVolAccSlider()
    {
        audioSourceToEffect = GameObject.Find("GameMaster").GetComponent<AudioSource>();
        audioSourceToEffect.volume = this.GetComponentInChildren<Slider>().value;
        //po = this.GetComponentInChildren<Slider>().value;

    }
}
