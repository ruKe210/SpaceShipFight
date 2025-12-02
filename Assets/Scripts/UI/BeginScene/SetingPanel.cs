using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SetingPanel : BasePanel<SetingPanel>
{
    // Start is called before the first frame update
    public UIButton btnquit;

    public UISlider musicSlider;
    public UISlider soundSlider;
    public UIToggle musicToggle;
    public UIToggle soundToggle;
    //public UIButton btnquit;

    

    void Start()
    {
        musicSlider.value = DataManager.Instacne.musicData.MusicVolume;
        soundSlider.value = DataManager.Instacne.musicData.SoundVolume;
        musicToggle.value = DataManager.Instacne.musicData.isMusic;
        soundToggle.value = DataManager.Instacne.musicData.isSound;



        this.HideMe();


        btnquit.onClick.Add(new EventDelegate(() => {
            DataManager.Instacne.SaveMusicData();
            this.HideMe();
        }));
        musicSlider.onChange.Add(new EventDelegate(() => {
            
            DataManager.Instacne.SetMusicVolume(musicSlider.value);
        }));
        soundSlider.onChange.Add(new EventDelegate(() => {
            DataManager.Instacne.SetSoundVolume(soundSlider.value);
        }));
        musicToggle.onChange.Add(new EventDelegate(() => {
           
            DataManager.Instacne.SetIsMusic(musicToggle.value);
        }));
        soundToggle.onChange.Add(new EventDelegate(() => {
            DataManager.Instacne.SetIsSound(soundToggle.value);

        }));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
