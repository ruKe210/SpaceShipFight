using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bkMusic : MonoBehaviour
{

   
   private static bkMusic instance;
    public static bkMusic Instance=>instance;
    public AudioSource bkmusic;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

        bkmusic = this.gameObject.GetComponent<AudioSource>();
        bkmusic.loop = true;
        bkmusic.Play();
        bkmusic.mute = !DataManager.Instacne.musicData.isMusic;
   

        bkmusic.volume = DataManager.Instacne.musicData.MusicVolume;
    }

    void Update()
    {
        
    }
}
