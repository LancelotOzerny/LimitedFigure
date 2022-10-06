using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    [SerializeField] private Vector2 moveDirection;
    [SerializeField] private float speed = 7.0f;
    [SerializeField] private float deathTimer = 10.0f;

    private void Start()
    {
        GetComponent<SoundController>().Play();
        Destroy(gameObject, deathTimer);
        if (PlayerPrefs.GetInt("ColorLevel") >= 3)
        {
            GetComponent<Animator>().SetBool("isColor", true);
        }
    }

    private void Update()
    {
        transform.position = new Vector3
        (
            transform.position.x + moveDirection.x * speed * Time.deltaTime,
            transform.position.y + moveDirection.y * speed * Time.deltaTime,
            transform.position.z
        );
    }
}
