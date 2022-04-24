using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallbacks
{
    public class DeathListener : MonoBehaviour
    {
        public GameObject bloodParticle;
        public AudioClip deathSound;
        public AudioSource speaker;

        // Use this for initialization
        void Start()
        {
            EventSystem.Current.RegisterListener<DieEvent>(DebugListener);
            EventSystem.Current.RegisterListener<DieEvent>(SoundListener);
            EventSystem.Current.RegisterListener<DieEvent>(RemoveListener);
            EventSystem.Current.RegisterListener<DieEvent>(ParticleListener);

        }

        void DebugListener(DieEvent dieEvent)
        {
            Debug.Log("Alerted about unit death: " + dieEvent.UnitGO.name);

        }
        void SoundListener(DieEvent unitDeathInfo)
        {
            var unitPrefabClones = GameObject.FindGameObjectsWithTag("UnitPrefab");
            foreach (var clone in unitPrefabClones)
            {
                speaker.PlayOneShot(deathSound);
            }
        }
        void RemoveListener(DieEvent unitDeathInfo)
        {
            var unitPrefabClones = GameObject.FindGameObjectsWithTag("UnitPrefab");
            foreach (var clone in unitPrefabClones)
            {
                Destroy(clone);
            }
        }
        void ParticleListener(DieEvent unitDeathInfo)
        {
            var unitPrefabClones = GameObject.FindGameObjectsWithTag("UnitPrefab");
            var particalesClones = GameObject.FindGameObjectsWithTag("Particales");
            foreach (var clone in unitPrefabClones)
            {
                _ = Instantiate(bloodParticle);
            }
            foreach (var clone in particalesClones)
            {
                Destroy(clone, 1);
            }
        }

    }
}