using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;
    
    [SerializeField] private Transform[] SpawnAreas = new Transform[4];
    [SerializeField] private List<GameObject> PoolEnnemies;
    
    private int _RandomIndex;
    private GameObject CurrEnnmy;
    public GameObject Menu;
    
    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DispawnEnnemy(GameObject EnnemyToDispawn)
    {
        EnnemyToDispawn.SetActive(false);
        PoolEnnemies.Append(EnnemyToDispawn);
    }
    
    IEnumerator SpawnEnemy()
    {
        for (;;)
        {
            CurrEnnmy = PoolEnnemies[0];
            PoolEnnemies.Remove(CurrEnnmy);
            CurrEnnmy.SetActive(true);
            
            
            _RandomIndex = Random.Range(0, SpawnAreas.Length);

            CurrEnnmy.transform.position = SpawnAreas[_RandomIndex].position;
            
            yield return new WaitForSeconds(4);
        }
    }
    
    public void PlayButton()
    {
        Menu.SetActive(false);
        StartCoroutine(SpawnEnemy());

    }

    public void QuitButton()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    
}
