using HarmonyLib;
using UnityEngine.InputSystem;

namespace Kamtsports.TabKeyFix.Patches
{
    [HarmonyPatch]
    internal static class DisableTabKeyPatch
    {
        
        [HarmonyPrefix]
        [HarmonyPatch(typeof(Terminal), "PressESC")]
        public static bool DisableTabKey(ref InputAction.CallbackContext context)
        {
            var name = context.control.name;
            return !name.Equals("tab");
        }
        
        [HarmonyPrefix]
        [HarmonyPatch(typeof(HUDManager), nameof(HUDManager.ChangeControlTip))]
        public static void ChangeHintToEsc(ref string changeTo)
        {
            if (changeTo.Equals("Quit terminal : [TAB]"))
            {
                changeTo = "Quit terminal : [ESC]";
            }
        }
    }
    
}