using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class PlantItem : MonoBehaviour
{
    public PlantObject plant;

    public UnityEngine.UI.Text nameTxt;
    public UnityEngine.UI.Text priceTxt;
    public UnityEngine.UI.Image icon;

    public UnityEngine.UI.Image btnImage;
    public UnityEngine.UI.Text btnTxt;

    FarmManager fm;

    // Start is called before the first frame update
    void Start()
    {
        fm = FindObjectOfType<FarmManager>();
        InitializeUI();
    }

    public void BuyPlant()
    {
        UnityEngine.Debug.Log("Bought " + plant.plantName);
        fm.SelectPlant(this);
    }

    void InitializeUI()
    {
        nameTxt.text = plant.plantName;
        priceTxt.text = "$" + plant.buyPrice;
        icon.sprite = plant.icon;
    }

}