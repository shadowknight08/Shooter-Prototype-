using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyprefab;

    private bool spawn = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(spawn == true)
        {
            spawn = false;
            Vector3 spawnpoint = new Vector3(Random.Range(1, 8), 1, Random.Range(1, 8));
            Instantiate(enemyprefab, spawnpoint, Quaternion.identity);
            StartCoroutine(Spawnenemy());
        }
    }


    IEnumerator Spawnenemy()
    {
        yield return new WaitForSeconds(3f);

        spawn = true;

    }
}
