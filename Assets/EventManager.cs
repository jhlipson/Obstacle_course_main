using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{
    public TimeKeeper timer;
    public GameObject[] enemyPrefabs;  // Array to store the different enemy prefabs
    public Transform[] spawnPoints;    // Array to store spawn points (5 cubes)
    public GameObject[] weaponPrefabs; // Array to store the different weapon prefabs
    public Transform[] weaponSpawnPoints; // Array to store weapon spawn points
    public AudioSource[] VoiceLines;
    [SerializeField] AudioSource[] songs;
    [SerializeField] GameObject Nekros;

    public float spawnInterval = 1.0f; // Time between each enemy spawn
    public int initialEnemyCount = 1;  // Starting number of enemies to spawn
    public int enemyCount = 0;
    public int MaxEnemycount = 100;
    private bool bossSpawned = false;  // Check if the boss has spawned
    public float maxTime = 300f;
    public int maxDragons = 4;
    public int currentdragons;

    // Flags to ensure weapons and voice lines spawn/trigger only once
    private bool spawnFirstEnemy = false;
    private bool spawnSecondEnemy = false;
    private bool spawnThirdEnemy = false;
    private bool spawnFourthEnemy = false;

    private bool[] weaponSpawnedFlags;
    private bool[] voiceLinePlayedFlags;

    void Start()
    {
        timer = GetComponent<TimeKeeper>();
        weaponSpawnedFlags = new bool[weaponPrefabs.Length]; // Initialize the flags
        voiceLinePlayedFlags = new bool[VoiceLines.Length]; // Initialize the flags

        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnWeapons());
        enemyCount = initialEnemyCount;
    }

    void Update()
    {
        // Manage the spawning of enemies based on time
        if (timer.CurrentTime >= 0f && !spawnFirstEnemy && MaxEnemycount > enemyCount) // 1 minute mark
        {
            spawnFirstEnemy = true; // Start spawning the first enemy
            
            
        }

        if (timer.CurrentTime >= 60f && !spawnSecondEnemy && MaxEnemycount > enemyCount) // 2 minutes mark
        {
            spawnSecondEnemy = true; // Start spawning the second enemy
            MaxEnemycount = 25;
        }

        if (timer.CurrentTime >= 120f && !spawnThirdEnemy && MaxEnemycount > enemyCount) // 4 minutes mark
        {
            spawnThirdEnemy = true; // Start spawning the third enemy
            MaxEnemycount = 30;
            PlaySong(1);
        }

        if (timer.CurrentTime >= 180f && !spawnFourthEnemy && MaxEnemycount > enemyCount)
        {
            spawnFourthEnemy = true;
           
        }

        // When 7 minutes pass, spawn the final boss and stop spawning more enemies
        if (timer.CurrentTime >= maxTime && !bossSpawned)
        {
            SpawnBoss();
            bossSpawned = true;
            PlayVoiceLine(3);
            voiceLinePlayedFlags[3] = true;
            PlaySong(2);
        }
    }

    // Coroutine to spawn enemies periodically
    IEnumerator SpawnEnemies()
    {
        while (!bossSpawned)
        {
            // Spawn the first enemy at 1 minute
            if (spawnFirstEnemy)
            {
                if(MaxEnemycount > enemyCount)
                {
                    SpawnEnemy(0); // Spawn first enemy type
                    
                }
                
            }

            // Spawn the second enemy at 2 minutes (along with the first)
            if (spawnSecondEnemy && maxDragons > currentdragons)
            {
             if(MaxEnemycount > enemyCount)
                {
                    SpawnEnemy(1); // Spawn second enemy type
                    currentdragons++;
                   
                }   
                
            }

            // Spawn the third enemy at 4 minutes (along with the first and second)
            if (spawnThirdEnemy)
            {
                if (MaxEnemycount > enemyCount)
                {
                    SpawnEnemy(2); // Spawn third enemy type
                   
                }
               
            }

            if (spawnFourthEnemy)
            {
                if (MaxEnemycount > enemyCount)
                {
                    SpawnEnemy(3); // Spawn third enemy type
                   
                }
            }

            yield return new WaitForSeconds(spawnInterval); // Wait between spawns
        }
    }

    // Coroutine to spawn weapons at the specified times
    IEnumerator SpawnWeapons()
    {
        while (!bossSpawned)
        {
            // Spawn first weapon and play voice line at the defined time intervals
            if (timer.CurrentTime >= 30f && timer.CurrentTime < 60f && !weaponSpawnedFlags[0]) // At 2 minutes
            {
                SpawnWeapon(0); // Spawn first weapon
                PlayVoiceLine(0);  // Submachine gun voice line
                weaponSpawnedFlags[0] = true;  // Set flag so it only spawns once
                voiceLinePlayedFlags[0] = true;  // Set flag so it only plays once
            }

            if (timer.CurrentTime >= 60f && timer.CurrentTime < 120f && !weaponSpawnedFlags[1]) // At 4 minutes
            {
                SpawnWeapon(1); // Spawn bazooka
                PlayVoiceLine(1); // Bazooka voice line
                weaponSpawnedFlags[1] = true;  // Set flag so it only spawns once
                voiceLinePlayedFlags[1] = true;  // Set flag so it only plays once
            }

            if (timer.CurrentTime >= 120f && timer.CurrentTime < 180f && !weaponSpawnedFlags[2]) // At 6 minutes
            {
                SpawnWeapon(2); // Spawn shotgun
                PlayVoiceLine(2); // Shotgun voice line
                weaponSpawnedFlags[2] = true;  // Set flag so it only spawns once
                voiceLinePlayedFlags[2] = true;  // Set flag so it only plays once
            }

            // Delay for the next weapon spawn check
            yield return null;
        }
    }

    // Spawn a specific enemy at a random spawn point
    void SpawnEnemy(int enemyIndex)
    {
        int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length); // Choose random spawn point
        enemyCount++;
        Instantiate(enemyPrefabs[enemyIndex], spawnPoints[randomSpawnPointIndex].position, Quaternion.identity);
    }

    // Spawn a weapon at a random spawn point
    void SpawnWeapon(int weaponIndex)
    {
        int randomWeaponSpawnPointIndex = Random.Range(0, weaponSpawnPoints.Length); // Choose random weapon spawn point
        Instantiate(weaponPrefabs[weaponIndex], weaponSpawnPoints[randomWeaponSpawnPointIndex].position, Quaternion.identity);
    }

    // Play a specific voice line
    void PlayVoiceLine(int voiceLineIndex)
    {
        if (!voiceLinePlayedFlags[voiceLineIndex])  // Check if voice line hasn't been played
        {
            VoiceLines[voiceLineIndex].Play();
            voiceLinePlayedFlags[voiceLineIndex] = true; // Mark it as played
        }
    }

    // Spawn the final boss
    void SpawnBoss()
    {
        int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length); // Choose random spawn point
        Instantiate(Nekros, spawnPoints[randomSpawnPointIndex].position, Quaternion.identity);
        Debug.Log("Final Boss Spawned!");
    }

    public void PlaySong(int songIndex)
    {
        for (int i = 0; i < songs.Length; i++)
        {
            songs[i].Stop();
        }

        songs[songIndex].Play();
    }
}
