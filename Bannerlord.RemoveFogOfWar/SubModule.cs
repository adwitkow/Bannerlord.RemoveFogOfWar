using HarmonyLib;
using TaleWorlds.MountAndBlade;

namespace Bannerlord.RemoveFogOfWar
{
    public class SubModule : MBSubModuleBase
    {
        private readonly Harmony _harmony = new Harmony(typeof(SubModule).Namespace);

        protected override void OnSubModuleLoad()
        {
            DefaultInformationRestrictionModelPatch.Apply(_harmony);
            base.OnSubModuleLoad();
        }
    }
}