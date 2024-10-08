using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Capsu : MonoBehaviour
{
    void Start()
    {
        // Initialization logic can go here if needed.
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, mousePos, 2f * Time.deltaTime);
    }
}