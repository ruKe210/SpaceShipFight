using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObj : MonoBehaviour
{
    public BulletInfo info;
    float time = 0;

    public void dead()
    {
        GameObject deadeff = Resources.Load(info.deadEffRes) as GameObject;
        deadeff = Instantiate(deadeff, this.transform.position, this.transform.rotation);
        
        Destroy(deadeff, 2);
        Destroy(this.gameObject);

    }
 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            other.gameObject.GetComponent<Player>().gethit();
        }
        dead();
    }
    void move()
    {

    }
    private void Start()
    {
        info = DataManager.Instacne.bulletData.bulletInfoList[Random.Range(0, DataManager.Instacne.bulletData.bulletInfoList.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        if(GamePanel.Instance.isTimeUpdate)
        {
            time += Time.deltaTime;
            if (time >= info.lifeTime)
                dead();
            this.transform.Translate(Vector3.forward * info.forwardSpeed * Time.deltaTime);
            switch (info.type)
            {
                case 2:
                    this.transform.Translate(Vector3.right * info.rightSpeed * Time.deltaTime * Mathf.Sin(this.time));
                    break;
                case 3:
                    this.transform.rotation *= Quaternion.AngleAxis(info.roundSpeed * Time.deltaTime, Vector3.up);
                    break;
                case 4:
                    this.transform.rotation *= Quaternion.AngleAxis(-info.roundSpeed * Time.deltaTime, Vector3.up);

                    break;
                case 5:
                    this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(Player.Instance.gameObject.transform.position - this.transform.position), info.roundSpeed * Time.deltaTime);
                    break;
            }
        }
        
    }
}
