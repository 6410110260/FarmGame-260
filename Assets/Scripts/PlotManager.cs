using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour
{
    bool isPlanted = false;
    public SpriteRenderer plant;
    int plantStage = 0;
    public PlantObject selectplant;
    float timer;
    SpriteRenderer coin;
    float coin_timer;

    SpriteRenderer Plot;
    bool isPreplot = false;
    public Sprite PrePlot;
    FarmManager fm;


    void Start()
    {
        Plot = GetComponent<SpriteRenderer>();
        fm = FindObjectOfType<FarmManager>();
        coin = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlanted)
        {
            timer -= Time.deltaTime;
            if (timer < 0 && plantStage < selectplant.plantStages.Length - 1) //Check จำนวนภาพ sprite
            {
                timer = selectplant.timeBtwStages;
                plantStage++;
                UpdatePlant();
            }
        }
        else
        {
            coin_timer -= Time.deltaTime;
            if (coin_timer < 0)
            {
                coin.gameObject.SetActive(false);
            }
        }

    }
    public void Water()
    {
        if (isPlanted)
        {
            timer -= Time.deltaTime;
            if (timer < 0 && plantStage < selectplant.plantStages.Length - 1) //Check จำนวนภาพ sprite
            {
                timer = selectplant.timeBtwStages;
                plantStage++;
                UpdatePlant();
            }
        }
    }
    private void OnMouseDown()
    {
        Debug.Log("Click");
        if (isPlanted == false)
        {
            if (isPreplot == true && fm.selected_plant.buyprice <= fm.money)
            {
                Plant(fm.selected_plant);
            }
        }

    }

    public void Harvest()
    {
        if (isPlanted)
        {
            if (plantStage == selectplant.plantStages.Length - 1)
            {
                isPlanted = false;
                plant.gameObject.SetActive(false);
                fm.Transaction(selectplant.sellprice);
                coin.gameObject.SetActive(true);
                coin_timer = 1f;  //Time in second per frame
            }
        }
    }
    public void Destroy()
    {
        isPlanted = false;
        plant.gameObject.SetActive(false);
    }
    void Plant(PlantObject newPlant)
    {
        selectplant = newPlant;
        isPlanted = true;

        fm.Transaction(-selectplant.buyprice);

        plantStage = 0;
        UpdatePlant();
        timer = selectplant.timeBtwStages;
        coin.gameObject.SetActive(false);
        plant.gameObject.SetActive(true);

    }
    void UpdatePlant()
    {
        plant.sprite = selectplant.plantStages[plantStage];
    }
    private void OnMouseOver()
    {
        if (isPlanted)
        {
            Plot.color = Color.red;
        }
        else
        {
            Plot.color = Color.green;
        }
    }
    private void OnMouseExit()
    {
        Plot.color = Color.white;
    }
    public void ChangeSprite()
    {
        Plot.sprite = PrePlot;
        isPreplot = true;
    }

}