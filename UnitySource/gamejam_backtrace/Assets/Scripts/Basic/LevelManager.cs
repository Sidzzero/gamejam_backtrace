using DG.Tweening;
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
        public UIController uiController;
        public Transform transStartingPosition;
        public bool bUseCollider = true;
        public int iCoinsToCollect;
    

        private int iCurrentCollected = 0;

     
        private void Start()
        {
            iCurrentCollected = 0;
            player.transform.position = transStartingPosition.position;
            uiController.bUseCollider = bUseCollider;
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
            player.enabled = false;
            uiController.UI_PauseToggle(false);
            if (a_Sucess)
            {
                Debug.Log("Game Won with Sucess:");
                uiController.uiGameWon.SetActive(true);
            }
            else
            {
                Debug.Log("Game Won with Failure:" + (iCurrentCollected - iCoinsToCollect));
                uiController.uiGameLost.SetActive(true);
            }
           
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

     
    }
}