using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePanel : BasePanel<GamePanel>
{
    public GameObject UIRoot;
    public UIButton quit;
    public float time;
    public UILabel _time;
    string current_time;
    int second;
    int minute;
    public bool isTimeUpdate;

    public GameObject hp_empty;
    public GameObject hp_full;

    List<GameObject> hp_now;


    int maxhp = 0;
    // Start is called before the first frame update
    void Start()
    {

        hp_now = new List<GameObject>();
        isTimeUpdate = true;
        time = 0;
        quit.onClick.Add(new EventDelegate(() =>
        {
            this.isTimeUpdate = false;
            QuitPanel.Instance.ChangeMode(0);
            QuitPanel.Instance.ShowMe();
        }));

        StartCoroutine(ShowHP());


        //maxhp = Player.Instance.maxhp;
        //int maxhp = 5;


    }

    IEnumerator ShowHP()
    {
        while (!Player.Instance)
        {
            yield return 0;
        }
        maxhp = Player.Instance.maxhp;
        print(maxhp);
        for (int i = 0; i < maxhp; i++)
        {

            hp_now.Add(Instantiate(hp_full));
            //hp_now[i] = ;
            //GameObject hp_full_copy = Instantiate(hp_full);

            hp_now[i].transform.SetParent(UIRoot.transform);
            hp_now[i].transform.localPosition = new Vector3(-900 + i * 40, -467, 0);
            hp_now[i].transform.localScale = Vector3.one;

        }
        yield return 0;
    }


    void TimeUpdate(bool isUpdate)
    {
        if (isUpdate)
        {
            time += Time.deltaTime;
            minute = ((int)time) / 60;
            second = ((int)time) % 60;
            current_time = minute.ToString().Length == 1 ? ("0" + minute.ToString()) : minute.ToString();
            current_time += ":";
            current_time += second.ToString().Length == 1 ? ("0" + second.ToString()) : second.ToString();
            _time.text = current_time;
        }
    }
    public void UpdateHp(int hp)
    {

        Destroy(hp_now[hp]);
        //hp_now.RemoveAt(hp);
        hp_now[hp]=(Instantiate(hp_empty));

        hp_now[hp].transform.SetParent(UIRoot.transform);
        hp_now[hp].transform.localPosition = new Vector3(-900 + hp * 40, -467, 0);
        hp_now[hp].transform.localScale = Vector3.one;

    }
    // Update is called once per frame
    void Update()
    {
        TimeUpdate(isTimeUpdate);
    }
}
