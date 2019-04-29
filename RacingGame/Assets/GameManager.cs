using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Utility;

public class GameManager : MonoBehaviour
{
    public string sceneName = "SampleScene";
    private AsyncOperation async;
    bool done = false;
    public GameObject hider;

    private void Awake()
    {
        Time.timeScale = 0;
        hider.SetActive(true);
    }


    // Start is called before the first frame update
    void Start()
    {
        async = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        if (async.isDone & !done)
        {
            done = true;
            Time.timeScale = 1;
            hider.SetActive(false);
            WaypointCircuit circuit = FindObjectOfType<WaypointCircuit>();
            WaypointProgressTracker[] aiCars = FindObjectsOfType<WaypointProgressTracker>();
            foreach (WaypointProgressTracker car in aiCars)
            {
                car.circuit = circuit;
            }
            
        }
    }
}
