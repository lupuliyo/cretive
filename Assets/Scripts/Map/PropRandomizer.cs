using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PropRandomizer : MonoBehaviour
{
    public List<GameObject> propsSpawn;
    public List<GameObject> propsPrefabs;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnProps();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnProps()
    {
        foreach (GameObject propSpawn in propsSpawn)
        {
            int rand = Random.Range(0, propsPrefabs.Count);
            GameObject prop = Instantiate(propsPrefabs[rand], propSpawn.transform.position, Quaternion.identity);
            prop.transform.parent = propSpawn.transform;
        } 
    }
}
