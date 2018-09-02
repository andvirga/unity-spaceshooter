﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--Main class of the Game, controls everything
public class GameController : MonoBehaviour
{
    #region Public Variables (Visibles from Unity)

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    #endregion

    #region Methods

    private IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                var spawnPosition = new Vector3
                {
                    x = Random.Range(-spawnValues.x, spawnValues.x),
                    y = spawnValues.y,
                    z = spawnValues.z
                };
                var spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    // Use this for initialization
    public void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    // Update is called once per frame
    public void Update()
    {

    }

    #endregion
}