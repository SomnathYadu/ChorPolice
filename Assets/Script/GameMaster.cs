using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;
    public Transform chorPrefab;
    public Transform player;
    public GameObject gameOverPanel;

    Transform camera;

    float timeToSpawnChor = 0;

    bool chorJindaHai = false;
    void Start()
    {
        camera = Camera.main.transform;
        gm = this;
    }

    void Update()
    {
        if (!chorJindaHai && timeToSpawnChor < Time.time)
        {
            SpawnChor();
        }
        if(player == null)
        {
            gameOverPanel.SetActive(true);
        }
    }

    void SpawnChor()
    {
        Vector3 newPos = new Vector3(camera.position.x + 50, 0, 0);
        chorJindaHai = true;
        Instantiate(chorPrefab, newPos, Quaternion.identity);
    }

    public static void KillEnemy(GameObject chor)
    {
        gm.timeToSpawnChor = Time.time + 3f;
        Destroy(chor);
        gm.chorJindaHai = false;
    }
}
