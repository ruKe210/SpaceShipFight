using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeginPanel : BasePanel<BeginPanel>
{
    // Start is called before the first frame update
    public UIButton btnstart;
    public UIButton btnquit;
    public UIButton btnseting;
    public UIButton btnrank;
    //public UIButton btn;
    

    void Start()
    {
        btnquit.onClick.Add(new EventDelegate(() => {
            Application.Quit(); 
        }));
        btnstart.onClick.Add(new EventDelegate(() =>
        {
            SelectPanel.Instance.ShowMe();
            this.HideMe();

        }));
        btnseting.onClick.Add(new EventDelegate(() => {
            SetingPanel.Instance.ShowMe();

        }));
        btnrank.onClick.Add(new EventDelegate(() => {
            RankPanel.Instance.ShowMe();

        }));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
