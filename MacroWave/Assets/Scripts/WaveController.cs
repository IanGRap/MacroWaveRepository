using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using System;

namespace Application
{
    public class WaveController : MonoBehaviour
    {
        private int waveCount;
        private bool activeWave;
        //private GameObject[] Spawners; //List that holds all enemy spawners

        void Start()
        {
            //Spawners = GameObject.FindObjectsOfType("EnemySpawner"); //NEED SPAWNER PREFAB
            waveCount = 0;
            activeWave = false;
        }

        void update()
        {
           // foreach (GameObject spawner in Spawners)
            {
                //if (spawner.active)
                {
                    //waveCount++;
                }
            }
        }
    }
}
