using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine.Networking;
using UnityEngine;
using TMPro;

namespace SuperlativeSandbox
{
    [BepInPlugin("com.meds.superlativesandbox", PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private readonly Harmony harmony = new("com.meds.superlativesandbox");
        internal static ManualLogSource Log;
        private void Awake()
        {
            // Plugin startup logic
            Log = Logger;
            Logger.LogInfo($"Superlative Sandbox activated!");
            harmony.PatchAll();
        }
    }
    [HarmonyPatch]
    public class SandEVERYWHERE
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(SandboxManager), "InitCombos")]
        public static bool InitCombosPrefix(ref SandboxManager __instance)
        {
            Traverse.Create(__instance).Field("keyValue").SetValue(new Dictionary<string, List<int>>());
            Traverse.Create(__instance).Field("currentValue").SetValue(new Dictionary<string, int>());
            Traverse.Create(__instance).Field("defaultValue").SetValue(new Dictionary<string, int>());
            Traverse.Create(__instance).Field("comboValues").SetValue(new Dictionary<string, TMP_Text>());
            Traverse.Create(__instance).Field("valueIsPercent").SetValue(new List<string>());
            Traverse.Create(__instance).Field("showPositiveSign").SetValue(new List<string>());
            MethodInfo setCombo = __instance.GetType().GetMethod("SetCombo", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            setCombo.Invoke(__instance, new object[] { "sbEnergy", 0, -100, 100, 1, true, false });
            setCombo.Invoke(__instance, new object[] { "sbSpeed", 0, -100, 100, 1, true, false });
            setCombo.Invoke(__instance, new object[] { "sbGold", 0, -100000, 500000, 2500, true, false });
            setCombo.Invoke(__instance, new object[] { "sbShards", 0, -100000, 500000, 2500, true, false });
            setCombo.Invoke(__instance, new object[] { "sbCraftCost", 0, -100, 3000, 25, true, true });
            setCombo.Invoke(__instance, new object[] { "sbUpgradeCost", 0, -100, 3000, 25, true, true });
            setCombo.Invoke(__instance, new object[] { "sbTransformCost", 0, -100, 3000, 25, true, true });
            setCombo.Invoke(__instance, new object[] { "sbRemoveCost", 0, -100, 3000, 25, true, true });
            setCombo.Invoke(__instance, new object[] { "sbEquipmentCost", 0, -100, 3000, 25, true, true });
            setCombo.Invoke(__instance, new object[] { "sbPetsCost", 0, -100, 3000, 25, true, true });
            setCombo.Invoke(__instance, new object[] { "sbDivinationCost", 0, -100, 3000, 25, true, true });
            setCombo.Invoke(__instance, new object[] { "sbMonstersHP", 0, -90, 3000, 10, true, true });
            setCombo.Invoke(__instance, new object[] { "sbMonstersDamage", 0, -90, 3000, 10, true, true });
            return false;
        }
    }
}
