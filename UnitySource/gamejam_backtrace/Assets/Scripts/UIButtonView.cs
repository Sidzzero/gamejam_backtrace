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
        private void Start()
        {
            
        }
      
        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                windowController.OnButtonLeftClick(()=> { uEvntOnLeftClickWindowController?.Invoke(true); });
            }
            else if (eventData.button == PointerEventData.InputButton.Right)
            {
                windowController.OnButtonLeftClick(() => { uEvntOnLeftClickWindowController?.Invoke(true); });
            }
           
        }

        public void OnPointerExit(PointerEventData eventData)
        {
                windowController.OnPointerExit(() => { uEvntPointerExit?.Invoke(false); });
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            windowController.OnPointerEnter(() => { uEvntPoniterEnter?.Invoke(false); });
        }
    }
}