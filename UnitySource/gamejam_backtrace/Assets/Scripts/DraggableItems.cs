using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace sidz.wogame
{
    public class DraggableItems : MonoBehaviour
    {
        public DragManager dragManager;
        private Vector3 vScreenPoint;
        private Vector3 vOffset;

        private bool bCanDrag;
        public bool bPlayerStanding = false;
        private void Start()
        {
            
        }
       
      
        // Start is called before the first frame update
        void OnMouseDown()
        {
            vScreenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            vOffset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, vScreenPoint.z));
            bCanDrag = true;
        }
        
        void OnMouseDrag()
        {
            if (bCanDrag == false || bPlayerStanding == true)
            {
                return;
            }
            Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, vScreenPoint.z);
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + vOffset;
            if (dragManager.CanIDrag(cursorPosition) == false)
            {
                bCanDrag = false;
                return;
            }
            transform.position = cursorPosition;
          
        }
  
    }
}
