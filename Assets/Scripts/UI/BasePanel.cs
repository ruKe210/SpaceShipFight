using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel<T> : MonoBehaviour where T : class
{
    // Start is called before the first frame update

    private static T instacne;

    public static T Instance =>instacne;


    private void Awake()
    {
        instacne = this as T;
    }
    void Start()
    {
        
    }
    public void ShowMe()
    {
        this.gameObject.SetActive(true);
    
    }
    public void HideMe()
    {
        this.gameObject.SetActive(false);

    }
}
