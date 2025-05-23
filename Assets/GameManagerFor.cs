using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerFor : MonoBehaviour
{
    public static GameManagerFor Game;
    public GameObject Player;
    public GameObject Grid;
    public float x, y;
    public bool HeroSpawn,InChoose;
    public HashSet<GameObject> gridMap = new HashSet<GameObject>();
    public void Awake()
    {
        Game = this;
    }
  public void chooseHero (Transform hero)
    {
        print("youChoose");
        for (float i = hero.position.x-2;i<= hero.position.x+2;i++)
        {
            for (float j = hero.position.y - 2; j <= hero.position.y + 2; j ++)
            {
               var test = Instantiate(Grid, new Vector3(i, j, 0), Quaternion.identity);
                gridMap.Add(test);
                

            }    
        }
        InChoose = true;
    }    
    public void UnChoose ()
    {
        gridMap.Clear();
        InChoose=false;
    }    
   public void RandomSpawnHero (float H,float V)
    {
        int heroCount = 1;
        for (int i = 0; i < heroCount; i++) {
            Instantiate(Player,new Vector3(H,V,0), Quaternion.identity);
            HeroSpawn= true;
                 }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
