using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public GameObject[] Ships;
    private static Player instance;
    public static Player Instance =>instance;
    
    public float RotateRatio = 0.01f;
    public float Speed = 10;
    public float RoateAngle = 20;



    int hp;

    public int maxhp = 5;



    void Start()
    {
        maxhp = 5;
        this.hp = maxhp;


        //print(Application.persistentDataPath);
        instance = this;
        for(int i=0;i<Ships.Length;i++)
        {
            if (i == SelectPanel.Instance.ShipNo)
                Ships[i].SetActive(true);
            else
                Ships[i].SetActive(false);
        }
    }

    void move()
    {
        Quaternion targetRotation = Quaternion.Euler(0, 0, 0);
        Quaternion ForwardRotation = Quaternion.Euler(RoateAngle, 0, 0);
        Quaternion BackwardRotation = Quaternion.Euler(-RoateAngle, 0, 0);
        Quaternion LeftwardRotation = Quaternion.Euler(0, 0, RoateAngle);
        Quaternion RightwardRotation = Quaternion.Euler(0, 0, -RoateAngle);
        if(Input.anyKey)
        {
            

            if (Input.GetKey(KeyCode.W) && this.transform.position.z < 70)
            {
                this.transform.rotation = Quaternion.Lerp(this.transform.rotation, ForwardRotation, RotateRatio);
                this.gameObject.transform.Translate(Vector3.forward*Time.deltaTime*Speed,Space.World); 
            }
            if (Input.GetKey(KeyCode.S)&& this.transform.position.z > -70)
            {
                this.transform.rotation = Quaternion.Lerp(this.transform.rotation, BackwardRotation, RotateRatio);
                this.gameObject.transform.Translate(Vector3.back * Time.deltaTime * Speed, Space.World);

            }
            if (Input.GetKey(KeyCode.A)&& this.transform.position.x >- 150)
            {
                this.transform.rotation = Quaternion.Lerp(this.transform.rotation, LeftwardRotation, RotateRatio);
                this.gameObject.transform.Translate(Vector3.left * Time.deltaTime * Speed,Space.World);

            }
            if (Input.GetKey(KeyCode.D) && this.transform.position.x <150)
            {
                this.transform.rotation = Quaternion.Lerp(this.transform.rotation, RightwardRotation, RotateRatio);
                this.gameObject.transform.Translate(Vector3.right * Time.deltaTime * Speed, Space.World);

            }
            
        }
        else
        {
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, RotateRatio);
        }

        
    }
    void removeBUllet()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            //print(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            //print(Camera.main.ScreenPointToRay(Input.mousePosition));
            Debug.DrawRay(Camera.main.ScreenToWorldPoint(Input.mousePosition), new Vector3(0,-1,0), Color.red);
            if( Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, 1000, 1<<LayerMask.NameToLayer("Bullet")))
            {
                print(hitInfo.transform.name);
                hitInfo.transform.gameObject.GetComponent<BulletObj>().dead();
            }
                
        }
    }

    public void gethit()
    {
        this.hp--;
        GamePanel.Instance.UpdateHp(this.hp);
    }

    // Update is called once per frame
    void Update()
    {
        removeBUllet();
        move();
        if(hp<=0)
        {
            OverPanel.Instance.changepos();
            OverPanel.Instance.ShowMe();
            this.gameObject.SetActive(false);
        }
    }
}
