using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.RootnShoot.Scripts.Root
{
    public class MovementChecker : MonoBehaviour
    {
        private RootController rootController;
        
        public enum Terrain
        {
            Layer1,
            Layer2,
            Layer3
        }

        public int currentAllowedStage = 0;

        public Terrain currentTerrain;
        void Start()
        {
            rootController = GetComponentInParent<RootController>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetType() == typeof(TilemapCollider2D))
            {
                if (Enum.TryParse<Terrain>(collision.gameObject.name, out currentTerrain))
                {
                    if (currentAllowedStage < (int)currentTerrain)
                    {
                        //New Zone not unlocked
                        rootController.CollidedWith(collision);
                    }
                }
            }
            else
            {
                rootController.CollidedWith(collision);
            }
        }

        //private void OnCollisionEnter2D(Collision2D collision)
        //{
        //    if (collision.collider.GetType() == typeof(TilemapCollider2D))
        //    {
        //        if(Enum.TryParse<Terrain>(collision.collider.gameObject.name, out currentTerrain))
        //        {
        //            if (currentAllowedStage < (int)currentTerrain)
        //            {
        //                //New Zone not unlocked
        //                rootController.CollidedWith(collision);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        rootController.CollidedWith(collision);
        //    }
        //}

        // Update is called once per frame
        void Update()
        {
            
        }

        public bool CanMove(Vector3 position)
        {
            bool canMove = true;
            if (currentAllowedStage < (int)currentTerrain)
                canMove = false;


            return canMove;
        }

    }

}
