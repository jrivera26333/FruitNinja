using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] objectsToSpawn;
    public Transform[] spawnPlaces;
    public float minWait = .3f;
    public float maxWait = 1f;
    public float minForce = 12f;
    public float maxForce = 17f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruits()); //Coroutine takes in a function as a parameter that returns an IEnumerator
    }

    private IEnumerator SpawnFruits()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));

            Transform t = spawnPlaces[(Random.Range(0, spawnPlaces.Length))]; //Pick a random index from the size of our array

            GameObject go = null;
            float p = Random.Range(0, 100);

            if (p < 10) //10 percent chance its a bomb
            {
                go = objectsToSpawn[0];
            }
            else
                go = objectsToSpawn[Random.Range(1, objectsToSpawn.Length)]; //Bomb will be at index 0 so we start at 1

            GameObject fruit = Instantiate(go, t.position, t.rotation);
            fruit.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(minForce,maxForce), ForceMode2D.Impulse); //We want to transform from our object since we have a special rotation
            Debug.Log("Fruit gets Spawned!");

            Destroy(fruit, 5f);
        }
    }
}
