using System.Linq;
using Game;
using GameLibrary;

namespace GnomoriaEditor
{
    public class Defs
    {
        public static FactionDef NeutralFactionDef
        {
			get { return GnomanEmpire.Instance.World.AIDirector.Factions.First(x => x.Value.FactionDef.Type == FactionType.Neutral).Value.FactionDef; }
        }

        public static FactionDef EnemyFactionDef
        {
			get { return GnomanEmpire.Instance.World.AIDirector.Factions.First(x => x.Value.FactionDef.Type == FactionType.EnemyCiv).Value.FactionDef; }
        }

        public static FactionDef WildFactionDef
        {
			get { return GnomanEmpire.Instance.World.AIDirector.Factions.First(x => x.Value.FactionDef.Type == FactionType.Wild).Value.FactionDef; }
        }

        public static FactionDef PlayerFactionDef
        {
			get { return GnomanEmpire.Instance.World.AIDirector.Factions.First(x => x.Value.FactionDef.Type == FactionType.PlayerCiv).Value.FactionDef; }
        }

        public static RaceClassDef YakDef
        {
			get { return NeutralFactionDef.Squads.First(x => x.Classes.Any(y => y.RaceID == RaceID.Yak.ToString())).Classes.First(x => x.RaceID == RaceID.Yak.ToString()); }
        }

        public static RaceClassDef AlpacaDef
        {
			get { return NeutralFactionDef.Squads.First(x => x.Classes.Any(y => y.RaceID == RaceID.Alpaca.ToString())).Classes.First(x => x.RaceID == RaceID.Alpaca.ToString()); }
        }

        public static RaceClassDef BearDef
        {
			get { return WildFactionDef.Squads.First(x => x.Classes.Any(y => y.RaceID == RaceID.Bear.ToString())).Classes.First(x => x.RaceID == RaceID.Bear.ToString()); }
        }

        public static RaceClassDef EmuDef
        {
			get { return NeutralFactionDef.Squads.First(x => x.Classes.Any(y => y.RaceID == RaceID.Emu.ToString())).Classes.First(x => x.RaceID == RaceID.Emu.ToString()); }
        }

        public static RaceClassDef GnomeDef
        {
			get { return PlayerFactionDef.Squads.First(x => x.Classes.Any(y => y.RaceID == RaceID.Gnome.ToString())).Classes.First(x => x.RaceID == RaceID.Gnome.ToString()); }
        }

        public static RaceClassDef HoneyBadgerDef
        {
			get { return WildFactionDef.Squads.First(x => x.Classes.Any(y => y.RaceID == RaceID.HoneyBadger.ToString())).Classes.First(x => x.RaceID == RaceID.HoneyBadger.ToString()); }
        }

        public static RaceClassDef MonitorLizardDef
        {
			get { return WildFactionDef.Squads.First(x => x.Classes.Any(y => y.RaceID == RaceID.MonitorLizard.ToString())).Classes.First(x => x.RaceID == RaceID.MonitorLizard.ToString()); }
        }

        public static RaceClassDef OgreDef
        {
			get { return EnemyFactionDef.Squads.First(x => x.Classes.Any(y => y.RaceID == RaceID.Ogre.ToString())).Classes.First(x => x.RaceID == RaceID.Ogre.ToString()); }
        }

        public static RaceClassDef ToughOgreDef
        {
			get { return EnemyFactionDef.Squads.First(x => x.Classes.Any(y => y.RaceID == RaceID.BlueOgre.ToString())).Classes.First(x => x.RaceID == RaceID.BlueOgre.ToString()); }
        }

        public static Faction WildFaction
        {
            get { return GnomanEmpire.Instance.World.AIDirector.Factions.First(x => x.Value.FactionDef.Type == FactionType.Wild).Value; }
        }

        public static Faction NeutralFaction
        {
            get { return GnomanEmpire.Instance.World.AIDirector.NeutralFaction; }
        }

        public static Faction EnemyFaction
        {
            get { return GnomanEmpire.Instance.World.AIDirector.Factions.First(x => x.Value.FactionDef.Type == FactionType.EnemyCiv).Value; }
        }

        public static Faction PlayerFaction
        {
            get { return GnomanEmpire.Instance.World.AIDirector.PlayerFaction; }
        }

    }
}