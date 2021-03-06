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
		private float HealBufferStart; //When healing begins  (Doing this so Update only heals once when a button is pressed once)
		private float HealBufferStop; //When healing ends

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

		void Start() 
		{
			isInvincible = false;
			MaxHP = HP;
		}


		//If wanting to damage input a negative number
		public void takeHealth(int change){

			//Checks if in invincible frames
			if (isInvincible)
				return;
			else {
				isInvincible = true;
			}

			//If not invincible
			Debug.Log("HP:"+HP+"-"+change);
			HP -=change;
			WhenIStarted = Time.time;
			WhenIStops = WhenIStarted + numIFrames;
			setInvincible();


		}


		//Healing
		public void gainHealth(int change){
			Debug.Log("HP:"+HP+"+"+change);
			if (HP + change > MaxHP)
				HP = MaxHP;
			else
				HP += change;

			HealBufferStart = Time.time;
			HealBufferStop = HealBufferStart + numIFrames;
		}


		//Checks if player is alive
		public bool isAlive(){
			return HP > 0;
		}


		void Update(){

			if (isInvincible) {
				//Checks for if Invincibilty should run out
				if (WhenIStops < Time.time) {
					setNotInvincible ();
				}
			}

			if (Input.GetButton("Fire1"))
				takeHealth(damage);

			if (Input.GetButton ("Fire2")) {
				if (HealBufferStop < Time.time)
					gainHealth (damage);
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
				Debug.Log ("Blegh");
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

