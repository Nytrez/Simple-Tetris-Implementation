using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class border : MonoBehaviour
{
    public static int type = 1;
    void Start()
    {
       switch (type)
        {
            case 0:
                transform.position = new Vector3(3.09f, 7f, 0f);
                 break;
            case 1:
                transform.position = new Vector3(-0.91f, 7f, 0f);
                 break;
            case 2:
                transform.position = new Vector3(-4.91f, 7f, 0f);
                 break;
            default:
                transform.position = new Vector3(0f, 7f, 0f);
                break;
        }
    }

    public static void Settings(int types)
    {
        type = types;
        
    }

    
}
