using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHud : MonoBehaviour
{
    [Header("Canvas")]
    public Canvas canvas;
    public Canvas canvasGameDuck;

    [Header("Prefabs")]
    public GameObject preStartPanel;

    [Header("GameDuck")]
    public GameObject preGameDuck;

    public static GameHud sharedInstance = null;
    public static GameHud SharedManager()
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
        LoadStorePanel(Panel.StartPanel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadStorePanel(Panel panelId)
    {
        switch (panelId)
        {
            case Panel.StartPanel:
                {
                    Instantiate(preStartPanel, canvas.transform);
                }
                break;

            case Panel.GameDuck:
                {
                    Instantiate(preGameDuck, canvasGameDuck.transform);
                }
                break;
            default:
                break;
        }
    }
}
