using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallbacks
{
    public class Health : MonoBehaviour
    {
        private int health = 100;
        [SerializeField]private float deathCountDown = 5f;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (health <= 0)
            {
                Die();
            }
        }

        void Die()
        {
            // I am dying for some reason.
            deathCountDown -= 1 * Time.deltaTime;
            if (deathCountDown <= 0)
            {
                DieEvent udei = new DieEvent();
                udei.EventDescription = "Unit " + gameObject.name + " has died.";
                udei.UnitGO = gameObject;
                EventSystem.Current.FireEvent(udei);

            }
        }
        public void setHealth(int amount)
        {
            health = amount;
        }
    }
}