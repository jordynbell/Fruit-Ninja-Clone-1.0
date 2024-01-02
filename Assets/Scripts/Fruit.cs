using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject slicedFruitPrefab;

    [System.Obsolete]
    public void CreateSlicedFruit()
    {
        GameObject inst = (GameObject)Instantiate(slicedFruitPrefab, transform.position, transform.rotation);

        FindObjectOfType<GameManager>().PlayRandomSound();

        Rigidbody[] rbsOnSliced = inst.transform.GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody r in rbsOnSliced)
        { 
            r.transform.rotation = Random.rotation;
            r.AddExplosionForce(Random.Range(500,1000), transform.position, 5);
        }

        FindObjectOfType<GameManager>().IncreaseScore(3);

        Destroy(inst.gameObject, 5);
        Destroy(gameObject);
    }

    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade blade = collision.GetComponent<Blade>();

        if(!blade) return;

        CreateSlicedFruit();
    }

}
