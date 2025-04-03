using UnityEngine;
using UnityEngine.SceneManagement;
public class ProxyCam : MonoBehaviour
{
     public float speed = 0.25f;

    public Transform[] points;
    public GameObject main;
    Player _player;
    public float t = 0f;
    Vector3 proxyPos;
    Vector3 playerPos;
    int currentPointIndex;
    Vector3 currentPoint;
    Camera _cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = FindFirstObjectByType<Player>();
        _cam = GetComponentInChildren<Camera>();
        
        proxyPos = transform.position;
        playerPos = _player.transform.position;
        currentPoint = points[currentPointIndex].position;
        main.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime * speed;
        _cam.transform.LookAt(playerPos); //Instead of Vector3.zero, we want it to come into focus on the player.
        _player.enabled = false;
     

        Vector3 newPos = Vector3.Lerp(proxyPos, playerPos, t);
        transform.position = newPos;

        if (t > 1f)
        {
            currentPointIndex = (currentPointIndex + 1) % points.Length; //We want it to circle around objects that have their meshes turned off.
            proxyPos = transform.position;
            currentPoint = points[currentPointIndex].position;
        }

        if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene("Main scene"); //Scene management because this is only active when the player is not.
        }
    }
}


