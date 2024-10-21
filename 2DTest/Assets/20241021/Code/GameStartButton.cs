using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartButton : MonoBehaviour
{
    // 이 함수는 버튼 클릭 시 호출됩니다.
    public void StartGame()
    {
        // "GameScene"이라는 이름의 씬을 로드합니다.
        SceneManager.LoadScene("Game");
    }
}