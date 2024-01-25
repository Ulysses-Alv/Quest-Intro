using TMPro;
using UnityEngine;

public class UIEndCanvasController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Score, Record;
    [SerializeField] private GameObject NewRecord;

    private void OnEnable()
    {
        int score = ScoreManager.Instance._currentScore;
        int record = ScoreManager.Instance.GetRecordScore();

        Score.text = $"Score: {score}";
        Record.text = $"Record: {record}";

        NewRecord.SetActive(score > record);

        PlayerPrefs.SetInt("Record", Mathf.Max(score, record));
    }
}