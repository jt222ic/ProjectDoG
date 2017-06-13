using UnityEngine;
using System.Collections;

public class CoinGenerator : MonoBehaviour {


    public ObjectPooling coinPool;
    public ObjectPooling PowerUpPool;
    public ObjectPooling MagnetPool;
    public ObjectPooling WingsPool;
    //public ObjectPooling ReWindPool;
    
    public float distanceBetweenCoins;
    // Use this for initialization
    float value;


    

    public void spawnCoins(Vector3 startposition)
    {


        value = Random.Range(22, 25);
        GameObject coin1 = coinPool.getPooledObject();     // 1 coin is generated
        coin1.transform.position = startposition;
        coin1.SetActive(true);
        GameObject coin2 = coinPool.getPooledObject();     // 2nd coin is generated
        coin2.transform.position = new Vector3(startposition.x - distanceBetweenCoins, startposition.y+ 1f,startposition.z);    // minus the distance because we want the newly placed position 
        coin2.SetActive(true);

        GameObject coin3 = coinPool.getPooledObject();     // 3 coin is generated
        coin3.transform.position = new Vector3(coin2.transform.position.x - distanceBetweenCoins, startposition.y, startposition.z);    // minus the distance because we want the newly placed position 
        coin3.SetActive(true);

        GameObject coin4 = coinPool.getPooledObject();     // 1 coin is generated
        coin4.transform.position = new Vector3(startposition.x  + distanceBetweenCoins, startposition.y - 1f, startposition.z);    // minus the distance because we want the newly placed position 
        coin4.SetActive(true);

        GameObject coin5 = coinPool.getPooledObject();     // 1 coin is generated
        coin5.transform.position = new Vector3(startposition.x - value -  distanceBetweenCoins, startposition.y - 1f, startposition.z);    // minus the distance because we want the newly placed position 
        coin5.SetActive(true);
    }
    public void spawnPowerUp(Vector3 startposition)
    {
        GameObject Powerup = PowerUpPool.getPooledObject();
        Powerup.transform.position = new Vector3(startposition.x + distanceBetweenCoins +4f, startposition.y - 1.5f, startposition.z);    // minus the distance because we want the newly placed position 
        Powerup.SetActive(true);
    }
    public void spawnMagnetUp(Vector3 startposition)
    {
        GameObject Magnet = MagnetPool.getPooledObject();
        Magnet.transform.position = new Vector3(startposition.x + distanceBetweenCoins + 4f, startposition.y - 1.5f, startposition.z);    // minus the distance because we want the newly placed position 
        Magnet.SetActive(true);

    }
    public void spawnWingsUp(Vector3 startposition)
    {
        GameObject Wing = WingsPool.getPooledObject();
        Wing.transform.position = new Vector3(startposition.x + distanceBetweenCoins, startposition.y - 1.5f, startposition.z);    // minus the distance because we want the newly placed position 
        Wing.SetActive(true);
    }


    //public void spawnRewindUp(Vector3 startposition)
    //{
    //    GameObject Rewind = ReWindPool.getPooledObject();
    //    Rewind.transform.position = new Vector3(startposition.x + distanceBetweenCoins, startposition.y - 1.5f, startposition.z);    // minus the distance because we want the newly placed position 
    //    Rewind.SetActive(true);
    //}

}
