using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private List<Vector3> listPosRectFull;
    [SerializeField]
    private List<Vector3> listPosRhombusFull;
    [SerializeField]
    private List<Vector3> listPosTriangle;
    [SerializeField]
    private List<Vector3> listPosRect;
    public List<GameObject> listEnemy;
    public GameObject enemyPf;
    private bulletPool bulletPool;
    private GameObject bullet;
    private GameObject enemy;
    public GameObject player;
    public GameObject overlay;
    public TMP_Text score;
    public int point = 0;
    public int enemyAmount = 16;
    public static gameController ins;
    void Start()
    {
        if (ins == null)
        {
            ins = this;
        }
        bulletPool = FindObjectOfType<bulletPool>();
        for (var i = 0; i < 16; i++)
        {
            enemy = Instantiate(enemyPf, new Vector3(-5, 3, 0), Quaternion.identity);
            listEnemy.Add(enemy);
        }
        InvokeRepeating("invokeEnemyFly", 0f, 20f);
        InvokeRepeating("spawnBullet",5f,0.1f);
    }
    void flyToFullRect()
    {
        for (int i = 0; i < listPosRectFull.Count; i++)
        {
            LeanTween.move(listEnemy[i], listPosRectFull[i], 2f);
        }
    }
    void flyToFullRhombus()
    {
        for (int i = 0; i < listPosRhombusFull.Count; i++)
        {
            LeanTween.move(listEnemy[i], listPosRhombusFull[i], 2f);
        }
    }
    void flyToTriangle()
    {
        for (int i = 0; i < listPosTriangle.Count; i++)
        {
            LeanTween.move(listEnemy[i], listPosTriangle[i], 2f);
        }
    }
    void flyToRect()
    {
        for (int i = 0; i < listPosRect.Count; i++)
        {
            LeanTween.move(listEnemy[i], listPosRect[i], 2f);
        }
    }
    void invokeEnemyFly()
    {
        flyToFullRect();
        Invoke("flyToFullRhombus", 5f);
        Invoke("flyToTriangle", 10f);
        Invoke("flyToRect", 15f);
    }
    void spawnBullet()
    {
        bullet = bulletPool.instance.getBullet();
        if(bullet != null)
        {
            bullet.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0);
            bullet.SetActive(true);
        }
    }

    public void Replay()
    {
        Debug.Log("Lam lai");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
