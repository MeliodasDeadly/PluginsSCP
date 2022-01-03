using Synapse;
using Synapse.Api.Events.SynapseEventArguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dorien_Plugin72
{
    internal class EventHandler
    {

        #region Properties & Variable
        #endregion

        #region Constructor & Destructor
        public EventHandler()
        {
            Server.Get.Events.Player.PlayerDeathEvent += OnDeath;
        }
        #endregion

        #region Methods
        #endregion

        #region Events
        private void OnDeath(PlayerDeathEventArgs ev)
        {
            ev.Victim.RoleID = 333;
            ev.Victim.BroadcastMessage("T'est null car CACA", Plugin.instance.Config.broadcastTime);
        }
        #endregion
    }
}
