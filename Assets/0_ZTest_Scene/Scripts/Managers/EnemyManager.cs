//using System;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UI;

namespace CompleteProject
{
    public class EnemyManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;       // Reference to the player's heatlh.
        public GameObject[] enemys;
        public GameObject[] enemysSpec1; // The enemy prefab to be spawned.
        public GameObject[] enemysSpec2; // The enemy prefab to be spawned.
        public GameObject[] enemysSpec3; // The enemy prefab to be spawned.
        public float spawnTime = 3f;
        public float spawnWait = 5f;// How long between each spawn.
        public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
        //public int pMaxCount = 3;
        public int pCount = 0;
        public int pCountZombie = 0;
        public EnemyManager pNextWave;
        public Transform PositionDeath;
        public bool ifStartPosPrevDeath;
        public int pHealth;
        public UnityEngine.UI.Text WaveTxt;
        public string wTxt = "";
        public bool ifSpecialWave = false;

        int countMinus = 0;
        void Start ()
        {
            if (ifSpecialWave)
            {
                Invoke("SpawnSpec", spawnWait);
            }
            else {
                InvokeRepeating("Spawn", spawnWait, spawnTime);
            }
                // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
                
            WaveTxt.text = wTxt;

            Invoke("TextWaveHide", spawnWait);
        }


        void TextWaveHide() {
            WaveTxt.text = "";

            if (ifSpecialWave)
            {
                TextCountShowSpecial();
            }
            else {
                TextCountShow();
            }
        }

        void TextCountShow() {
            WaveTxt.text = countMinus.ToString() + "/" + enemys.Length.ToString();
        }

        void TextCountShowSpecial()
        {
            WaveTxt.text = countMinus.ToString() + "/" + (enemysSpec1.Length + enemysSpec2.Length + enemysSpec3.Length).ToString();
        }

        void Spawn ()
        {         
                // If the player has no health left...
                if(playerHealth.currentHealth <= 0f)
                {
                    // ... exit the function.
                    return;
                }

                if (pCount < enemys.Length)
                {
                    // Find a random index between zero and one less than the number of spawn points.
                    int spawnPointIndex = Random.Range(0, spawnPoints.Length);
                    int spawnZombIndex = Random.Range(0, enemys.Length);

                    // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
                    enemys[pCount].GetComponent<EnemyHealth>().pManageWave = this;
                    enemys[pCount].GetComponent<EnemyHealth>().startingHealth = pHealth;
                    enemys[pCount].GetComponent<EnemyHealth>().currentHealth = pHealth;

                    if (ifStartPosPrevDeath)
                    {
                        Instantiate(enemys[pCount], PositionDeath.position, PositionDeath.rotation);
                    }
                    else
                    {
                        Instantiate(enemys[pCount], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
                    }

                    pCount++;
                    pCountZombie++;
                }   
        }


        void SpawnSpec() {
            //1
            for (int i = 0; i < enemysSpec1.Length; i++)
            {
                enemysSpec1[i].GetComponent<EnemyHealth>().pManageWave = this;
                enemysSpec1[i].GetComponent<EnemyHealth>().startingHealth = pHealth;
                enemysSpec1[i].GetComponent<EnemyHealth>().currentHealth = pHealth;

                Instantiate(enemysSpec1[i], spawnPoints[0].position + new Vector3(i + Random.Range(3f, 10f), 0f, i + Random.Range(3f, 10f)), spawnPoints[0].rotation);

                pCount++;
                pCountZombie++;
            }

            //2
            for (int j = 0; j < enemysSpec2.Length; j++)
            {
                enemysSpec2[j].GetComponent<EnemyHealth>().pManageWave = this;
                enemysSpec2[j].GetComponent<EnemyHealth>().startingHealth = pHealth;
                enemysSpec2[j].GetComponent<EnemyHealth>().currentHealth = pHealth;

                Instantiate(enemysSpec2[j], spawnPoints[1].position, spawnPoints[1].rotation);

                pCount++;
                pCountZombie++;
            }
            
            //3
            for (int k = 0; k < enemysSpec3.Length; k++)
            {
                enemysSpec3[k].GetComponent<EnemyHealth>().pManageWave = this;
                enemysSpec3[k].GetComponent<EnemyHealth>().startingHealth = pHealth;
                enemysSpec3[k].GetComponent<EnemyHealth>().currentHealth = pHealth;

                Instantiate(enemysSpec3[k], spawnPoints[2].position, spawnPoints[2].rotation);

                pCount++;
                pCountZombie++;
            }
        }

       public void CheckCount(Transform pTtransf) {

            countMinus++;
            PositionDeath = pTtransf;

            pCountZombie--;
            if (pCountZombie == 0) {
                EnableNextWave();
            }

            if (ifSpecialWave)
            {
                WaveTxt.text = countMinus.ToString() + "/" + (enemysSpec1.Length + enemysSpec2.Length + enemysSpec3.Length).ToString();
            }
            else {
                WaveTxt.text = countMinus.ToString() + "/" + enemys.Length.ToString();
            }
                
        }

        void EnableNextWave() {
            if (pNextWave)
            {       
                pNextWave.PositionDeath = PositionDeath;
                pNextWave.enabled = true;
            }

            this.enabled = false;
        }
    }
}