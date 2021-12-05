using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace sidz.wogame
{
    public enum eDirection
    { 
     up , left, right , down
    }
    public enum ePlayerStates
    { 
        
    Idle ,
    Move ,
    Jump , 
    Dead ,
    Shooting,
     Init,
    }
    public class Common 
    {
        public static  Vector3 GetDirectionVector(eDirection a_eDirection)
        {
            switch (a_eDirection)
            {
                case eDirection.up:
                    return Vector3.up;
                case eDirection.left:
                    return -Vector3.right;
                case eDirection.right:
                    return Vector3.right;
                case eDirection.down:
                    return -Vector3.up;
            }
            return Vector3.up;
        }
    }

    public  class GameTags
    {
        public static readonly string c_strWall = "Wall";
        public static readonly string c_strRegion = "Region";
        public static readonly string c_strIcon = "Icon";
    }


}