using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pawnManager : MonoBehaviour {

    public GameObject pawnObject;
    LevelOrganizer lvlOrg;
    public Dictionary<GameObject, GameObject> tilePawnMap;



	// Use this for initialization
	void Start () {
        
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void instantiatePawns()
    {
        lvlOrg = GetComponent<LevelOrganizer>();
        int pawnMax = (int)lvlOrg.mapLength * 2 ;

        GameObject[,] map = lvlOrg.getMapInstance();

        Dictionary<GameObject, GameObject> tilePawnMap = new Dictionary<GameObject, GameObject>();

        //GameObject[] pawnArray = new GameObject[15];
        int pawnCounter = 0;

        for (int i = 0; i < pawnMax; i++)
        {
            

            if (i < lvlOrg.mapLength)
            {
                GameObject temp = Instantiate<GameObject>(pawnObject, map[0, pawnCounter].transform.position, new Quaternion(0, 0, 0, 0));
                temp.GetComponent<pawnScript>().setPawnMan(this);
                temp.GetComponent<pawnScript>().setTeamFlag(1);
                temp.GetComponent<pawnScript>().setCurrentTile(map[0, pawnCounter].GetComponent<tileScript>());
                tilePawnMap.Add(map[0, pawnCounter], temp);
                pawnCounter++;
            }
            else {
                GameObject temp = Instantiate<GameObject>(pawnObject, map[1, pawnCounter].transform.position, new Quaternion(0, 0, 0, 0));
                temp.GetComponent<pawnScript>().setPawnMan(this);
                temp.GetComponent<pawnScript>().setTeamFlag(1);
                temp.GetComponent<pawnScript>().setCurrentTile(map[1, pawnCounter].GetComponent<tileScript>());
                tilePawnMap.Add(map[1, pawnCounter], temp);
                pawnCounter++;
            }

            if (pawnCounter == 8)
            {
                pawnCounter = 0;
            }
            
        }
    }


    public enum attacks
    {
        ROCK,
        PAPER,
        SCISSORS
    }
}
