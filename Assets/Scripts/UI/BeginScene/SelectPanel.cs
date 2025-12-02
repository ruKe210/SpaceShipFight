using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPanel : BasePanel<SelectPanel>
{

    public GameObject[] Ships;
    public UIButton Left;
    public UIButton Right;
    public UIButton start;
    public int ShipNo=0;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<Ships.Length;i++)
        {
            Ships[i].SetActive(false);
        }
        Ships[ShipNo].SetActive(true);
;       this.HideMe();
        Left.onClick.Add(new EventDelegate(() => {
            Ships[ShipNo].SetActive(false);
            ShipNo--;
            if (ShipNo < 0)
                ShipNo += Ships.Length;
            Ships[ShipNo].SetActive(true);

        }));
        Right.onClick.Add(new EventDelegate(() => {
            Ships[ShipNo].SetActive(false);
            ShipNo++;
            if (ShipNo >= Ships.Length)
                ShipNo = 0;
            //print(ShipNo);
            Ships[ShipNo].SetActive(true);
            
        }));
        start.onClick.Add(new EventDelegate(() => {
            SceneManager.LoadScene("GameScene");
            this.HideMe();

        }));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
