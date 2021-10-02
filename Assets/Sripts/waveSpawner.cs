using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class waveSpawner : MonoBehaviour
{
   
    public Transform spawnpoint;
    public Transform enemyPrefab;
    public float timebetweenWaves = 10f;

    private float countdown = 2f;
    private int waveIndex=0;
    private int enemiesINwave=1;
    private int maxWaves = 5;

    public Text waveCoutndownText;
    public Text waveNumberText;

     void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(Spawnwave());
            countdown = timebetweenWaves;
        }
        if (waveIndex>=maxWaves)
        {
            countdown = 0;
        }

        countdown -= Time.deltaTime;

        waveCoutndownText.text ="Incoming Wave in : "+Mathf.Round (countdown).ToString();
        waveNumberText.text = "Wave " + waveIndex.ToString() + " / " + maxWaves.ToString();

    }

    IEnumerator Spawnwave()   //IEnumerator allows us to pause the function
    {
        if (waveIndex<maxWaves)
        {
            waveIndex++;
            for (int i = 0; i < (enemiesINwave * waveIndex); i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(1f);
            }
            
        }
        
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab,spawnpoint.position,spawnpoint.rotation);
        return;
    }

}
