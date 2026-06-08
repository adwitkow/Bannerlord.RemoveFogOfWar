using Bannerlord.RemoveFogOfWar.Models;
using Bannerlord.RemoveFogOfWar.Patches;
using HarmonyLib;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace Bannerlord.RemoveFogOfWar
{
    public class SubModule : MBSubModuleBase
    {
        private readonly Harmony _harmony = new Harmony(typeof(SubModule).Namespace);

        protected override void OnSubModuleLoad()
        {
            HeroPatch.Apply(_harmony);
            HeroHelperPatch.Apply(_harmony);

            base.OnSubModuleLoad();
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            base.OnGameStart(game, gameStarterObject);

            if (game.GameType is not Campaign)
            {
                return;
            }

#if LOWER_THAN_1_3
            var baseModel = gameStarterObject.Models
                .OfType<InformationRestrictionModel>()
                .LastOrDefault();
            gameStarterObject.AddModel(new NoFogOfWarInformationRestrictionModel(baseModel));
#else
            gameStarterObject.AddModel<InformationRestrictionModel>(new NoFogOfWarInformationRestrictionModel());
#endif
        }
    }
}