using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KingdomGates
{
    public class CharHandler : MonoBehaviour
    {
        public bool alive;
        public int maxHealth = 100;
        public float curHealth;
        public GUIStyle healthBar;
        public bool takeDMG;
        //public int damage = 25;
        public int playerDMG = 1;



        private void Start()
        {
            // Health starts at max health
            curHealth = maxHealth;
            // Player starts alive
            alive = true;
        }

        private void LateUpdate()
        {
            // When current health is greater than or equal to max health
            if (curHealth >= maxHealth)
            {
                // Make current health equal max health
                curHealth = maxHealth;
            }
            // If current health is less than or equal to 0 and the player is alive
            if (curHealth <= 0 && alive)
            {
                // Make the player dead
                alive = false;
                Dead();
            }
            //if (curHealth <= 0)
            //{
            //    alive = false;
            //}
        }
        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other.gameObject.name == "Enemy")
        //    {
        //        takeDMG = true;
        //        if (takeDMG == true)
        //        {
        //            curHealth -= damage;
        //        }
        //    }
        //}
        public void TakeDamage(int npcDmg)
        {
            curHealth -= npcDmg;
        }
        // When the player is dead
        public void Dead()
        {
            // Deactivate the player
            gameObject.SetActive(false);
        }
        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Enemy")
            {

                NPCHandler npcHealth = other.GetComponent<NPCHandler>();
                if (npcHealth != null)
                {
                    npcHealth.TakeDMG(playerDMG);
                    Debug.Log("Enemy takes damage and doesn't know how to write debugs");
                    GameObject.Destroy(other.gameObject);
                }

                //DealDamage(npcDmg);
            }
        }

    }
}
