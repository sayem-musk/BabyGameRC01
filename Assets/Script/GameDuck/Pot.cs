using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Pot : MonoBehaviour
{
    public Image imgPot;
    public BoxCollider2D potCollider;
    int objectAtIndex;
    public int potType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AssignValue(int _objectAtIndex,int _potType)
    {
        objectAtIndex = _objectAtIndex;
        potType = _potType;

        this.name = "pot-" + objectAtIndex;

        imgPot.sprite = Resources.Load<Sprite>(Constants.folderResourcesPot + "pot-" + potType.ToString());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.Contains("duck"))
        {
            //int duckIndex = int.Parse(collision.name.Split('-')[1]);
            GameDuck.SharedManager().SetSelectedPotIndex(objectAtIndex) ;
        }
    }

    public bool IsCollided(BoxCollider2D boxCollider)
    {
        if (potCollider.IsTouching(boxCollider))
        {
            return true;
        }
        return false;
    }
}
