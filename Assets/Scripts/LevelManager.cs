using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager Instance { get; private set; }
    public int level;

    [SerializeField]
    List<Wave> waves = new List<Wave>();

    private Queue<Wave> waveQueue = new Queue<Wave>();


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        foreach (var wave in waves)
        {
            waveQueue.Enqueue(wave);
        }

        // Start the first wave
        StartNextWave();
    }

    public void StartNextWave()
    {
        if (waveQueue.Count > 0)
        {
            Wave nextWave = waveQueue.Dequeue();

            Instantiate(nextWave, Vector2.zero, Quaternion.identity);

        }
        else
        {
            Debug.Log("All waves completed!");
        }
    }




}
