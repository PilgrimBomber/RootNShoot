using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using Random = UnityEngine.Random;

namespace Assets.RootnShoot.Scripts.Root
{
    public class RootController : MonoBehaviour
    {
        
        private TreeNode rootNode;
        private TreeNode currentNode;

        [SerializeField] private GameObject circlePrefab;
        [SerializeField] private GameObject LinePrefab;

        [Header("Audio")]
        [SerializeField] private List<AudioClip> shotClips;
        [SerializeField] private AudioClip juiceGain;
        [SerializeField] private AudioClip upgradeGain;
        [SerializeField] private AudioClip rootDeath;
        private AudioSource audioSource;

        [Header("Shooting")]
        //Shot
        public float shotSpeed;
        [Range(0.001f, 0.2f)] public float fallOff = 0.05f;
        private Vector2 currentShotPos;
        private Vector2 shotDirection;
        private bool isShooting;
        private bool collided;

        private List<LineRenderer> allLines;
        private List<GameObject> allCircles;
        private LineRenderer currentLine;
        [SerializeField] private float rootThickness = 1;
        //[SerializeField] private float squiggleProbability;
        //[SerializeField] private float squiggleAngle = 30;
        [Header("Camera")]
            //camera
        [SerializeField] private Transform followTarget;
        [SerializeField] private CinemachineVirtualCamera virtualCamera;
        [SerializeField] private Color deadColor;
        [SerializeField] private Transform startPos;
        [Header("Juice")]
        //Juice
        private float maxJuice=200;
        private float currentJuice = 100;
        [SerializeField] private float MinJuiceCost = 20;
        [SerializeField] private float MaxShotStrength;
        public SpriteRenderer juiceBar;

        
        private UpgradeManager upgradeManager;
        void Start()
        {
            upgradeManager = GetComponent<UpgradeManager>();
            audioSource = GetComponent<AudioSource>();
            allLines = new List<LineRenderer>();
            allCircles = new List<GameObject>();
        }

        public void EndLevel()
        {
            while (allCircles.Count > 0)
            {
                Destroy(allCircles[0]);
                allCircles.RemoveAt(0);
            }
            while (allLines.Count > 0)
            {
                Destroy(allLines[0].gameObject);
                allLines.RemoveAt(0);
            }
            rootNode = null;
            followTarget.gameObject.SetActive(false);
            GameManager.Instance.EndLevel();
        }

        public void StartLevel()
        {
            allCircles = new List<GameObject>();
            allLines = new List<LineRenderer>();
            
            //pos
            rootNode = new TreeNode(startPos.position, null);
            currentNode = rootNode;
            followTarget.gameObject.SetActive(true);
            followTarget.position = startPos.position;
            //cAMERA
            virtualCamera.Follow = followTarget;
            virtualCamera.m_Lens.OrthographicSize = upgradeManager.OrthoSize;
            //ScaleJuiceBar
            Vector3 relativeBigPos = new Vector3(14, .21f, 10);
            Vector3 bigScale = new Vector3(3.54f, 4.09f, 1);
            juiceBar.transform.parent.localPosition = (upgradeManager.OrthoSize / 8f) * relativeBigPos * (16f/18f); 
            juiceBar.transform.parent.localScale = (upgradeManager.OrthoSize / 8f) * bigScale; 
            //lightSize
            followTarget.GetComponent<Light2D>().pointLightOuterRadius = upgradeManager.LightRange;

            currentJuice = maxJuice / 2;
            juiceBar.material.SetFloat("JuiceAmount", currentJuice);
        }

        private void Update()
        {
            if(isShooting) 
                HandleShot();
            
        }

        public void AddJuice(float amount)
        {
            currentJuice += amount;
            juiceBar.material.SetFloat("JuiceAmount", currentJuice);
            audioSource.PlayOneShot(juiceGain);
        }

        public void AddUpgradePoints(float points)
        {
            upgradeManager.UpgradePoints += points;
            audioSource.PlayOneShot(upgradeGain);
        }

        private void HandleShot()
        {
            float threshhold = 0.1f;
            if (shotDirection.sqrMagnitude < threshhold)
            {
                StopShot();
            }
            currentShotPos += shotDirection * Time.deltaTime * upgradeManager.Speed;
            shotDirection *= 1 - fallOff;
            currentLine.SetPosition(currentLine.positionCount - 1, currentShotPos);
            followTarget.position = currentShotPos;
            //directionChange
            if(Random.Range(0f,1f)<upgradeManager.SpreadProb* Time.deltaTime)
            {
                currentLine.positionCount++;
                currentLine.SetPosition(currentLine.positionCount-1, currentShotPos);
                shotDirection = shotDirection.Rotate(Random.Range(-upgradeManager.SpreadAngle, upgradeManager.SpreadAngle));
            }
        }

        public void KillCurrentShot()
        {
            isShooting = false;
            followTarget.position = currentNode.position;
            currentLine.endColor = deadColor;
            audioSource.PlayOneShot(rootDeath);
            CheckIfDefeat();
        }

        public void Freeze()
        {
            isShooting = false;
        }

        private void StopShot()
        {
            isShooting = false;
            currentNode = currentNode.AddChild(currentShotPos, currentLine);
            CheckIfDefeat();
        }

        private void CheckIfDefeat()
        {
            if(currentJuice<=0)
            {
                EndLevel();
            }
        }

        public void ShootToTarget(Vector3 direction)
        {
            if (isShooting) 
                return;
            
            Shoot(direction);
        }

        private void Shoot(Vector2 direction)
        {
            float juiceCost = CalculateJuiceCost(direction);
            if(juiceCost>currentJuice)
            {
                //reduce Strength
            }
            currentJuice -= juiceCost;
            juiceBar.material.SetFloat("JuiceAmount", currentJuice);
            juiceBar.material.SetFloat("MaxJuice", maxJuice);
            
            currentShotPos = currentNode.position;
            isShooting = true;
            shotDirection = direction;
            currentLine = Instantiate(LinePrefab, this.transform).GetComponent<LineRenderer>();
            allLines.Add(currentLine);
            currentLine.SetPositions(new Vector3[]{ currentShotPos,currentShotPos});
            
            currentLine.startWidth = rootThickness;
            currentLine.endWidth = 0;
            if(currentNode.line!=null)
                currentNode.line.endWidth = rootThickness;
            if (currentNode.children.Count == 0)
            {
                GameObject circle = Instantiate(circlePrefab, currentLine.transform);
                allCircles.Add(circle);
                circle.transform.position = currentNode.position;
                currentNode.circle = circle;
            }
            if(shotClips.Count>0)
                audioSource.PlayOneShot(shotClips[Random.Range(0, shotClips.Count - 1)]);

        }

        public float CalculateJuiceCost(Vector2 direction)
        {
            if (direction.magnitude > MaxShotStrength)
            {
                direction *= MaxShotStrength / direction.magnitude;
            }
            return (MinJuiceCost + direction.magnitude) * 0.6f * upgradeManager.JuiceMultiplier;
        }

        public void CollidedWith(Collider2D collision)
        {
            collided = true;
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

