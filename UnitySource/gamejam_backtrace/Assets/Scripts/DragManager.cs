using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace sidz.wogame
{
    public class DragManager : MonoBehaviour
    {
        public List<DraggableItems> lstDragItems;
        //Holds all the draggable items 
        //Test if if is in the region
        // Start is called before the first frame update

        public Collider colAttachedBounds;
        private void Start()
        {
       
        }
        public bool CanIDrag(Vector3 v_Position)
        {
            v_Position.z = colAttachedBounds.bounds.center.z;
            return colAttachedBounds.bounds.Contains(v_Position);
        }
          
    }

}