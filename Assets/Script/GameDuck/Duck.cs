using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Duck : MonoBehaviour
{
    public Image imgDuck;
    int objectAtIndex;
    public int duckType;

    public BoxCollider2D duckCollider;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AssignValue(int _objectAtIndex, int _duckType)
    {
        objectAtIndex = _objectAtIndex;
        duckType = _duckType;

        this.name = "duck-" + objectAtIndex;

        imgDuck.sprite = Resources.Load<Sprite>(Constants.folderResourcesDuck + "duck-" + duckType.ToString());
    }

    public bool IsTouched(Touch touch)
    {
        if (duckCollider == Physics2D.OverlapPoint(touch.position))
        {
            return true;
        }
        return false;
    }

    
}
