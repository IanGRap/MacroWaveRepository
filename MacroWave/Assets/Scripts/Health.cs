//This is the fault of Andrew and Nicholas
// Jon: Adding connections to health UI
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace Application
{
	public class Health : MonoBehaviour
	{
		//Dem Vars
		public int HP;
		private int MaxHP;
		public float numIFrames; //how many frames player is invincible
		private bool isInvincible;
		private float WhenIStarted; //When invincible started
		private float WhenIStops; //When Invincibility should run out
        public int score;

		//Temp vars DELETE LATER
		public int damage;
		public int heal;

		// Health UI
		public Image heartOne;
		public Image heartTwo;
		public Image heartThree;
		public Sprite fullHeart;
		public Sprite halfHeart;
		public Sprite emptyHeart;

        //Testing
        public GameObject camera;

        public SoundFunctions soundFX;

		void Start() {
			isInvincible = false;
			MaxHP = HP;
		}

        //If wanting to damage input a positive number
        public void takeHealth(int change) {

            //Checks if in invincible frames
            if (isInvincible)
                return;

            //If not invincible
            if (HP - change < 0) {
                HP = 0;
                GetComponent<GameOver>().playerDied();
            }
            else {
                HP -= change;
                //Camera Shake when damage taken
                camera.GetComponent<CameraShake>().cameraShakeBurst(MaxHP - HP);
                camera.GetComponent<CameraShake>().persistentShake(MaxHP - HP);

                //soundFX.playCrowdCheer();
            }
            WhenIStarted = Time.time;
            WhenIStops = WhenIStarted + numIFrames;
            setInvincible();
        }
        
		//Healing
		public void gainHealth(int change){
			if (HP + change > MaxHP)
				HP = MaxHP;
			else
				HP += change;
		}

		//Checks if player is alive
		public bool isAlive(){
            if(HP > 0 == false) {
                //Call the game over function
                GetComponent<GameOver>().playerDied();
            }
			return HP > 0;
		}

		void Update(){
			if (isInvincible) {
				//Checks for if Invincibilty should run out
				if (WhenIStops < Time.time) {
					setNotInvincible ();
				}
			}

			if (isAlive ()) {
				if (HP == 6) {
					heartThree.sprite = fullHeart;
					heartTwo.sprite = fullHeart;
					heartOne.sprite = fullHeart;
				} else if (HP == 5) {
					heartThree.sprite = halfHeart;
					heartTwo.sprite = fullHeart;
					heartOne.sprite = fullHeart;
				} else if (HP == 4) {
					heartThree.sprite = emptyHeart;
					heartTwo.sprite = fullHeart;
					heartOne.sprite = fullHeart;
				} else if (HP == 3) {
					heartThree.sprite = emptyHeart;
					heartTwo.sprite = halfHeart;
					heartOne.sprite = fullHeart;
				} else if (HP == 2) {
					heartThree.sprite = emptyHeart;
					heartTwo.sprite = emptyHeart;
					heartOne.sprite = fullHeart;
				} else {
					heartThree.sprite = emptyHeart;
					heartTwo.sprite = emptyHeart;
					heartOne.sprite = halfHeart;
				}
			} else {
				heartThree.sprite = emptyHeart;
				heartTwo.sprite = emptyHeart;
				heartOne.sprite = emptyHeart;
			}
		}

		public void setNotInvincible(){
			Debug.Log("set to not invincible");
			isInvincible = false;
		}


		public void setInvincible(){
			Debug.Log("set to invincible");
			isInvincible = true;
		}			
	}
}

