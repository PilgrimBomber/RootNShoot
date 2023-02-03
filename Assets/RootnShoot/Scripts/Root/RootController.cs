using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.RootnShoot.Scripts.Root
{
    public class RootController : MonoBehaviour
    {
        
        private TreeNode rootNode;
        private TreeNode currentNode;

        [SerializeField] private GameObject circlePrefab;
        //Shot
        public float shotSpeed;
        [Range(0.01f, 0.2f)] public float fallOff = 0.05f;
        private Vector2 currentShotPos;
        private Vector2 shotDirection;
        private bool isShooting;
        //line
        public GameObject LinePrefab;
        private LineRenderer currentLine;
        [SerializeField] private float rootThickness = 1;
        [SerializeField] private float squiggleProbability;
        [SerializeField] private float squiggleAngle = 30;
        //camera
        [SerializeField] private Transform followTarget;
        void Start()
        {
            rootNode = new TreeNode(Vector3.zero, null);
            currentNode = rootNode;
        }

        private void Update()
        {
            if(isShooting) 
                HandleShot();
            
        }

        private void HandleShot()
        {
            float threshhold = 0.1f;
            if (shotDirection.sqrMagnitude < threshhold)
            {
                StopShot();
            }
            currentShotPos += shotDirection * Time.deltaTime * shotSpeed;
            shotDirection *= 1 - fallOff;
            currentLine.SetPosition(currentLine.positionCount - 1, currentShotPos);
            followTarget.position = currentShotPos;
            //directionChange
            if(Random.Range(0f,1f)<squiggleProbability* Time.deltaTime)
            {
                currentLine.positionCount++;
                currentLine.SetPosition(currentLine.positionCount-1, currentShotPos);
                shotDirection = shotDirection.Rotate(Random.Range(-squiggleAngle, squiggleAngle));
            }
        }

        private void StopShot()
        {
            isShooting = false;
            currentNode = currentNode.AddChild(currentShotPos, currentLine);
        }

        public void ShootToTarget(Vector3 direction)
        {
            if (isShooting) 
                return;
            
            Shoot(direction);
        }

        private void Shoot(Vector2 direction)
        {
            currentShotPos = currentNode.position;
            isShooting = true;
            shotDirection = direction;
            currentLine = Instantiate(LinePrefab, this.transform).GetComponent<LineRenderer>();
            currentLine.SetPositions(new Vector3[]{ currentShotPos,currentShotPos});
            
            currentLine.startWidth = rootThickness;
            currentLine.endWidth = 0;
            if(currentNode.line!=null)
                currentNode.line.endWidth = rootThickness;
            if (currentNode.children.Count == 0)
            {
                GameObject circle = Instantiate(circlePrefab, currentLine.transform);
                circle.transform.position = currentNode.position;
                currentNode.circle = circle;
            }
        }

        public void Navigate(Direction direction)
        {
            if (isShooting) 
                return;
            switch (direction)
            {
                case Direction.Up:
                    if (currentNode.parent != null)
                        currentNode = currentNode.parent;
                    break;
                case Direction.Down:
                    if (currentNode.children.Count>0)
                        currentNode = currentNode.children[0];
                    break;
                case Direction.Left:
                    currentNode = currentNode.Previous;
                    break;
                case Direction.Right:
                    currentNode = currentNode.Next;
                    break;
            }
            followTarget.position = currentNode.position;
        }

        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
    }

    public static class Vector2Extension
    {
        public static Vector2 Rotate(this Vector2 v, float degrees)
        {
            return Quaternion.Euler(0, 0, degrees) * v;
        }
    }
}

