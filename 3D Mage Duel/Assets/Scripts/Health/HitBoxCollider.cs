using UnityEngine;
using UnityEngine.SceneManagement;

public class HitBoxCollider : MonoBehaviour
{
    private PlayerHealthManager healthManager;

    private void Start()
    {
        healthManager = FindObjectOfType<PlayerHealthManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            healthManager.DecreaseHearts();
        }
    }
}

public class PlayerHealthManager : MonoBehaviour
{
    public int maxHearts = 3;
    private int currentHearts;
    public GameObject gameOverScreen;
    public GameObject victoryScreen; 

    private void Start()
    {
        currentHearts = maxHearts;
    }

    public void DecreaseHearts()
    {
        currentHearts--;

        if (currentHearts <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        gameOverScreen.SetActive(true);

      
      
    }

   
}