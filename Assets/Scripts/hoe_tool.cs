using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class hoe_tool : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collision) => Log(collision);
    void Log(Collider2D collision, [CallerMemberName] string message = null)
    {
        Debug.Log(collision.gameObject.name.ToString());
        collision.gameObject.GetComponent<PlotManager>().Destroy();
    }


    private float startPosX;
    private float startPosY;
    private bool isBeing = false;

    // Update is called once per frame
    void Update()
    {
        if (isBeing == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
        }
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
            isBeing = true;
        }
    }
    private void OnMouseUp()
    {
        isBeing = false;
        this.gameObject.transform.localPosition = new Vector3(-7, 2, 0);
    }
}
