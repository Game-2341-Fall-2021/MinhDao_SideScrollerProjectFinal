using System;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;
using System.Collections.Generic;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Represebts the current vital statistics of some game entity.
    /// </summary>
    public class Health : MonoBehaviour
    {
        /// <summary>
        /// The maximum hit points for the entity.
        /// </summary>
        public int maxHP, initialhp;
        public GameObject healthcanvas, HealthSprite;
        List<GameObject> lifetotalimages;


        /// <summary>
        /// Indicates if the entity should be considered 'alive'.
        /// </summary>
        public bool IsAlive => currentHP > 0;

        public int currentHP;

        /// <summary>
        /// Increment the HP of the entity.
        /// </summary>
        public void Increment()
        {

            currentHP = Mathf.Clamp(currentHP + 1, 0, maxHP);
            GameObject newitem = Instantiate(HealthSprite, healthcanvas.transform);
            lifetotalimages.Add(newitem);

        }
        public void setinitiallife()
        {
            if (lifetotalimages != null)
            {
                foreach (GameObject healthobjects in lifetotalimages)
                {
                    GameObject.Destroy(healthobjects);
                }
                lifetotalimages = null;
            }
            lifetotalimages = new List<GameObject>();
            for (int i = 0; i < initialhp; i++)
            {
                GameObject newitem = Instantiate(HealthSprite, healthcanvas.transform);
                lifetotalimages.Add(newitem);
            }
            currentHP = initialhp;
        }


        /// <summary>
        /// Decrement the HP of the entity. Will trigger a HealthIsZero event when
        /// current HP reaches 0.
        /// </summary>
        public void Decrement()
        {
            currentHP = Mathf.Clamp(currentHP - 1, 0, maxHP);
            if (lifetotalimages.Count > 0)
            {
                GameObject objecttodestroy = lifetotalimages[lifetotalimages.Count - 1];
                lifetotalimages.RemoveAt(lifetotalimages.Count - 1);
                GameObject.Destroy(objecttodestroy);
            }

            if (currentHP == 0)
            {
                  //var ev = Schedule<HealthIsZero>();
                  //ev.health = this;
                 //ev.Execute();

                 //setinitiallife();
            }
            
        }

        /// <summary>
        /// Decrement the HP of the entitiy until HP reaches 0.
        /// </summary>
        public void Die()
        {
            while (currentHP > 0) Decrement();
        }

        void Awake()
        {
            // currentHP = maxHP;
            setinitiallife();


        }
    }
}