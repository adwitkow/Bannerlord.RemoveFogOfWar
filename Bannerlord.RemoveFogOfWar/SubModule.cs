using Bannerlord.RemoveFogOfWar.Models;
using Bannerlord.RemoveFogOfWar.Patches;
using HarmonyLib;
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

            base.OnSubModuleLoad();
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            base.OnGameStart(game, gameStarterObject);

            if (game.GameType is not Campaign)
            {
                return;
            }

            gameStarterObject.AddModel<InformationRestrictionModel>(new NoFogOfWarInformationRestrictionModel());
        }
    }
}