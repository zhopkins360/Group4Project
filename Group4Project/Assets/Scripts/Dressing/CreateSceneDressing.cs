using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSceneDressing : MonoBehaviour
{
    public GameObject[] prefabs;

    private LevelManager level;

    // Start is called before the first frame update
    void Start()
    {
        level = gameObject.GetComponent<LevelManager>();

        StartCoroutine("SpawnDressingCoroutine");
    }

    private IEnumerator SpawnDressingCoroutine()
    {
        while (!level.gameOver)
        {
            SpawnDressing();
            yield return new WaitForSeconds(UnityEngine.Random.Range(.25f,.75f));
        }
    }

    private void SpawnDressing()
    {
        bool leftOrRight = UnityEngine.Random.value > 0.5f;

        int index = UnityEngine.Random.Range(0, prefabs.Length);

        Vector3 spawnLocation = new Vector3(prefabs[index].transform.position.x * (leftOrRight ? -1 : 1), prefabs[index].transform.position.y,30);

        Instantiate(prefabs[index], spawnLocation, prefabs[index].transform.rotation);
    }
}
