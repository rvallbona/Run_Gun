using UnityEngine;

public class EnemyHor : MonoBehaviour
{
    public float speed = 0.8f;
    public float range = 3;

    float startingY;
    int dir = 1;
    // Start is called before the first frame update
    void Start()
    {
        startingY = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime * dir);
        if (transform.position.x < startingY || transform.position.x > startingY + range)
            dir *= -1;
    }
}
