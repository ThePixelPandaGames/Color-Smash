using UnityEngine;

public class Collision : MonoBehaviour
{



    private void Start()
    {
    }

    private bool CompareColor(Color me, Color other)
    {
        return me.r == other.r && me.g == other.g && me.b == other.b && me.a == other.a;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy")) { 
            GameObject enemy = collision.gameObject;
            
            Color enemyColor = enemy.GetComponent<SpriteRenderer>().color;

            Color thisColor = GetComponent<SpriteRenderer>().color;

            
            if(CompareColor(thisColor, enemyColor) || GameManager.Instance.isRainbowEffectActivated) {
                Score(enemy);
            } else
            {
                GameOver();
            }
        }
    }

    private void Score(GameObject toDestroy)
    {
        // calla score method in game Manager to handle UI, maybe a UI handler or so
        GameManager.Instance.IncreaseScoreByOne();
        Destroy(toDestroy);
    }

    private void GameOver()
    {
        // call game over in Game Manager or so
        //Debug.Log("Game Over");

        GameManager.Instance.isGameOver = true;
    }
}
