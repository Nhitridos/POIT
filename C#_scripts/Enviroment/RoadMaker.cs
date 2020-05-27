using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMaker : MonoBehaviour
{
    // Deklaracia premennych
    public GameObject road;
    public GameObject enviro;
    
    void Start()
    {
        CreateRoad(30);
        CreateBackRoad(30);
    }

    void CreateRoad(int cnt) // Tvorba cesty pred autom
    {
        for (int i = 0; i < cnt; i++)
        {
            GameObject roadClone = Instantiate(road, new Vector3(-2.25f, road.transform.position.y, i*10f), road.transform.rotation);
            roadClone.transform.parent = enviro.transform;
            roadClone.name = "Road" + (i + 1);
        }
    }

    void CreateBackRoad(int cnt) // Tvorba cesty za autom
    {
        for (int i = 0; i < cnt; i++)
        {
            GameObject roadClone = Instantiate(road, new Vector3(-2.25f, road.transform.position.y, i * -10f), road.transform.rotation);
            roadClone.transform.parent = enviro.transform;
            roadClone.name = "Road" + (i + 31);
        }
    }
}
