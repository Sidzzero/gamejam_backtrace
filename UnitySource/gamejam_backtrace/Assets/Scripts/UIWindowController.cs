using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace sidz.wogame
{

    [System.Serializable]
    public struct UIObjectContainer
    {
        public GameObject goUICanvasButton;
        public GameObject goUICanvasOBj;
        public GameObject goObjCollider;
    }
    public class UIWindowController : MonoBehaviour 
    {
        public List<UIObjectContainer> lstObjectContainer;
        public GameObject goStartMenu;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void LateUpdate()
        {
            if (Input.GetMouseButtonDown(1) == true)
            {
                if (goStartMenu.activeInHierarchy == true)
                {
                    UI_StartMenuToggle(false);
                }
            }
        }

        internal void OnButtonLeftClick(UnityAction a_CallBack)
        {
            a_CallBack?.Invoke();


        }

        internal void OnButtonRightClick(UnityAction a_CallBack)
        {
            a_CallBack?.Invoke();
        }

        public void UI_StartMenuToggle(bool a_bClicked)
        {
            goStartMenu.SetActive(a_bClicked);
        }

        internal void OnPointerExit(UnityAction a_CallBack)
        {
            a_CallBack?.Invoke();
        }

        internal void OnPointerEnter(UnityAction a_CallBack)
        {
            a_CallBack?.Invoke();
        }

        public void ToggleCollider(GameObject go , bool a_Value)
        {
            foreach (var container in lstObjectContainer)
            {
                if (container.goUICanvasButton == go)
                {
                    container.goUICanvasOBj.SetActive(a_Value);
                    container.goObjCollider.SetActive(a_Value);
                    return;
                }
            }
        }
    }
}