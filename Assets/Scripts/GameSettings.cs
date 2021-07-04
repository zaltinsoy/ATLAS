using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public Particle ball = new Particle();
    public GameObject[] gravy;
    public GameObject[] lazy;

    void Start()
    {
        //Set Cursor to not be visible
        Cursor.visible = false;

        gravy = GameObject.FindGameObjectsWithTag("gravy");
        lazy = GameObject.FindGameObjectsWithTag("lazy");
        
    }

    private void Update()
    {
      

    }
  



}
