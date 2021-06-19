using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Plansza : MonoBehaviour
{
    // rozmiar planszy
    public static int w = 10;
    public static int h = 20;
    public static Transform[,] grid = new Transform[w, h];
    
    public static void applySettings(float set_speed, int type)
    {
        Grupa.set_speed(set_speed, type);
        border.Settings(type);
        Spawner.Settings(type);


       switch(type){
           case 0:
             w=6;
             break;
            case 1:
             w=10;
             break;
            case 2:
            w = 14;
            break;
       }

         grid = new Transform[w, h];

    }


    public static Vector2 roundVec2(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x),
                           Mathf.Round(v.y));
    }

    public static bool insideBorder(Vector2 pos)
    {
        return ((int)pos.x >= (10-w) &&
                (int)pos.x < 10 &&
                (int)pos.y >= 0);
    }

    public static void deleteRow(int y)
    {
        for (int x = 0; x < w; x++)
        {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;

        }
    }

    public static void decreaseRow(int y)
    {
        for (int x = 0; x < w; x++)
        {
            if (grid[x, y] != null)
            {
                // jedna kratka w dol
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;

                // aktualizacja pozycji bloku
                grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    public static void decreaseRowsAbove(int y)
    {
        for (int i = y; i < h; ++i)
            decreaseRow(i);
    }

    public static bool isRowFull(int y)
    {
        for (int x = 0; x < w; x++)
            if (grid[x, y] == null)
                return false;


        scorebord.instance.ScoreUpdate();
        return true;
    }

    public static void deleteFullRows()
    {
        for (int y = 0; y < h; y++)
        {
            if (isRowFull(y))
            {
                deleteRow(y);
                decreaseRowsAbove(y + 1);
                y--;
            }
        }
    }
}
