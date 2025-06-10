using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    
    public GameObject Square,rock;
    public Transform cam;
    [SerializeField] TypeSquare grassType, rockType;
    int i,j;
 
   
    void Start()
    {
        mapRender();

    }

  
   public void mapRender()
    { 
       
        for ( i = 0; i <GameManagerFor.Game. x; i++)
        {
            for ( j = 0; j <GameManagerFor.Game. y; j++)
            {

                var RandomMap = (Random.Range(1, 8) == 7 ? rockType : grassType);
              var SpawnSquare =  Instantiate(RandomMap, new Vector3(i, j), Quaternion.identity);
               SpawnSquare.name = $"{i},{j}";
               SpawnSquare.e(i, j);
                SpawnSquare.locationV2 = new Vector2Int(i, j);
                var GridPos = new Vector2Int (i, j);
                GameManagerFor.Game.mapCheck.Add(GridPos,SpawnSquare);

               

            }
        }
      GameManagerFor.Game.  RandomSpawnHero();
        GameManagerFor.Game.randEvent();
        cam.transform.position = new Vector3(GameManagerFor.Game.x / 2, (GameManagerFor.Game.y / 2)-0.5f, -10);
       
    }

   
   
    }

