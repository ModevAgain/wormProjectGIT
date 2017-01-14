using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseScript : MonoBehaviour {

    bool selected = false;

    // Use this for initialization
    void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {

        if(!selected)
        checkForMouseCollision();

        }

    void checkForMouseCollision()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(mouseRay,out hit)){

            if(hit.collider.tag == "pawn")
            {
                if (!Camera.main.GetComponent<HighlightsMultiple>().objectRenderers.Contains(hit.transform.GetComponent<Renderer>())){

                    Camera.main.GetComponent<HighlightsMultiple>().objectRenderers.Add(hit.transform.GetComponent<Renderer>());
                    Camera.main.GetComponent<HighlightsMultiple>().enabled = true;
                }
               

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    selected = true;
                    hit.transform.GetComponent<pawnScript>().isSelected = true;
                }

            }
            else
            {
                Camera.main.GetComponent<HighlightsMultiple>().objectRenderers.Clear();
                Camera.main.GetComponent<HighlightsMultiple>().enabled = false;

            }

        }
        else
        {
            Camera.main.GetComponent<HighlightsMultiple>().objectRenderers.Clear();
            Camera.main.GetComponent<HighlightsMultiple>().enabled = false;

        }



    }

}

