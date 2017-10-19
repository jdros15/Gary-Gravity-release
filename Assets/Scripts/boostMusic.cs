﻿using UnityEngine;
using System.Collections;

public class boostMusic : MonoBehaviour {

    GameObject objSoundSource,objSoundLoop,objSoundIntro;
    private AudioSource asSfx,asMusic,asIntro;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playSfx()
    {
        Invoke("playSfxInvoked", 1.6f);

      
    }

    void playSfxInvoked()
    {
        objSoundLoop = GameObject.Find("Loop");
        objSoundIntro = GameObject.Find("Intro");
        objSoundSource = GameObject.Find("Loop music boost");

        asIntro = objSoundIntro.GetComponent<AudioSource>();
        asIntro.Stop();
        asMusic = objSoundLoop.GetComponent<AudioSource>();
        asMusic.Stop();

        asSfx = objSoundSource.GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("Music") == 1) asSfx.Play();
    }

    public void stopBoostMusic()
    {
     
        asSfx.Stop();
        if (PlayerPrefs.GetInt("Music") == 1) asMusic.Play();
    }
}
