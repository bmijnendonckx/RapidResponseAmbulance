using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using LSPD_First_Response.Mod.API;

namespace RapidResponseAmbulance
{
    public class Main:Plugin {
        public override void Finally() {
            Game.LogTrivial("Rapid Response Ambulance has been cleaned up.");
        }

        public override void Initialize() {
            Functions.OnOnDutyStateChanged += OnOnDutyStateChangedHandler;

            Game.LogTrivial("Plugin Rapig Response Ambulance has been initialised.");
        }

        private static void OnOnDutyStateChangedHandler(bool onDuty) {
            if(onDuty)
                RegisterCallouts();
        }

        private static void RegisterCallouts() {
            Functions.RegisterCallout(typeof(Callouts.HearthAttack));
        }
    }
}
