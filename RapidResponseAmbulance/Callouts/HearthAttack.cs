using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using LSPD_First_Response.Mod.API;
using LSPD_First_Response.Mod.Callouts;
using LSPD_First_Response.Engine.Scripting.Entities;

namespace RapidResponseAmbulance.Callouts {
    //Very High for Testing purposes
    [CalloutInfo("HearthAttack", CalloutProbability.VeryHigh)]
    public class HearthAttack : Callout {
        private Ped hearthAttackPed;
        private Blip hearthAttackBlip;
        private bool hearthAttackCreated = false;
        private Vector3 pos = new Vector3(-272.3569f, 27.46904f, 54.75251f);

        public override bool OnBeforeCalloutDisplayed() {
            ShowCalloutAreaBlipBeforeAccepting(pos, 30f);
            AddMinimumDistanceCheck(20f, pos);

            CalloutMessage = "Hearth Attack";
            CalloutPosition = pos;

            Functions.PlayScannerAudioUsingPosition("WE_HAVE CRIME_AMBULANCE_REQUESTED IN_OR_ON_POSITION", pos);

            return base.OnBeforeCalloutDisplayed();
        }

        public override bool OnCalloutAccepted() {
            hearthAttackPed = new Ped(new Model("a_m_y_bevhills_02"), pos, 213f);
            hearthAttackPed.IsPersistent = true;
            hearthAttackPed.BlockPermanentEvents = true;

            hearthAttackBlip = hearthAttackPed.AttachBlip();
            hearthAttackBlip.IsFriendly = true;

            hearthAttackPed.Tasks.PlayAnimation("amb@medic@standing@tendtodead@idle_a", "idle_b", 5, AnimationFlags.None);

            return base.OnCalloutAccepted();
        }

        public override void Process() {
            base.Process();

            if(!hearthAttackCreated && Game.LocalPlayer.Character.DistanceTo(hearthAttackPed.Position) < 30f) {
                hearthAttackCreated = true;
            }

            if(hearthAttackCreated)
                End();
        }

        public override void End() {
            base.End();

            if(hearthAttackPed.Exists())
                hearthAttackPed.Dismiss();
            if(hearthAttackBlip.Exists())
                hearthAttackBlip.Delete();
        }

    }
}
