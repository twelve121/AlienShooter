using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            //int index = gameController.ins.listEnemy.IndexOf(gameObject);
            gameController.ins.point = gameController.ins.point + 1;
            //Debug.Log("Score--------" + index);
            gameController.ins.score.text = "Score: " + (gameController.ins.point).ToString();
            Destroy(gameObject);

            if(gameController.ins.point == 16)
            {
                Time.timeScale = 0;
                Time.fixedDeltaTime = 0;
                gameController.ins.overlay.SetActive(true);
            }
        }
    }
}
