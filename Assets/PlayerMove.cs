using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject HighLight;
    public Transform hero;
    public Rigidbody2D player;
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
            GameManagerFor.Game.chooseHero(hero,2);
        }
        else
        {
            HighLight.SetActive(false);
            GameManagerFor.Game.UnChoose();
        }    
    }
    public void MovePlayer()
    {
        
        transform.position = new Vector3(GameManagerFor.Game.xToMove,GameManagerFor.Game.yToMove,0);
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    void Update()
    {
        
    }
}
