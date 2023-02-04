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
        public Tilemap layer1;
        public Tilemap layer2;
        public Tilemap layer3;
        void Start()
        {
            rootController = GetComponentInParent<RootController>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.GetType() == typeof(TilemapCollider2D))
            {
                
            }
            else
            {
                rootController.CollidedWith(collision);
            }
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public bool CanMove(Vector3 position)
        {
            bool canMove = true;
            CheckTerrain(position);
            if (currentAllowedStage < (int)currentTerrain)
                canMove = false;


            return canMove;
        }

        private void CheckTerrain(Vector3 position)
        {
            if (layer1.HasTile(layer1.WorldToCell(position)))
                currentTerrain = Terrain.Layer1;
            if (layer2.HasTile(layer2.WorldToCell(position)))
                currentTerrain = Terrain.Layer2;
            if (layer3.HasTile(layer3.WorldToCell(position)))
                currentTerrain = Terrain.Layer3;
        }
    }

}
