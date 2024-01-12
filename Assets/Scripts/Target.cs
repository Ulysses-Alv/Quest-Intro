using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform[] targetPositions;
    private Vector3 targetPosition;
    private float speed;
    private float size;

    private void Start()
    {
        ResetGameObject();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            ResetGameObject();

            UIScoreManager.Instance.AddScore(CalculateScore());
        }
    }

    private int CalculateScore()
    {
        float scoreSize = Mathf.Pow(size, -1) * 2;
        return Mathf.CeilToInt(speed * scoreSize);
    }

    private void ResetGameObject()
    {
        targetPosition = targetPositions[Random.Range(0, targetPositions.Length)].position;
        gameObject.transform.position = NewPosition();
        SetNewSpeed();
        SetNewSize();
    }

    private void SetNewSize()
    {
        size = Random.Range(0.1f, 1f);
        gameObject.transform.localScale = Vector3.one * size;
    }

    private void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition, speed * Time.deltaTime);
        
        if (Vector3.Distance(gameObject.transform.position, targetPosition) < 0.1f)
        {
            ResetGameObject();
        }
    }
    private void SetNewSpeed()
    {
        speed = Random.Range(1f, 10f);
    }
    private Vector3 NewPosition()
    {
        return new Vector3(Random.Range(-5f, 5f), Random.Range(0f, 5f), 5);
    }
}
