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

        //get the location of the center of the screen
        var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //get tranform of the "hit" as selection
            var selection = hit.transform;

            if (selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                var selectionGravity = selection.GetComponent<ChangeGravity>();
                selectionRenderer.material = matSelected;
                transSelected = selection;
                if (Input.GetKeyDown(KeyCode.Keypad6)) { selectionGravity.gravDirection = 6; }
                else if (Input.GetKeyDown(KeyCode.Keypad4)) { selectionGravity.gravDirection = 4; }
                else if (Input.GetKeyDown(KeyCode.Keypad8)) { selectionGravity.gravDirection = 8; }
                else if (Input.GetKeyDown(KeyCode.Keypad2)) { selectionGravity.gravDirection = 2; }
                else if (Input.GetKeyDown(KeyCode.KeypadPlus)) { selectionGravity.gravDirection = 5; }
                else if (Input.GetKeyDown(KeyCode.KeypadMinus)) { selectionGravity.gravDirection = 9; }
                else if (Input.GetKeyDown(KeyCode.Keypad0)) { selectionGravity.gravDirection = 7; }
            }


        }
    }

}

