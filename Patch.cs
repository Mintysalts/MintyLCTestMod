using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using MintyTestMod.Patches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintyTestMod
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class MintyTestMod : BaseUnityPlugin
    {
        private const string modGUID = "Minty.MintyTestMod";
        private const string modName = "Minty Test Mod";
        private const string modVersion = "1.0.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static MintyTestMod Instance;

        internal ManualLogSource mls;

        void Awake() 
        {
            if (Instance == null) 
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("This test mod as awaken :>");

            harmony.PatchAll(typeof(MintyTestMod));
            harmony.PatchAll(typeof(PlayerControllerBPatch));

        }
    }
}
