using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace sidz.finalbuild
{ 
    public class UIController : MonoBehaviour
    {
        public GameObject uiGameLost;
        public GameObject uiGameWon;
        [Header("UI")]
        public GameObject uiPauseBtn;
        public GameObject uiPauseScreen;
        public GameObject uiPauseCollider;
        public bool bUseCollider = true;
        public float fPauseDuration = 0.5f;
        private Vector3 vPauseScreenStartPosition;
        private void Start()
        {
            vPauseScreenStartPosition = uiPauseScreen.transform.position;
        }
        #region PAUSE_AREA
        public void UI_PauseToggle(bool a_bPause)
        {
            //   uiPauseScreen.SetActive(a_bPause);
            //   uiPauseBtn.SetActive(!a_bPause);
            uiPauseCollider.SetActive(bUseCollider && a_bPause);
            if (a_bPause)
            {
                uiPauseScreen.transform.position += Vector3.down * 15;
                uiPauseScreen.gameObject.SetActive(true);
                uiPauseBtn.GetComponent<Button>().interactable = !a_bPause;
                uiPauseScreen.transform.DOMove(vPauseScreenStartPosition, fPauseDuration);

            }
            else
            {

                var temp = uiPauseScreen.transform.position + Vector3.down * 15; ;
                uiPauseScreen.transform.DOMove(temp, fPauseDuration).OnComplete(() =>
                {
                    uiPauseBtn.GetComponent<Button>().interactable = !a_bPause;
                    uiPauseScreen.gameObject.SetActive(false);
                });
            }


        }
        public void UI_PauseToggleCollider(bool a_bPause)
        {
            uiPauseCollider.SetActive(a_bPause);
        }
        public void UI_Restart()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);//It;s hardcoded change it
        }
        public void UI_Quit()
        { 
        }
        #endregion PAUSE_AREA

        [ContextMenu("Test moving")]
        public void Test_MoveWithTween()
        {

            //  UI_PauseToggle(true);
            uiPauseScreen.transform.position += Vector3.down * 15;
            uiPauseScreen.gameObject.SetActive(true);
            uiPauseScreen.transform.DOMove(vPauseScreenStartPosition, fPauseDuration);

        }
    }
}
