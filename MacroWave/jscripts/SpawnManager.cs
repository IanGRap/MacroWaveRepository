using UnityEngine;
using System.Collections;

public class SpawnManager{
  int[] activeEnemies;

  void start(){

  }

  void update(){

  }

  GameObject spawn(location){
    var vertExtent = Camera.main.camera.orthographicSize;
    var horzExtent = vertExtent * Screen.width / Screen.height;


    GameObject newEnemy = Instantiate(pizza_enemy, ,Quaternion.identity)//GameObject.find("enemy");

    return newEnemy;
  }

  void despawn(enemy){
    BinarySearch(activeEnemies, enemy);
  }

}
