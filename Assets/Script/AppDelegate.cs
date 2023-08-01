using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppDelegate : MonoBehaviour
{
    public static AppDelegate sharedInstance = null;
    public static AppDelegate SharedManager()
    {
        return sharedInstance;
    }

    private void Awake()
    {
        sharedInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
