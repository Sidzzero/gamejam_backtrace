using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace sidz.finalbuild
{

    public class LevelManager : MonoBehaviour
    {
        public BPlayerController player;
        public int iCoinsToCollect;
        
        public GameObject uiGameLost;
        public GameObject uiGameWon;
        [Header("UI")]
        public GameObject uiPauseBtn;
        public GameObject uiPauseScreen;
        public GameObject uiPauseCollider;
        private int iCurrentCollected = 0;
        private void Start()
        {
            iCurrentCollected = 0;
        }
        public void Level_CoinCollected(GameObject coinObj)
        {
            iCurrentCollected++;
            Destroy(coinObj.gameObject);
            Debug.Log("Remaning Left:"+ (iCurrentCollected-iCoinsToCollect));
            
        }

        public void Level_ReachedDoor()
        {
            LevelComplete(iCurrentCollected >= iCoinsToCollect);
        }

        public void LevelComplete(bool a_Sucess)
        {
            if (a_Sucess)
            {
                Debug.Log("Game Won with Sucess:");
                uiGameWon.SetActive(true);
            }
            else
            {
                Debug.Log("Game Won with Failure:" + (iCurrentCollected - iCoinsToCollect));
                uiGameLost.SetActive(true);
            }
            player.enabled = false;
        }

        internal void Level_OnPlayerInteracted(InteractaleType temp_IntComp)
        {
            switch (temp_IntComp.type)
            {
                case eInteractableType.Coin:
                    Level_CoinCollected(temp_IntComp.gameObject);
                    break;
                case eInteractableType.Door:
                    Level_ReachedDoor();
                    break;
                case eInteractableType.Boundary:
                    Debug.Log("Touching the wall");
                    break;
            }
        }

        public void Level_RestartLevel()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);//It;s hardcoded change it
        }

        #region PAUSE_AREA
        public void UI_PauseToggle(bool a_bPause)
        {
            uiPauseScreen.SetActive(a_bPause);
            uiPauseBtn.SetActive(!a_bPause);
            uiPauseBtn.GetComponent<Button>().interactable = !a_bPause;
        }
        public void UI_PauseToggleCollider(bool a_bPause)
        {
            uiPauseCollider.SetActive(a_bPause);
        }
        #endregion PAUSE_AREA
    }
}