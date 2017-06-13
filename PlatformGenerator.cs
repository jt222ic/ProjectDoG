using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour
{

    // Use this for initialization


    // public GameObject ThePlatForm;
    public Transform generationPoint;
    public float distanceBetween;
    private float[] PlatFormWidth;         // platformwidth

    // private GameObject newPlatform;
    public float distanceBetweenMin;         // distance between object 
    public float distanceBetweenMax;

    // public GameObject[] thePlatforms;
    private int PlatFormSelector;
    public ObjectPooling[] theObjectPools;
    private float minHeight;
    private float maxHeight;
    public Transform maxHeightPoint;
    public float maxHeightChange;
    private float heightChange;


    public CoinGenerator coingenerator;

    public int ForEvery;
    public int MagnetEvery;
    public float WingEvery;
    public int ForRewinery = 3000;
    float WingNewPosition;


    void Start()
    {
        ForEvery = 650;
        PlatFormWidth = new float[theObjectPools.Length];


        for (int i = 0; i < theObjectPools.Length; i++)
        {
            PlatFormWidth[i] = theObjectPools[i].PooledObject.GetComponent<BoxCollider2D>().size.x;    // get the variable gameobject from refer to create in pobjectpooling class
        }
        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;                /* PlatFormWidth = ThePlatForm.GetComponent<BoxCollider2D>().size.x;  */    // get of the platform of the Gameobject   , platformwidth become the float width out of gameobject

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)                  // this gameobject transform position compare to the generation gameobject position
        {
            //distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            if (ScoreManager.scoreCount < 1000)
            {
                PlatFormSelector = Random.Range(0, 3);

            }
            else if (ScoreManager.scoreCount > 1000 && ScoreManager.scoreCount < 4500)
            {
                PlatFormSelector = Random.Range(0, 4);
                ///theObjectPools.Length
            }
            else if (ScoreManager.scoreCount > 4500 && ScoreManager.scoreCount < 5000)
            {
                PlatFormSelector = Random.Range(0, 5);
            }
            else if (ScoreManager.scoreCount > 5000 && ScoreManager.scoreCount < 7000)
            {
                PlatFormSelector = Random.Range(0, 6);
            }
            else if (ScoreManager.scoreCount >= 7000)
            {
                PlatFormSelector = Random.Range(0, theObjectPools.Length);
            }

            //else
            //{
            //    Debug.Log("DIFFICULTY SPIKE");                                  // it works will implement later
            //    PlatFormSelector = Random.Range(0, theObjectPools.Length);
            //}
            //heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);
            //else if (ScoreManager.scoreCount > 300)
            //{
            //    PlatFormSelector = Random.Range(0, 4);

            //    Debug.Log("difficulty spiike");

            //    //difficultyPlat.transform.position = transform.position;
            //    //difficultyPlat.transform.position = transform.position;
            //    //difficultyPlat.SetActive(true);
            //}

            transform.position = new Vector3(transform.position.x + (PlatFormWidth[PlatFormSelector]) / 2 + distanceBetween, transform.position.y, transform.position.z);

            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }                                                      // adding in width and the distance in between and not overlapping

            /// random platform of the amount in the platform arrays.
                                       // Instantiate(thePlatforms[PlatFormSelector], transform.position,transform.rotation);

            GameObject newPlatform = theObjectPools[PlatFormSelector].getPooledObject();                    // call the pooling script with the getPooled to set them to active from the transform.position 
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            //Debug.Log(ScoreManager.scoreCount);


            //GameObject difficultyPlat = theObjectPools[4].getPooledObject();
            //difficultyPlat.transform.position = new Vector3(transform.position.x + (PlatFormWidth[PlatFormSelector]) / 2 + distanceBetween, transform.position.y, transform.position.z);
            //difficultyPlat.transform.rotation = newPlatform.transform.rotation;
            //difficultyPlat.SetActive(false);

            //if (ScoreManager.scoreCount> 300)
            //{
            //    PlatFormSelector = Random.Range(0, 4);

            //    //difficultyPlat.transform.position = transform.position;
            //    //difficultyPlat.transform.position = transform.position;
            //    //difficultyPlat.SetActive(true);
            //}

            transform.position = new Vector3(transform.position.x + PlatFormWidth[PlatFormSelector] + distanceBetween, transform.position.y, transform.position.z);

            coingenerator.spawnCoins(new Vector3(transform.position.x + 10, transform.position.y + 1.8f, transform.position.z));


            if(ScoreManager.scoreCount > ForEvery)                        // spawn power ups for every 650 score rate
            {
                ForEvery += 800;
                coingenerator.spawnPowerUp(new Vector3(transform.position.x + 10, transform.position.y + 1.8f, transform.position.z));
            }
            if(ScoreManager.scoreCount > MagnetEvery)
            {
                //Debug.Log("MAGNET SPAWN");
                MagnetEvery += Random.Range(100,1500);
                coingenerator.spawnMagnetUp(new Vector3(transform.position.x + 10, transform.position.y + 2f, transform.position.z));
            }
            if (ScoreManager.scoreCount >WingEvery)
            {
                WingNewPosition = Random.Range(8f, 12f);
                    if (Random.value >= 0.1)         // 90% of getting the Wing for next above 500 score points
                {

                    WingEvery += 300;
                    coingenerator.spawnWingsUp(new Vector3(transform.position.x + WingNewPosition, transform.position.y - 1.5f, 2.16f));
                }
            }

            //if (ScoreManager.scoreCount > ForRewinery)
            //{

            //    ForRewinery += 200;
            //    coingenerator.spawnRewindUp(new Vector3(transform.position.x -5f, transform.position.y + 3f, 2.16f));
            //}

        }

    }
}
