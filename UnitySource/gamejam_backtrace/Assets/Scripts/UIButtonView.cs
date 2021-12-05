using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace sidz.wogame
{
    public class UIButtonView : MonoBehaviour  , IPointerClickHandler,IPointerExitHandler,IPointerEnterHandler
    {
        public UIWindowController windowController;
        public Button uiButton;

        public UnityEvent<bool> uEvntOnLeftClickWindowController;
        public UnityEvent<bool> uEvntOnRightClickWindowController;
        public UnityEvent<bool> uEvntOnPointerLeftWindowController;
        public UnityEvent<bool> uEvntPoniterEnter;
        public UnityEvent<bool> uEvntPointerExit;

        private bool bDetectionRange = false;
        public eDirection AppearDirection = eDirection.up;
        public eDirection DisappearDirection = eDirection.down;
        private void LateUpdate()
        {
            if (bDetectionRange == false && Input.GetMouseButtonDown(1))
            {
                windowController.ToggleCollider(this.gameObject, false);
            }
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                windowController.OnButtonLeftClick(()=> { uEvntOnLeftClickWindowController?.Invoke(true);
                    windowController.ToggleCollider(this.gameObject, true);
                });
            }
            else if (eventData.button == PointerEventData.InputButton.Right)
            {
                  windowController.OnButtonLeftClick(() => { uEvntOnLeftClickWindowController?.Invoke(true);
                      windowController.ToggleCollider(this.gameObject, false);
                  });
              
            }
           
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            bDetectionRange = false;
            windowController.OnPointerExit(() => 
                { uEvntPointerExit?.Invoke(false);
                  
                });
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            bDetectionRange = true;
            windowController.OnPointerEnter(() => { uEvntPoniterEnter?.Invoke(false); });
            
        }
        [ContextMenu("Tween Up")]
        public void TweenMovement()
        {
            transform.position = transform.position  - Common.GetDirectionVector(AppearDirection) * 2.0f;
            transform.DOMove(transform.position + Common.GetDirectionVector(AppearDirection)*2.0f, 1);
        }
    }
}