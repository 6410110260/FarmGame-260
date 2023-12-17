using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmManager : MonoBehaviour
{
    public PlantObject selected_plant;

    public int money = 100;
    public Text moneyTxt;

    // Start is called before the first frame update
    void Start()
    {
        moneyTxt.text = "$" + money;
    }

    public void farmplant(PlantObject plant)
    {
        selected_plant = plant;
    }

    public void Transaction(int value)
    {
        money += value;
        moneyTxt.text = "$" + money;
    }
}