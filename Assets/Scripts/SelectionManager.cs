using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public Material matSelected;
    public Material defaultMaterial;
    private Transform transSelected;
    private string selectableTag = "gravy";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (transSelected != null)
        {
            var selectionRenderer = transSelected.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            transSelected = null; //clear the selection
        }

        //get the location of the center of the 
        var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //get tranform of the "hit" as selection
            var selection = hit.transform;
           if (selection.CompareTag(selectableTag))
           {
                var selectionRenderer = selection.GetComponent<Renderer>();
                selectionRenderer.material = matSelected;
                transSelected = selection;
            }
           
        }
    }

}

