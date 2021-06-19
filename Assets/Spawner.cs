using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance { get; private set; }
    public static int typ = 1;

    void Start()
    {
        switch (typ)
        {
            case 0:
                transform.position = new Vector3(6f, 14f, 0f);
                 break;
            case 1:
                transform.position = new Vector3(4f, 14f, 0f);
                 break;
            case 2:
                transform.position = new Vector3(2f, 14f, 0f);
                 break;
            default:
                transform.position = new Vector3(5f, 14f, 0f);
                break;
        }

       instance = this;
        // tworzenie poczatkowego bloczku
        spawnNext();
    }

    public static void Settings(int types)
    {
         typ = types;
    }

    // Groups
    public GameObject[] groups;

    public void spawnNext()
    {
        // losujemy bloczek z puli
        int i = Random.Range(0, groups.Length);

        // tworzymy grupe na aktualnej pozycji
        Instantiate(groups[i],
                    transform.position,
                    Quaternion.identity);
    }

}
