using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverPanel : BasePanel<OverPanel>
{
    public UIButton back;
    public UILabel time;
    public UILabel Name;
    // Start is called before the first frame update
    void Start()
    {
        this.HideMe();
        back.onClick.Add(new EventDelegate(() => {
            RankInfo item = new RankInfo();
            item.name = Name.text;
            item.time = (int)GamePanel.Instance.time;
            DataManager.Instacne.rankList.rankList.Add(item);
            DataManager.Instacne.SaveRankList();
            SceneManager.LoadScene("BeginScene");
        }));
    }
    public void changepos()
    {
        GamePanel.Instance.isTimeUpdate = false;
        time.transform.localPosition = new Vector3(0, 80, 0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
