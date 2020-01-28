using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>(); //If the object is a blade

        if(!b)
        {
            return;
        }
        FindObjectOfType<GameManager>().OnBombHit();
    }
}
