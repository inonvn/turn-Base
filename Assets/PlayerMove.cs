using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject HighLight;
    public Transform hero;
    void Start()
    {
        
    }
  
    private void OnMouseExit()
    {
        HighLight.SetActive(false);
    }
    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && GameManagerFor.Game.InChoose==false)
        {
            print("you choose Hero");
            HighLight.SetActive(true);
            GameManagerFor.Game.chooseHero(hero);
        }
        else
        {
            HighLight.SetActive(false);
            GameManagerFor.Game.UnChoose();
        }    
    }


    void Update()
    {
        
    }
}
