using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fireobj : MonoBehaviour
{

    FireInfo fireInfo;
    BulletInfo bulletInfo;
    int nownum =10;
    float nowcd =10;
    float nowdelay=10;
    float changeangle;
    GameObject bullet;
    public enum pos
    {
        topleft,
        topright,
        bottomleft,
        bottomright
    }

    public pos type;
    Vector3 screenpos;
    Vector3 initdir;
    Vector3 nowdir;
    float posx;
    float posz;
    // Start is called before the first frame update
    void Start()
    {
        screenpos.z = 100;
    }
    void updatepos()
    {
        switch(type)
        {
            case pos.topleft:
                screenpos.x = 0;
                screenpos.y = Screen.height;
                initdir = Vector3.right;
                break;
            case pos.topright:
                screenpos.x = Screen.width;
                screenpos.y = Screen.height;
                initdir = Vector3.back;
                break;
            case pos.bottomleft:
                screenpos.x = 0;
                screenpos.y = 0;
                initdir = Vector3.forward;
                break;
            case pos.bottomright:
                screenpos.x = Screen.width;
                screenpos.y = 0;
                initdir = Vector3.left;
                break;
        }
        this.transform.position = Camera.main.ScreenToWorldPoint(screenpos);
    }
    // Update is called once per frame

    void ResetFireInfo()
    {

        if(fireInfo!=null)
        {
            nowdelay -= Time.deltaTime;
            if (nowdelay > 0)
                return;
        }
        fireInfo = DataManager.Instacne.fireData.fireInfoList[Random.Range(0, DataManager.Instacne.fireData.fireInfoList.Count)];
        nownum = fireInfo.num;
        nowcd = fireInfo.cd;
        nowdelay = fireInfo.delay;


        string[] str = fireInfo.ids.Split(',');
        int beginid = int.Parse(str[0]);
        int endid = int.Parse(str[1]);
        int randid = Random.Range(beginid, endid );

        bulletInfo = DataManager.Instacne.bulletData.bulletInfoList[randid];

        if(fireInfo.type==2)
        {
            changeangle = 90f/(nownum+1);
        }
    }
    void UpdateFire()
    {
 
        nowcd -= Time.deltaTime;
        if (nowcd > 0)
            return;
        switch(fireInfo.type)
        {
            case 1:
                //print(bulletInfo.resName);
                bullet = Instantiate(Resources.Load(bulletInfo.resName) as GameObject);
                bullet.transform.position = this.transform.position;
                bullet.transform.rotation = Quaternion.LookRotation(Player.Instance.transform.position-this.transform.position);
                bullet.AddComponent<BulletObj>();
                nownum--;
                nowcd = nownum == 0 ? 0 : fireInfo.cd;
                break;
            case 2:
                if(nowcd==0)
                {
                    for (global::System.Int32 i = 0; i <nownum ; i++)
                    {
                        bullet = Instantiate(Resources.Load(bulletInfo.resName) as GameObject);
                        bullet.transform.position = this.transform.position;
                        nowdir = Quaternion.AngleAxis(changeangle * i, Vector3.up)*initdir;
                        bullet.transform.rotation = Quaternion.LookRotation(nowdir);
                        bullet.AddComponent<BulletObj>();

                    }
                    nowcd = nownum = 0;
                }
                else
                {
                    bullet = Instantiate(Resources.Load(bulletInfo.resName) as GameObject);
                    bullet.transform.position = this.transform.position;
                    nowdir = Quaternion.AngleAxis(changeangle * (fireInfo.num-nownum), Vector3.up) * initdir;
                    bullet.transform.rotation = Quaternion.LookRotation(nowdir);
                    bullet.AddComponent<BulletObj>();
                    nownum--;
                    nowcd = nownum == 0 ? 0 : fireInfo.cd;
                }
                break;

        }
    }
    void Update()
    {
        if(GamePanel.Instance.isTimeUpdate)
        {
            updatepos();
            ResetFireInfo();
            UpdateFire();
        }

        //screenpos = Camera.main.WorldToScreenPoint(Player.Instance.transform.position);
        //print(screenpos);
    }
}
