using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDuck : MonoBehaviour
{
    public GameObject prePot;
    public GameObject preDuck;

    public Button btnCross;

    public GameObject potGameObjects;
    public GameObject duckGameObjects;

    [Header("Positions")]
    public List<GameObject> allPotPosition;
    public List<GameObject> allDuckStartPostion;
    public List<GameObject> allDuckEndPostion;

    public List<GameObject> allPotObject;
    public List<Pot> allPot;

    public List<GameObject> allDuckObject;
    public List<Duck> allDuck;

    List<int> selectedColorList = new List<int>();
    int selectedDuckIndex = -1;
    int selectedPotIndex = -1;
    bool isTouchEnable = true;

    public static GameDuck sharedInstance = null;
    public static GameDuck SharedManager()
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
        btnCross.onClick.AddListener(() => CrossCallBack());
        SetColor();
        LoadPot();
        LoadDuck();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                TouchBegan(Input.GetTouch(0));
            }

            if(Input.GetMouseButton(0))
            {
                TouchMoved(Input.GetTouch(0));
            }

            if (Input.GetMouseButtonUp(0))
            {
                TouchEnd(Input.GetTouch(0));
            }
        }
    }

    void CrossCallBack()
    {
        Destroy(this.gameObject);
    }

    #region Color

    void SetColor()
    {
        selectedColorList.Clear();
        while(true)
        {
            int colorNo = 1 + Random.Range(0, 7);
            bool isNewColor = true;

            for (int j = 0; j < selectedColorList.Count; j++)
            {
                if(colorNo== selectedColorList[j])
                {
                    isNewColor = false;
   
                    break;
                }
            }

            if(isNewColor)
            {
                selectedColorList.Add(colorNo);
                if (selectedColorList.Count == 3)
                    break;
            }
        }
    }

    #endregion
    
    #region Pot
    void LoadPot()
    {
        List<int> tempColorList = new List<int>(selectedColorList);

        for (int i = 0; i < allPotPosition.Count; i++)
        {
            int selecteIndex = Random.Range(0, tempColorList.Count);
           
            GameObject goPot = Instantiate(prePot, potGameObjects.transform);
            goPot.transform.position = allPotPosition[i].transform.position;

            Pot pot = goPot.GetComponent<Pot>();
            pot.AssignValue(i,tempColorList[selecteIndex]);

            allPotObject.Add(goPot);
            allPot.Add(pot);

            tempColorList.RemoveAt(selecteIndex);
        }
    }

    #endregion

    #region Duck

    void LoadDuck()
    {
        List<int> tempColorList = new List<int>(selectedColorList);
        for (int i = 0; i < allDuckEndPostion.Count; i++)
        {
            int selecteIndex = Random.Range(0, tempColorList.Count);
            
            GameObject goDuck = Instantiate(preDuck, duckGameObjects.transform);
            goDuck.transform.position = allDuckStartPostion[i].transform.position;

            Duck duck = goDuck.GetComponent<Duck>();
            duck.AssignValue(i,tempColorList[selecteIndex]);

            //allDuck[i].sprite = Resources.Load<Sprite>(Constants.folderResourcesDuck + "duck-" + duckColorList[i]);

            tempColorList.RemoveAt(selecteIndex);

            allDuckObject.Add(goDuck);
            allDuck.Add(duck);
        }

        StartDuckAnimation();
    }

    void StartDuckAnimation()
    {
        for (int i = 0; i < allDuckObject.Count; i++)
        {
            allDuckObject[i].transform.DOMove(allDuckEndPostion[i].transform.position, 0.8f);
        }
    }

    #endregion

    #region Touch

    void TouchBegan(Touch touch)
    {
        for (int i = 0; i < allDuckObject.Count; i++)
        {
            Duck duck = allDuck[i];
            if(duck.IsTouched(touch))
            {
                selectedDuckIndex = i;
                break;
            }
        }
    }

    void TouchMoved(Touch touch)
    {
        if(isTouchEnable)
        {
            if (selectedDuckIndex != -1)
            {
                allDuckObject[selectedDuckIndex].transform.position = touch.position;
            }
        }
    }

    void TouchEnd(Touch touch)
    {
        if(isTouchEnable)
        {
            if (selectedDuckIndex != -1)
            {
                allDuckObject[selectedDuckIndex].transform.position = allDuckEndPostion[selectedDuckIndex].transform.position;
            }
        }
        selectedDuckIndex = -1;
        isTouchEnable = true;
    }
    #endregion

    #region Selected

    public void SetSelectedPotIndex(int _selectedPotIndex)
    {
        selectedPotIndex = _selectedPotIndex;

        Duck duck = allDuck[selectedDuckIndex];
        Pot pot = allPot[selectedPotIndex];

        //Debug.Log("duck.duckType "+ duck.duckType + " pot.potType " + pot.potType);
        if(duck.duckType==pot.potType)
        {
            isTouchEnable = false;
        }
    }

    #endregion

}
