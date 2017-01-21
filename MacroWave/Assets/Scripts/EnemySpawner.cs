//This is the fault of Andrew
using UnityEngine;
using System.Collections;
namespace Application
{
	public class EnemySpawner : MonoBehaviour
	{
		private GameObject Spawner;

		//Attaches to the Spawner GameObject
		void Start(){
			Spawner = GameObject.Find("Spawner");
		}

		//Spawns enemy at the Spawn Gate's position
		public void SpawnEnemy(GameObject Enemy){
			Instantiate (Enemy, Spawner.transform.position);
		}

	}
}
