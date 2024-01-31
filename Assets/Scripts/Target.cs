using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    private Vector3 targetPosition;
    private float _speed;
    private float size;

    [System.Serializable]
    public class XPosition
    {
        public bool isLeft;
        public float xSpawn;
    }

    [System.Serializable]
    public class YPosition
    {
        public float minY;
        public float maxY;
    }
    [System.Serializable]
    public class ZPosition
    {
        public float minZ;
        public float maxZ;
    }

    [System.Serializable]
    public class Speed
    {
        public float minSpeed;
        public float maxSpeed;
    }


    [SerializeField] private XPosition xPositionLeft;
    [SerializeField] private XPosition xPositionRight;

    [SerializeField] private YPosition yPosition;
    [SerializeField] private ZPosition zPosition;

    [SerializeField] private Speed speed;

    private XPosition currentXPosition;

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

        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition, _speed * Time.deltaTime);

        if (Vector3.Distance(gameObject.transform.position, targetPosition) < 0.1f)
        {
            ResetTarget();
            ScoreManager.Instance.AddScore(-(CalculateScore() / 2));

            TargetAudioManager.instance.TargetMissed();
        }
    }

    private int CalculateScore()
    {
        float scoreSize = Mathf.Pow(size, -1) * 2;
        return Mathf.CeilToInt(_speed * scoreSize);
    }

    private void ResetTarget()
    {
        Vector3 newPos = NewPosition();
        SetObjectivePosition(newPos);

        gameObject.transform.position = newPos;
        SetNewSpeed();
        SetNewSize();
    }

    private void SetObjectivePosition(Vector3 newPos)
    {
        float distance = Mathf.Abs(xPositionLeft.xSpawn - xPositionRight.xSpawn);

        float x = currentXPosition.isLeft ? distance : -distance;

        targetPosition = new Vector3(newPos.x + x, newPos.y, newPos.z);
    }

    #region SetNew
    private void SetNewSize()
    {
        size = Random.Range(0.01f, 0.021f);
        gameObject.transform.localScale = Vector3.one * size;
    }

    private void SetNewSpeed()
    {
        _speed = Random.Range(speed.minSpeed, speed.maxSpeed);
    }

    private Vector3 NewPosition()
    {
        SetCurrentXPosition();
        float x = currentXPosition.xSpawn;
        float y = Random.Range(yPosition.minY, yPosition.maxY);
        float z = Random.Range(zPosition.minZ, zPosition.maxZ);

        return new Vector3(x, y, z);
    }

    private void SetCurrentXPosition()
    {
        currentXPosition = Random.value > 0.5f ? xPositionLeft : xPositionRight;
    }
    #endregion
}
