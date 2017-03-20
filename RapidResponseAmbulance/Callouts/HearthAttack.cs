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
    }
}
