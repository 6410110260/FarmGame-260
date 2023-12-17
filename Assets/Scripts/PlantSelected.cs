using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantSelected : MonoBehaviour
{
    public PlantObject SE_plant;
    public Text Planttype;
    FarmManager fm;

    // Start is called before the first frame update
    void Start()
    {
        fm = FindObjectOfType<FarmManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        //Planttype.text = "Select : " + SE_plant.plantName;
        fm.selected_plant = SE_plant;
    }
}