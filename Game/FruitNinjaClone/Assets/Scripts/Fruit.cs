using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject slicedFruitPrefab;

    private void Update()
    {

    }

    public void CreateSlicedFruit()
    {
        var inst = Instantiate(slicedFruitPrefab, transform.position, transform.rotation);

        Rigidbody[] rbsOnSliced = inst.GetComponentsInChildren<Rigidbody>(); //Since we are grabbing multiple components we need to get Components and we need an array of Rigidbody[]
        
        foreach(Rigidbody r in rbsOnSliced)
        {
            r.transform.rotation = Random.rotation;
            r.AddExplosionForce(Random.Range(500, 1000), transform.position, 5f);
        }

        FindObjectOfType<GameManager>().IncreaseScore(3);
        Destroy(gameObject);
        Destroy(inst, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>(); //Grab the collision and set it to b if it is of type blade

        if(!b)
        {
            return;
        }
        else
        {
            CreateSlicedFruit();
        }
    }

}
