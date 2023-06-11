using UnityEngine;

public class Hearts : MonoBehaviour
{
    private GameObject Heart1;
    private GameObject Heart2;
    private GameObject Heart3;

    public GameObject gameOver;

    int health;

    private void Start()
    {
        health = 3;

        GameObject canvasGameObject = GameObject.Find("Canvas");
        if (canvasGameObject != null)
        {
            Heart1 = canvasGameObject.transform.Find("Heart 1").gameObject;
            Heart2 = canvasGameObject.transform.Find("Heart 2").gameObject;
            Heart3 = canvasGameObject.transform.Find("Heart 3").gameObject;
        }
    }

    private void Update()
    {
        switch (health)
        {
            case 0:
                {
                    Heart1.gameObject.SetActive(false);
                    Heart2.gameObject.SetActive(false);
                    Heart3.gameObject.SetActive(false);
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
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (CompareTag("Projectile"))
        {
            health--;
            Debug.Log("-1 Heart");
        }
    }
}

