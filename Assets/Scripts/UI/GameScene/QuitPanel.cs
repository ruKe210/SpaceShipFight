using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : BasePanel<QuitPanel>
{
    int mode;
    string [] textarr;
    public UIButton yes;
    public UIButton no;
    public UILabel _text;

    // Start is called before the first frame update
    void Start()
    {
        this.HideMe();
        textarr = new string[5];
        textarr[0] = "游戏未结束\n是否退出？";
        textarr[1] = "游戏结束! ";
        yes.onClick.Add(new EventDelegate(() =>{
            SceneManager.LoadScene("BeginScene");
        }));
        no.onClick.Add(new EventDelegate(() => {
            GamePanel.Instance.isTimeUpdate = true;
            this.HideMe();
        }));
    }

    public void ChangeMode(int mode)
    {
        this.mode = mode;
        _text.text = textarr[mode];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
