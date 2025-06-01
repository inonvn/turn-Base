using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class MapPath
{
    public List<TypeSquare> Path(TypeSquare start, TypeSquare end)
    {
     List<TypeSquare> open = new List<TypeSquare>();
        List<TypeSquare> close = new List<TypeSquare>();
        open.Add(start);
        while (open.Count > 0)
        {
            TypeSquare current = open.OrderBy(e=>e.F).First();
            open.Remove(current);
            close.Add(current);
            if (current==end)
            {
                return ResetList(start,end);
            }
            var checkNei = neigbour(current);
            foreach (var e in checkNei)
            {
                if (e.itWall == true || close.Contains(e) )
                { continue; }
                e.G = MathM(start, e);
                e.H = MathM(end, e);
                
                e.Part = current;
                if (open.Contains(e)== false )
                {
                    open.Add(e);
                }    
            }
           
        }
        return new List<TypeSquare>();

    }

    private List<TypeSquare> ResetList(TypeSquare start, TypeSquare end)
    {
        List<TypeSquare> reset = new List<TypeSquare>();
        var Current = end;
        while (Current != start)
        {
            reset.Add(Current);
            Current= Current.Part;
        }
        reset.Reverse();
        return reset;
    }

    private int MathM(TypeSquare a, TypeSquare checkNei)
    {
       return Mathf.Abs(a.locationV2.x-checkNei.locationV2.x)+ Mathf.Abs(a.locationV2.y - checkNei.locationV2.y);

    }

    public List<TypeSquare> neigbour(TypeSquare current)
    {
        var m = GameManagerFor.Game.mapCheck;
        
       List<TypeSquare> ni = new List<TypeSquare>();

        Vector2Int ViTriCheck = new Vector2Int(GameManagerFor.Game.GridPosCheck.x,GameManagerFor.Game.GridPosCheck.y+1);
        if (m.ContainsKey(ViTriCheck))
        {
            ni.Add(m[ViTriCheck]);
        }
         ViTriCheck = new Vector2Int(GameManagerFor.Game.GridPosCheck.x, GameManagerFor.Game.GridPosCheck.y - 1);
        if (m.ContainsKey(ViTriCheck))
        {
            ni.Add(m[ViTriCheck]);
        }
         ViTriCheck = new Vector2Int(GameManagerFor.Game.GridPosCheck.x - 1, GameManagerFor.Game.GridPosCheck.y );
        if (m.ContainsKey(ViTriCheck))
        {
            ni.Add(m[ViTriCheck]);
        }
        ViTriCheck = new Vector2Int(GameManagerFor.Game.GridPosCheck.x + 1, GameManagerFor.Game.GridPosCheck.y);
        if (m.ContainsKey(ViTriCheck))
        {
            ni.Add(m[ViTriCheck]);
        }
        return ni;
    }
}
