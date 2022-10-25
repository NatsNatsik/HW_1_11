using System.Collections;
using UnityEngine;

namespace Assets.scripts
{
    public class Platform : MonoBehaviour
    {              
      
        private void OnTriggerEnter(Collider other)
        {   
            if (other.TryGetComponent(out Player player))
            player.CurrentPlatform = this;
           
        }

    }
}