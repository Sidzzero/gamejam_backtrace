using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace sidz.finalbuild
{

    public class LevelManager : MonoBehaviour
    {
        public int iCoinsToCollect;
        public GameObject uiGameEnd;

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
            }
            else
            {
                Debug.Log("Game Won with Failure:" + (iCurrentCollected - iCoinsToCollect));
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
    }
}