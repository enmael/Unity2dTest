/*
# ----------------------------------------------------------------------------------------
#파일이름 :GameStartButton.cs
#작성자 : 장승배
#생성일 : 2024.10.22
#내용 : 로비에서 버튼을 눌렀을때 씬이 이동하는 기능 
# ------------------------------------------------------------------------------------------
*/


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