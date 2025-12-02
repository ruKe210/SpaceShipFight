using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using Unity.VisualScripting;
using UnityEngine;

public class RankPanel : BasePanel<RankPanel>
{


    public UIButton btnquit;

    public UIScrollView scrollView;
    GameObject rankItem;

    private void Start()
    {

        //DataManager.Instacne.AddRankRecord("123", 123);
        this.HideMe();
        btnquit.onClick.Add(new EventDelegate(() =>
        {
            this.gameObject.SetActive(false);
        }));

        for(int i=0;i<DataManager.Instacne.rankList.rankList.Count;i++)
        {
            rankItem = Instantiate(Resources.Load<GameObject>("RankItem"));
            
            rankItem.transform.position = new Vector3(0, 57346.2f - 142*i, 0);
            rankItem.transform.SetParent(scrollView.transform,false);
    

            for(int j=0;j<3;j++)
            {
               
                if (rankItem.transform.GetChild(j).name=="Name")
                {
                    rankItem.transform.GetChild(j).GetComponent<UILabel>().text = DataManager.Instacne.rankList.rankList[i].name;
                }
                else if(rankItem.transform.GetChild(j).name == "Time")
                {
                    int time = DataManager.Instacne.rankList.rankList[i].time;
                    //int hour = time / 3600;
                    int minute = time / 60;
                    int second = time % 60;

                    string _time = minute.ToString().Length == 1 ? "0" + minute.ToString() : minute.ToString();
                    _time += ":";
                    _time += second.ToString().Length == 1 ? "0" + second.ToString() : second.ToString();

                    rankItem.transform.GetChild(j).GetComponent<UILabel>().text = _time;
                }
                else
                {
                    rankItem.transform.GetChild(j).GetComponent<UILabel>().text = (i+1).ToString();
                }
            }

        }
        
        
        
    }
}
