using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SetBladeToMouse(); //Grabs the mouse position
    }

    private void SetBladeToMouse()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10; //Distance of 10 Units from the camera to the layer of the fruits
        rb.position = Camera.main.ScreenToWorldPoint(mousePos); //Get the vector of our mouse position from WorldPoint
    }
}
