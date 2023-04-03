using HarmonyLib;
using HarmonyLib.BUTR.Extensions;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements;

namespace Bannerlord.RemoveFogOfWar
{
    static class DefaultInformationRestrictionModelPatch
    {
        public static void Apply(Harmony harmony)
        {
            var settlementMethodToPatch = AccessTools2.Method(typeof(DefaultInformationRestrictionModel),
                nameof(DefaultInformationRestrictionModel.DoesPlayerKnowDetailsOf),
                new[] { typeof(Settlement) });
            var heroMethodToPatch = AccessTools2.Method(typeof(DefaultInformationRestrictionModel),
                nameof(DefaultInformationRestrictionModel.DoesPlayerKnowDetailsOf),
                new[] { typeof(Hero) });
            var prefixMethod = AccessTools2.Method(typeof(DefaultInformationRestrictionModelPatch),
                nameof(DoesPlayerKnowDetailsOfPrefix));

            harmony.TryPatch(settlementMethodToPatch, prefix: prefixMethod);
            harmony.TryPatch(heroMethodToPatch, prefix: prefixMethod);
        }

        private static bool DoesPlayerKnowDetailsOfPrefix(ref bool __result)
        {
            __result = true;
            return false;
        }
    }
}
