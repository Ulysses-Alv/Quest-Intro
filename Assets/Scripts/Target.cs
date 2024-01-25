using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform[] targetPositions;
    private Vector3 targetPosition;
    private float speed;
    private float size;

    private void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GameManagerStatus.statusEvent.AddListener(ChangeTargetStatus);
    }
    private void ChangeTargetStatus(GameState status)
    {
        if (status == GameState.Playing)
            InitializeTarget();
        else
            StopTarget();

    }
    private void StopTarget()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }
    private void InitializeTarget()
    {
        GetComponent<MeshRenderer>().enabled = true;
        ResetTarget();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!GameManagerStatus.IsPlaying()) return;

        if (!collision.gameObject.CompareTag("Bullet")) return;

        TargetAudioManager.instance.TargetHitted();
        ResetTarget();
        ScoreManager.Instance.AddScore(CalculateScore());
    }
    private void Update()
    {
        if (!GameManagerStatus.IsPlaying()) return;

        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(gameObject.transform.position, targetPosition) < 0.1f)
        {
            ResetTarget();
            TargetAudioManager.instance.TargetMissed();
        }
    }

    private int CalculateScore()
    {
        float scoreSize = Mathf.Pow(size, -1) * 2;
        return Mathf.CeilToInt(speed * scoreSize);
    }

    private void ResetTarget()
    {
        targetPosition = targetPositions[Random.Range(0, targetPositions.Length)].position;
        gameObject.transform.position = NewPosition();
        SetNewSpeed();
        SetNewSize();
    }

    #region SetNew
    private void SetNewSize()
    {
        size = Random.Range(0.01f, 0.03f);
        gameObject.transform.localScale = Vector3.one * size;
    }

    private void SetNewSpeed()
    {
        speed = Random.Range(1f, 7f);
    }
    private Vector3 NewPosition()
    {
        return new Vector3(Random.Range(-5f, 5f), Random.Range(0f, 5f), 5);
    }
    #endregion
}
