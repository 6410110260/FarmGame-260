    using UnityEngine;

    public class PlotManager : MonoBehaviour
    {
        bool isPlanted = false;
        SpriteRenderer myplant;
        BoxCollider2D myplantCollider;
        int plantStage = 0;
        SpriteRenderer plot;
        PlantObject selectedPlant;
        float timer;

    FarmManager fm;

        // Start is called before the first frame update
        void Start()
        {
            myplant = transform.GetChild(0).GetComponent<SpriteRenderer>();
            myplantCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
            plot = GetComponent<SpriteRenderer>();
            fm = transform.parent.GetComponent<FarmManager>();

    }

    // Update is called once per frame
    void Update()
        {
            if (isPlanted)
            {
                timer -= Time.deltaTime;

                if (timer < 0 && plantStage < selectedPlant.plantStages.Length - 1)
                    {
                        timer = selectedPlant.timeBtwStages;
                        plantStage++;
                        UpdatePlant();
                    }
            }
        }

        private void OnMouseDown()
        {
            if (isPlanted)
            {
                if (plantStage == selectedPlant.plantStages.Length - 1 && !fm.isPlanting)
                {
                    Harvest();
                }
            }
            else if (fm.isPlanting && fm.selectPlant.plant.buyPrice <= fm.money)
            {
                Plant(fm.selectPlant.plant);
            }
        }



        void Harvest()
        {
            isPlanted = false;
            myplant.gameObject.SetActive(false);
            fm.Transaction(selectedPlant.sellPrice);
        }

        void Plant(PlantObject newPlant)
        {
            selectedPlant = newPlant;
            fm.Transaction(-selectedPlant.buyPrice);
            isPlanted = true;
            plantStage = 0;
            UpdatePlant();
            timer = selectedPlant.timeBtwStages;
            myplant.gameObject.SetActive(true);
            Debug.Log("Plant");
        }

    void UpdatePlant()
    {
       
        myplant.sprite = selectedPlant.plantStages[plantStage];
      
    }

    private void OnMouseOver()
    {
        if (isPlanted)
        {
            plot.color = Color.red;
        }
        else
        {
            plot.color = Color.green;
        }
    }
    private void OnMouseExit()
    {
        plot.color = Color.white;
    }

}

    
