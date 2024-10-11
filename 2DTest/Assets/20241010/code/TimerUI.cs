using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    public float timeLimit = 60f; // 60초 타이머
    private float currentTime;
    
    public Text timerText; // UI Text 컴포넌트 연결

    void Start()
    {
        //currentTime = timeLimit;
        UpdateTimerUI();
    }

    void Update()
    {
    
            currentTime += Time.deltaTime; // 매 프레임마다 시간을 감소시킴
            UpdateTimerUI();
        
            //currentTime = 0;
            //UpdateTimerUI(); // 타이머가 끝났을 때도 UI 갱신
            //Debug.Log("Timer ended!");
        
    }

    void UpdateTimerUI()
    {
        // 시간 값을 분:초 형식으로 변환하여 UI에 표시
        int minutes = Mathf.FloorToInt(currentTime / 60); // 분 단위
        int seconds = Mathf.FloorToInt(currentTime % 60); // 초 단위
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
