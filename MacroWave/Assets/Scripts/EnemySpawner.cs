//This is the fault of Andrew
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using System;

namespace Application
{
	public class EnemySpawner : MonoBehaviour
	{
		private GameObject Spawner;
        private int enemyCount;
        public bool spawnerActive;
        private List<GameObject> activeEnemies = new List<GameObject>(); //List that holds all enemy objects
        private List<GameObject> nextWave = new List<GameObject>(); //List of next enemies to spawn

        //Attaches to the Spawner GameObject
        void Start(){     
            Spawner = GameObject.Find("Spawner");
            enemyCount = activeEnemies.Count;
            spawnerActive = false;
		}

        void update()
        {
            enemyCount = activeEnemies.Count;
            if (!spawnerActive && enemyCount <= 0) spawnMore(nextWave);
            else if (enemyCount > 0) spawnerActive = true;
        }

        //Spawns all enemies slated to spawn for next wave from List of enemies to spawn
        private IEnumerator spawnMore(List<GameObject> Enemies)
        {
            spawnerActive = false;
            List<GameObject> enemiesToSpawn = Enemies;
            foreach (GameObject enemy in enemiesToSpawn)
            {
                SpawnEnemy(enemy);
                enemyCount += 1;
                yield return new WaitForSeconds(1f);
            }
        }

        //Spawns enemy at the Spawn Gate's position
        public void SpawnEnemy(GameObject Enemy){
            activeEnemies.Add(Enemy);
			Instantiate (Enemy, Spawner.transform.position, Quaternion.identity);
		}

        //Method for when enemy is defeated, might move to Wave controller
        public void DespawnEnemy(GameObject Enemy)
        {
            activeEnemies.Remove(Enemy);
            enemyCount -= 1;
            Destroy(Enemy);
        }

        //Get List of enemies to spawn for next wave
        public List<GameObject> getEnemiesToSpawn()
        {
            return nextWave;
        }

        //Set List of enemies to spawn for next wave
        public void setEnemiesToSpawn(List<GameObject> array)
        {
            nextWave = array;
        }
	}
}
