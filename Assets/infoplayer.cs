using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infoplayer : MonoBehaviour
{
    // Start is called before the first frame update
    public static infoplayer eStat;
 public   Dictionary<stat, int> statMap = new Dictionary<stat, int>();

    public int e;
    public void Awake()
    {
        eStat = this;
    }
    public void statadd()
    {
        statMap.Add(stat.dame, 10);
        statMap.Add(stat.maxSanity, 10);
        statMap.Add(stat.Maxhp, 10);
        statMap.Add(stat.RateHit, 10);


        int o = statMap[stat.Maxhp];

        print(o);
    } 
   
    }
public enum stat
{
    dame,
    maxSanity,
    sanity,
    Maxhp,
    hp,
    RateHit,
}
