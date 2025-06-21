using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;

using static TriggerCombat;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance;
   public enemyAttack enemy;
    public Transform enemyspawn1;
    public battelState state;
    public TextMeshProUGUI text;
    public GameObject choose;
    public GameObject chooseAttack;
   
    public enemyAttack e;
    public stat EStat;


    public void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        choose.SetActive(false);
        state = battelState.start;
     StartCoroutine(   setupbattle());
    }

    IEnumerator setupbattle()
    {
    e =  Instantiate(enemy,enemyspawn1);
        text.text = "You found monster";
        yield return new WaitForSeconds(2);
        text.text = "what should you do ?";
        yield return new WaitForSeconds(2);
        text.text = "";
        myturn();
        
    }
    void myturn ()
    {
        state = battelState.Myturn;
        choose.SetActive(true);

       

    }    
  public  void attackButton ()
    {
        if (state== battelState.Myturn)
        {
            choose.SetActive (false);
            chooseAttack.SetActive (true);
        }    
        else { return; }
    }  
  public  IEnumerator Attack1 ()
    {

        infoplayer.eStat.statadd();
        enemy.HP -= infoplayer.eStat.statMap[stat.dame];
        chooseAttack.SetActive (false);
        text.text = $"you deal :{infoplayer.eStat.statMap[stat.dame]}   dame to enemy";
        yield return new WaitForSeconds(1);
    }
    public void normalAttack ()
    {
      StartCoroutine(  Attack1());
    }    
 public   void HeavyAttack()
    {
        
    }
    public void back()
    {
        choose.SetActive (true);
        chooseAttack.SetActive (false);
    }    

    // Update is called once per frame
    void Update()
    {
        
    }
}
