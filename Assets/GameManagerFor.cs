using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerFor : MonoBehaviour
{
    public static GameManagerFor Game;
    public GameObject Player;
    public ChooseZone Grid;
    public float x, y;
    public float xToMove, yToMove;
    public bool HeroSpawn,InChoose;
    public HashSet<ChooseZone> gridMap = new HashSet<ChooseZone>();
    public void Awake()
    {
        Game = this;
    }
  public void chooseHero (Transform hero,int range)
    { int e=0;
        int f = 0;
        print("youChoose");
        for (float i = hero.position.x-range;i<= hero.position.x;i++)
        {
            for (float j = hero.position.y - range; j <= hero.position.y + range; j ++)
            {
                if (j <= hero.position.y + e && j >= hero.position.y - e )
                {
                    var test = Instantiate(Grid, new Vector3(i, j, 0), Quaternion.identity);
                    gridMap.Add(test);
                }
                

            }
            
         
            e++;
        }
        for (float i = hero.position.x + range; i > hero.position.x; i--)
        {
            for (float j = hero.position.y - range; j <= hero.position.y + range; j++)
            {
                if (j <= hero.position.y + f && j >= hero.position.y - f)
                {
                    var test = Instantiate(Grid, new Vector3(i, j, 0), Quaternion.identity);
                    gridMap.Add(test);
                }


            }


            f++;
        }
        InChoose = true;
    }    
    public void GoToHere (float e,float f)
    {
         xToMove=e; yToMove=f;
    }    
    public void UnChoose ()
    {
        foreach (var t in gridMap)
        {

           Destroy(t.gameObject);
        }    
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
