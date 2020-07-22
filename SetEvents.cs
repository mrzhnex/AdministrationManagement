using EXILED;
using System.Collections.Generic;
using EXILED.Extensions;
using System.IO;
using System.Linq;

namespace AdministrationManagement
{
    public class SetEvents
    {
        internal void OnPlayerJoin(PlayerJoinEvent ev)
        {
            if (Global.Administration.ContainsKey(ev.Player.GetUserId()))
            {
                ev.Player.SetRank(Global.Administration[ev.Player.GetUserId()]);
                Log.Info("Set rank " + Global.Administration[ev.Player.GetUserId()].BadgeText + " to " + ev.Player.nicknameSync.Network_myNickSync);
            }
        }

        internal void OnSetGroup(SetGroupEvent ev)
        {
            if (Global.Administration.ContainsKey(ev.Player.GetUserId()) && ev.Group != Global.Administration[ev.Player.GetUserId()])
            {
                ev.Allow = false;
            }
        }

        internal void OnWaitingForPlayers()
        {
            Global.Administration = new Dictionary<string, UserGroup>();
            List<string> tempAdministration = File.ReadAllLines(Global.AdministrationFullFileName).ToList();
            foreach (string line in tempAdministration)
            {
                string[] args = line.Split(':');
                if (args.Length != 2 || args[0].Length != 26 || args[1].Length < 2)
                    continue;
                args[0] = args[0].Substring(3);
                args[1] = args[1].Substring(1);
                if (!ServerStatic.GetPermissionsHandler().GetAllGroups().ContainsKey(args[1]))
                    continue;
                if (!Global.Administration.ContainsKey(args[0]))
                    Global.Administration.Add(args[0], ServerStatic.GetPermissionsHandler().GetAllGroups()[args[1]]);
            }
        }
    }
}