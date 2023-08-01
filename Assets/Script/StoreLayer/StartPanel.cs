using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    public Button btnDuck;

    // Start is called before the first frame update
    void Start()
    {
        btnDuck.onClick.AddListener(() => DuckCallBack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DuckCallBack()
    {
        GameHud.SharedManager().LoadStorePanel(Panel.GameDuck);
    }
}
