
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MapPath
{
<<<<<<< HEAD
    public List<TypeSquare> Path(TypeSquare start, TypeSquare end,List<TypeSquare> Search)
    {
        
     List<TypeSquare> open = new List<TypeSquare>();
=======
    public List<TypeSquare> Path(TypeSquare start, TypeSquare end, List<TypeSquare> Search)
    {

        List<TypeSquare> open = new List<TypeSquare>();
>>>>>>> map-ngẫu-nhiên
        List<TypeSquare> close = new List<TypeSquare>();
        open.Add(start);
        while (open.Count > 0)
        {
<<<<<<< HEAD
            
            TypeSquare current = open.OrderBy(e=>e.F).First();
            open.Remove(current);
            close.Add(current);
          
            if (current==end)
=======

            TypeSquare current = open.OrderBy(e => e.F).First();
            open.Remove(current);
            close.Add(current);

            if (current == end)
>>>>>>> map-ngẫu-nhiên
            {
                return ResetList(start, end);
            }
<<<<<<< HEAD
            var checkNei = neigbour(current,Search);

            foreach (var e in checkNei)
            {
                Debug.Log($"{e.locationV2.x} , {e.locationV2.y}" );
             
                if (e.itWall == true || close.Contains(e) || math.abs(current.locationV2.y-e.locationV2.y)>1)
=======
            var checkNei = neigbour(current, Search);

            foreach (var e in checkNei)
            {
                Debug.Log($"{e.locationV2.x} , {e.locationV2.y}");

                if (e.itWall == true || close.Contains(e) || math.abs(current.locationV2.y - e.locationV2.y) > 1)
>>>>>>> map-ngẫu-nhiên
                { continue; }
                e.G = MathM(start, e);
                e.H = MathM(end, e);

                e.Part = current;
<<<<<<< HEAD
                if (!open.Contains(e) )
=======
                if (!open.Contains(e))
>>>>>>> map-ngẫu-nhiên
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
            Current = Current.Part;
        }
        reset.Reverse();
        return reset;
    }

    private int MathM(TypeSquare a, TypeSquare checkNei)
    {
        return Mathf.Abs(a.locationV2.x - checkNei.locationV2.x) + Mathf.Abs(a.locationV2.y - checkNei.locationV2.y);

    }

<<<<<<< HEAD
    public List<TypeSquare> neigbour(TypeSquare current,List<TypeSquare> inRange)
=======
    public List<TypeSquare> neigbour(TypeSquare current, List<TypeSquare> inRange)
>>>>>>> map-ngẫu-nhiên
    {
        var m = GameManagerFor.Game.mapCheck;
        Dictionary<Vector2Int, TypeSquare> TileToSeach = new Dictionary<Vector2Int, TypeSquare>();
        if (inRange.Count > 0)
        {
            foreach (var t in inRange)
            {
                TileToSeach.Add(t.locationV2copy, t);
            }
        }
        else
        {
            TileToSeach = m;
        }

<<<<<<< HEAD
                List<TypeSquare> ni = new List<TypeSquare>();

        Vector2Int ViTriCheck = new Vector2Int(current.locationV2.x,current.locationV2.y+1);
=======
        List<TypeSquare> ni = new List<TypeSquare>();

        Vector2Int ViTriCheck = new Vector2Int(current.locationV2.x, current.locationV2.y + 1);
>>>>>>> map-ngẫu-nhiên
        if (TileToSeach.ContainsKey(ViTriCheck))
        {
            ni.Add(TileToSeach[ViTriCheck]);
        }
<<<<<<< HEAD
         ViTriCheck = new Vector2Int(current.locationV2.x, current.locationV2.y - 1);
=======
        ViTriCheck = new Vector2Int(current.locationV2.x, current.locationV2.y - 1);
>>>>>>> map-ngẫu-nhiên
        if (TileToSeach.ContainsKey(ViTriCheck))
        {
            ni.Add(TileToSeach[ViTriCheck]);
        }
<<<<<<< HEAD
         ViTriCheck = new Vector2Int(current.locationV2.x - 1, current.locationV2.y );
=======
        ViTriCheck = new Vector2Int(current.locationV2.x - 1, current.locationV2.y);
>>>>>>> map-ngẫu-nhiên
        if (TileToSeach.ContainsKey(ViTriCheck))
        {
            ni.Add(TileToSeach[ViTriCheck]);
        }
        ViTriCheck = new Vector2Int(current.locationV2.x + 1, current.locationV2.y);
        if (TileToSeach.ContainsKey(ViTriCheck))
        {
            ni.Add(TileToSeach[ViTriCheck]);
        }
        return ni;
    }
}
