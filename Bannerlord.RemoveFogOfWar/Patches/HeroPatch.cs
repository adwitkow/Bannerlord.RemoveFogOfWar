using HarmonyLib;
using HarmonyLib.BUTR.Extensions;
using TaleWorlds.CampaignSystem;

namespace Bannerlord.RemoveFogOfWar.Patches
{
    public static class HeroPatch
    {
        public static void Apply(Harmony harmony)
        {
            var methodToPatch = AccessTools2.PropertyGetter(typeof(Hero),
                nameof(Hero.IsKnownToPlayer));
            var prefixMethod = AccessTools2.Method(typeof(HeroPatch),
                nameof(IsKnownToPlayer));

            harmony.TryPatch(methodToPatch, prefix: prefixMethod);
        }

        private static bool IsKnownToPlayer(ref bool __result)
        {
            if (Settings.Instance.EnableForHeroes)
            {
                __result = true;
                return false;
            }

            return true;
        }
    }
}
