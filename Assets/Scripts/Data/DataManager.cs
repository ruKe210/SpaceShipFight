using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using Unity.VisualScripting;
using UnityEngine;

public class DataManager
{
    private static DataManager instacne = new DataManager();
    public static DataManager Instacne =>instacne;

    public MusicData musicData;

    public RankList rankList;

    public BulletData bulletData;

    public FireData fireData;
    DataManager()
    {
        rankList = XmlDataMgr.Instance.LoadData(typeof(RankList), "RankList") as RankList;
        musicData = XmlDataMgr.Instance.LoadData(typeof(MusicData), "MusicData") as MusicData;
        bulletData = XmlDataMgr.Instance.LoadData(typeof(BulletData), "BulletData") as BulletData;
        fireData = XmlDataMgr.Instance.LoadData(typeof(FireData), "FireData") as FireData;
    }

    public void AddRankRecord(string name,int time)
    {
        RankInfo rankInfo = new RankInfo();
        rankInfo.name = name;
        rankInfo.time = time;
        rankList.rankList.Add(rankInfo);
        rankList.rankList.Sort((a, b) =>
        {
            return a.time < b.time ? 1 : -1;
        });

        while(rankList.rankList.Count > 20)
        {
            rankList.rankList.Remove(rankList.rankList[rankList.rankList.Count-1]);
        }
        SaveRankList();
    }
    public void SaveRankList()
    {
        rankList.rankList.Sort((a, b) =>
        {
            if (a.time > b.time)
                return -1;
            else
                return 1;
        });

        XmlDataMgr.Instance.SaveData(rankList, "RankList");
    }
    public void SaveMusicData()
    {
        XmlDataMgr.Instance.SaveData(musicData, "MusicData");
    }
    public void SetMusicVolume(float volume)
    {
        bkMusic.Instance.bkmusic.volume = volume;
        this.musicData.MusicVolume = volume;

    }
    public void SetSoundVolume(float volume)
    {
        this.musicData.SoundVolume = volume;
    }
    public void SetIsMusic(bool isMusic)
    {
        bkMusic.Instance.bkmusic.mute = !isMusic;

        this.musicData.isMusic = isMusic;
    }    
    public void SetIsSound(bool isSound)
    {
        this.musicData.isSound = isSound;
    }
}
