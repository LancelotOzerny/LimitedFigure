using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    #region Поля класса
    [Header("Player Movement Points")]
    [SerializeField] private Transform[] movePoints = new Transform[4];

    [Header("Player Movement Settings")]
    [SerializeField] private float speed;
    [SerializeField] private bool reverse;
    [SerializeField] private Vector2 movement;

    [SerializeField] private Vector2 lastPoint, nextPoint;
    [SerializeField] private int nextIndex;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private SoundController sc;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        sc = GetComponent<SoundController>();

        movement = new Vector2(0, 0);

        lastPoint = movePoints[0].position;
        nextPoint = movePoints[1].position;
        nextIndex = 1;

        transform.position = new Vector3(
            lastPoint.x,
            lastPoint.y,
            transform.position.z
        );
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.Play("ReverseAnimation");
            sc.Play();
            reverse = !reverse;

            SelectNewPoint();
            movement *= 0;

            CheckMoveDirection();
        }

        Vector3 pos = transform.position;

        CheckMoveDirection();

        transform.position = new Vector3(
            pos.x + movement.x * speed * Time.deltaTime,
            pos.y + movement.y * speed * Time.deltaTime,
            pos.z
        );

        CheckTarget();
    }

    private void CheckMoveDirection()
    {
        Vector3 pos = transform.position;

        // Позиция по X
        if (pos.x < nextPoint.x)
        {
            movement.x = 1;
        }
        else if (pos.x > nextPoint.x)
        {
            movement.x = -1;
        }
        else
        {
            movement.y = 0;
        }

        // Позиция по Y
        if (pos.y < nextPoint.y)
        {
            movement.y = 1;
        }
        else if (pos.y > nextPoint.y)
        {
            movement.y = -1;
        }
        else
        {
            movement.y = 0;
        }
    }

    private void CheckTarget()
    {
        if (
            (transform.position.x > nextPoint.x & movement.x > 0.5) | (transform.position.x < nextPoint.x & movement.x < 0.5)
            )
        {
            transform.position = new Vector3(
                nextPoint.x,
                nextPoint.y,
                transform.position.z
            );
            movement *= 0;

            SelectNewPoint();
            CheckMoveDirection();
        }

        else if ((transform.position.y > nextPoint.y & movement.y > 0.5) | (transform.position.y < nextPoint.y & movement.y < 0.5))
        {
            transform.position = new Vector3(
                nextPoint.x,
                nextPoint.y,
                transform.position.z
            );
            movement *= 0;

            SelectNewPoint();
            CheckMoveDirection();
        }
    }

    private void SelectNewPoint()
    {
        if (reverse)
        {
            if (--nextIndex < 0)
            {
                nextIndex = movePoints.Length - 1;
            }
        }
        else
        {
            if (++nextIndex >= movePoints.Length)
            {
                nextIndex = 0;
            }
        }

        lastPoint = nextPoint;
        nextPoint = movePoints[nextIndex].position;
    }
}