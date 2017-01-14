using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pawnScript : MonoBehaviour {

    [SerializeField]
    pawnManager.attacks attackType;
    [SerializeField]
    int teamFlag;
    [SerializeField]
    tileScript currentTile;

    List<Renderer> pathTiles;

    public bool isSelected = false;

    pawnManager pawnMan;

	// Use this for initialization
	void Start () {

        
	}

    public void setPawnMan(pawnManager man)
    {
        pawnMan = man;
    }
    public void setTeamFlag(int team)
    {
        teamFlag = team;
    }
    public void setCurrentTile(tileScript tile)
    {
        currentTile = tile;
    }
    

    // Update is called once per frame
    void Update () {

        if (isSelected)
        {
            showPath();
        }

        if (currentTile.GetComponent<tileScript>().getTeamFlag() != teamFlag)

            currentTile.GetComponent<tileScript>().setTeamFlag(teamFlag);
        	
	}

    void showPath()
    {
        pathTiles = new List<Renderer>();

        Renderer[] rens = new Renderer[4];

        if (teamFlag != currentTile.getNeighbour(playerScript.direction.TOP).GetComponent<tileScript>().getTeamFlag())
        {
            if (!Camera.main.GetComponent<HighlightsMultiple>().objectRenderers.Contains(currentTile.getNeighbour(playerScript.direction.TOP).GetComponent<Renderer>()))
            {
                Camera.main.GetComponent<HighlightsMultiple>().objectRenderers.Add(currentTile.getNeighbour(playerScript.direction.TOP).GetComponent<Renderer>());
            }
        }
        if (teamFlag != currentTile.getNeighbour(playerScript.direction.BOTTOM).GetComponent<tileScript>().getTeamFlag())
        {
            if (!Camera.main.GetComponent<HighlightsMultiple>().objectRenderers.Contains(currentTile.getNeighbour(playerScript.direction.BOTTOM).GetComponent<Renderer>()))
            {
                Camera.main.GetComponent<HighlightsMultiple>().objectRenderers.Add(currentTile.getNeighbour(playerScript.direction.BOTTOM).GetComponent<Renderer>());
            }
        }
        if (teamFlag != currentTile.getNeighbour(playerScript.direction.RIGHT).GetComponent<tileScript>().getTeamFlag())
        {
            if (!Camera.main.GetComponent<HighlightsMultiple>().objectRenderers.Contains(currentTile.getNeighbour(playerScript.direction.RIGHT).GetComponent<Renderer>()))
            {
                Camera.main.GetComponent<HighlightsMultiple>().objectRenderers.Add(currentTile.getNeighbour(playerScript.direction.RIGHT).GetComponent<Renderer>());
            }
        }
        if (teamFlag != currentTile.getNeighbour(playerScript.direction.LEFT).GetComponent<tileScript>().getTeamFlag())
        {
            if (!Camera.main.GetComponent<HighlightsMultiple>().objectRenderers.Contains(currentTile.getNeighbour(playerScript.direction.LEFT).GetComponent<Renderer>()))
            {
                Camera.main.GetComponent<HighlightsMultiple>().objectRenderers.Add(currentTile.getNeighbour(playerScript.direction.LEFT).GetComponent<Renderer>());
            }
        }

        //pathCam.GetComponent<HighlightsMultiple>().objectRenderers.Add(rens) = rens; //pathTiles.ToArray();
        Camera.main.GetComponent<HighlightsMultiple>().enabled = true;
        //Camera.main.GetComponent<HighlightsFX>().objectRenderer = currentTile.getNeighbour(playerScript.direction.LEFT).GetComponent<MeshRenderer>(); //pathTiles.ToArray();
       // Camera.main.GetComponent<HighlightsFX>().enabled = true;


    }

    public void setAttackType(pawnManager.attacks type)
    {
        attackType = type;
    }

   
}
