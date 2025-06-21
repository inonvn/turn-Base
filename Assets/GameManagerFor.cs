
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static eventFor;

public class GameManagerFor : MonoBehaviour
{
    public static GameManagerFor Game;
    public GameObject Player;
    public GameObject mousePos;
    public ChooseZone Grid;
    public int x, y;
    public bool HeroSpawn, InChoose;
    public HashSet<ChooseZone> gridMap = new HashSet<ChooseZone>();
    public PlayerMove chara;
    public TypeSquare TypeSquares;


    public Dictionary<Vector2Int, TypeSquare> mapCheck = new Dictionary<Vector2Int, TypeSquare>();
    public MapPath PathFind;
    public List<TypeSquare> path = new List<TypeSquare>();
    public int speed;
    public int ranged;
    public List<TypeSquare> test1 = new List<TypeSquare>();
    public List<eventFor> eventkey = new List<eventFor>();
    public eventFor eventf;
 
    public GameObject fade;
    
    public void Awake()
    {
        Game = this;
    }
    public void Start()
    {

        PathFind = new MapPath();

    }
    public void LateUpdate()
    {

        if (chara != null)
        {
            checkRay();

            if (Input.GetMouseButtonDown(0))
            {
                if (chara.pos == TypeSquares)
                {
                    if (InChoose == false)
                    {
                        chooseHero();
                    }
                    else
                    {
                        unchoose();
                    }
                    InChoose = !InChoose;
                }
                if (InChoose == true)
                {
                    getinrange();
                    path = PathFind.Path(chara.pos, TypeSquares, test1);
                    
                    
                }
                else
                {
                    var test1 = showZone(TypeSquares, ranged);
                    foreach (var item in test1)
                    {
                        item.hide();
                    }
                }

            }

            if (path.Count > 0)

            {
                findWay();
            }
        }
    }
    public key rand1()
    {
        int i = 0;
        var e = (key)Random.Range((int)key.none, (int)key.Exit + 1);

        if (e == key.Exit)
        {
            i++;
            if (i > 1)
                e = (key)Random.Range((int)key.none, (int)key.trap + 1);
        }


        return e;
    }
    public void randEvent()
    {
        foreach (var p in mapCheck)
        {
            if (p.Value.itWall != true && p.Value != chara.pos)
                p.Value.randomEvent = rand1();
            else if (p.Value == chara.pos)
                p.Value.randomEvent = key.none;
        }
        var e = mapCheck.Where(i => i.Value.randomEvent == key.Exit);
        if (e == null)
        {
            
            randEvent();
        }
    }
    void getinrange()
    {
        foreach (var item in test1)
        {
            item.hide();

        }

        test1 = showZone(chara.pos, ranged);

        foreach (var item in test1)
        {
            
            item.show();
        }
    }

    private void findWay()
    {
        chara.transform.position = Vector2.MoveTowards(chara.transform.position, path[0].transform.position, speed * Time.deltaTime);
        chara.transform.position = new Vector3(chara.transform.position.x, chara.transform.position.y, 0);
        if (Vector2.Distance(chara.transform.position, path[0].transform.position) < 0.01f)
        {
            
                charapos(path[0]);
                
                path.RemoveAt(0);
            eventcheck();
        }
        if (path.Count == 0)
        {
            getinrange();
        }
    }

    private void eventcheck()
    {
        var tes = chara.pos.randomEvent;
        if (tes == key.Eventcombat)
        {
            print("in combat");
            path = new List<TypeSquare>();
            triggercombat();
        }
       else if (tes == key.Eventbuff)
        {
            print("in buff");
            path = new List<TypeSquare>();

        }
        else  if (tes == key.EventOpenChest)
        {
            print("in chest");
            path = new List<TypeSquare>();

        }
        else   if (tes == key.Exit)
        {
            print("in exit");
            path = new List<TypeSquare>();

        }
        else if (tes == key.KeyExit)
        {
            print("in key");
            path = new List<TypeSquare>();

        }
        else
        {
            print("none");
        }
    }

    public void checkRay()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouse1 = new Vector2(mouse.x, mouse.y);


        RaycastHit2D[] hit = Physics2D.RaycastAll(mouse1, Vector2.zero);

        if (hit.Length > 0)
        {

            var test = hit.OrderBy(i => i.collider.transform.position.z).FirstOrDefault();
            mousePos.transform.position = test.transform.position;

            TypeSquares = test.collider.gameObject.GetComponent<TypeSquare>();

        }


    }
    public void chooseHero()
    {


    }
    public void unchoose()
    {


    }



    public void RandomSpawnHero()
    {

       
        foreach (var t in mapCheck)
        {
            if (Random.Range(0, 8) == 0 && t.Value.itWall == false && chara == null)
            {
               
                TypeSquares = t.Value;
                chara = Instantiate(Player).GetComponent<PlayerMove>();
                charapos(TypeSquares);

                HeroSpawn = true;
            }


        }
    }

    private void charapos(TypeSquare typeSquares)
    {
        chara.transform.position = new Vector3(typeSquares.transform.position.x, typeSquares.transform.position.y, 0.001f);
        chara.pos = typeSquares;
    }

    public List<TypeSquare> showZone(TypeSquare e, int range)
    {
        var inrange = new List<TypeSquare>();
        var tp = new List<TypeSquare>();
        int step = 0;
        inrange.Add(e);
        tp.Add(e);
        while (step < range)
        {
            var squareXQ = new List<TypeSquare>();
            foreach (var i in tp)
            {
                squareXQ.AddRange(PathFind.neigbour(i, new List<TypeSquare>()));
            }
            inrange.AddRange(squareXQ);
            tp = squareXQ.Distinct().ToList();
            step++;
        }

        return inrange.Distinct().ToList();
    }
    public void triggercombat()
    {

        StartCoroutine(load());
    }    
    IEnumerator load ()
    {
        
            fade.SetActive(true);
        yield return new WaitForSeconds(1);
            SceneManager.LoadScene(1);
        
    }    

    // Update is called once per frame
    void Update()
    {

    }
}
