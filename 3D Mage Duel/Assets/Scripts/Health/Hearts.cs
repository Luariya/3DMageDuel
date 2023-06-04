using UnityEngine;

public class Hearts : MonoBehaviour
{
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;

    public GameObject gameOver;

    int health;
    int health2;

    private void Start()
    {
        health = 3;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            health--;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            health++;
        }


        switch (health)
        {
            case 0:
                {
                    Heart1.gameObject.SetActive(false);
                    Heart2.gameObject.SetActive(false);
                    Heart3.gameObject.SetActive(false);
                    gameOver.SetActive(true);
                    break;
                }
            case 1:
                {
                    Heart1.gameObject.SetActive(true);
                    Heart2.gameObject.SetActive(false);
                    Heart3.gameObject.SetActive(false);
                    break;

                }
            case 2:
                {
                    Heart1.gameObject.SetActive(true);
                    Heart2.gameObject.SetActive(true);
                    Heart3.gameObject.SetActive(false);
                    break;
                }
            case 3:
                {
                    Heart1.gameObject.SetActive(true);
                    Heart2.gameObject.SetActive(true);
                    Heart3.gameObject.SetActive(true);
                    break;
                }



        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player1"))
            {
                health--;
                Debug.Log("-1 Heart");
            }

        }
        }
    }

        
}

