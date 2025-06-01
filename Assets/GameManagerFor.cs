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
    
    public Vector2Int GridPosCheck;
    public Dictionary<Vector2Int,TypeSquare> mapCheck = new Dictionary<Vector2Int,TypeSquare>();
    public MapPath PathFind;

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
   public void RandomSpawnHero (float H,float V,bool wall)
    {
        int heroCount = 1;
       
        
            if (heroCount == 1 && (Random.Range(0, 8) == 0) && wall==false && HeroSpawn == false)
            {
                
            print(H);
            print(V);
            xToMove = H; yToMove=V;
                Instantiate(Player, new Vector3(xToMove, yToMove, 0), Quaternion.identity);

                heroCount--;
                HeroSpawn = true;
            }
                 }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
