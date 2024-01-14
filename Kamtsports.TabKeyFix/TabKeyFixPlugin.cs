using BepInEx;
using HarmonyLib;

namespace Kamtsports.TabKeyFix;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class TabKeyFixPlugin: BaseUnityPlugin 
{
    
    private readonly Harmony m_Harmony = new Harmony(PluginInfo.PLUGIN_GUID);

    private void Awake()
    {
        Logger.LogInfo($"{PluginInfo.PLUGIN_GUID} is loading...");

        Logger.LogInfo($"Installing patches");
        m_Harmony.PatchAll(typeof(TabKeyFixPlugin).Assembly);
        

        DontDestroyOnLoad(this);

        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
    }
}