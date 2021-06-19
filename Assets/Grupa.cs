using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grupa : MonoBehaviour
{
    // czas od ostatniego przesuniecia w dol
    float lastFall = 0;
    static float speed = 0.8f;
    public static int offset = 0;
 
   
    // funkcja ustawiajaca predkosc z ustawien
    public static void set_speed(float i, int type)
    {
        speed = 1.25f - i;

        switch (type){
            case 0:
                 offset = -4;
                 break;
            case 1:
                 offset = 0;
                 break;
            case 2 :
                 offset = 4;
                break;
             default:
                 offset = 0;
                break;

        }

    }

    void Start()
    {
        // jeżeli tworzymy nowy bloczek i nie jest on prawidlowy to przegrywamy bo nie ma juz miejca :(
        if (!isValidGridPos())
        {
            Debug.Log("GAME OVER");
            scorebord.instance.stop = true;
            Destroy(gameObject);
        }
    }

    bool isValidGridPos()
    {
        foreach (Transform child in transform)
        {
            Vector2 v = Plansza.roundVec2(child.position);

            // sprawdzenie czy w srodku planszy
            if (!Plansza.insideBorder(v))
                return false;

            // sprawdzamy czy blok jest na naszych koordynatach i nie jest czescia naszego bloku
            if (Plansza.grid[(int)v.x+offset, (int)v.y] != null &&
                Plansza.grid[(int)v.x+offset, (int)v.y].parent != transform)
                return false;
        }
        return true;
    }

    void updateGrid()
    {
        // usuwanie starych blokow (te ktore byly przed przesunieciem)
        for (int y = 0; y < Plansza.h; ++y)
            for (int x = 0; x < Plansza.w; ++x)
                if (Plansza.grid[x, y] != null)
                    if (Plansza.grid[x, y].parent == transform)
                        Plansza.grid[x, y] = null;

        // pokazanie blokow po przesunieciu
        foreach (Transform child in transform)
        {
            Vector2 v = Plansza.roundVec2(child.position);
            Plansza.grid[(int)v.x+offset, (int)v.y] = child;
        }
    }

    void Update()
    {
        // ruch w lewo
        if (Input.GetKeyDown(KeyCode.A))
        {
            // modyfikujemy pozycje
            transform.position += new Vector3(-1, 0, 0);

            // sprawdzamy czy prawidlowa
            if (isValidGridPos())
                // jezeli tak to aktualizujemy plansze
                updateGrid();
            else
                // jezeli nie to sie cofamy
                transform.position += new Vector3(1, 0, 0);
        }

        // analogicznie dla reszty
        else if (Input.GetKeyDown(KeyCode.D))
        {
            
            transform.position += new Vector3(1, 0, 0);

            
            if (isValidGridPos())
               
                updateGrid();
            else
               
                transform.position += new Vector3(-1, 0, 0);
        }

        // obrót
        else if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Rotate(0, 0, -90);

            
            if (isValidGridPos())
                
                updateGrid();
            else
               
                transform.Rotate(0, 0, 90);
        }


        // poruszanie sie w dol i "spadanie"
        else if (Input.GetKeyDown(KeyCode.S) ||
                 Time.time - lastFall >= speed)
        {
           
            transform.position += new Vector3(0, -1, 0);


           
            if (isValidGridPos())
            {
               
                updateGrid();
            }
            else // czyli "wyladowalismy"
            {


                // wracamy
                transform.position += new Vector3(0, 1, 0);

                // usuwamy pelne wiersze
                Plansza.deleteFullRows();

                // tworzymy nowy bloczek 
                Spawner.instance.spawnNext();
                

                // wylaczamy skrypt
                enabled = false;
            }

            lastFall = Time.time;
        }
    }
}
