using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace sidz.wogame
{
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
    
    }

    public  class GameTags
    {
        public static readonly string c_strWall = "Wall";
        public static readonly string c_strRegion = "Region";
    }


}