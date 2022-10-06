using UnityEngine;

public class PlayerCather : MonoBehaviour
{
    [SerializeField] private CounterController gold;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gold"))
        {
            gold.Add(1);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Asteroid"))
        {
            Destroy(this.gameObject);
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
