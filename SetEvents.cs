using Exiled.API.Features;
using Exiled.Events.EventArgs;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdministrationManagement
{
    public class SetEvents
    {
        internal void OnChangingGroup(ChangingGroupEventArgs ev)
        {
            if (Global.Administration.ContainsKey(ev.Player.UserId) && ev.NewGroup != Global.Administration[ev.Player.UserId])
            {
                ev.IsAllowed = false;
            }
        }

        internal void OnJoined(JoinedEventArgs ev)
        {
            if (Global.Administration.ContainsKey(ev.Player.UserId))
            {
                ev.Player.SetRank(Global.Administration[ev.Player.UserId].BadgeText, Global.Administration[ev.Player.UserId]);
                Log.Info("Set rank " + Global.Administration[ev.Player.UserId].BadgeText + " to " + ev.Player.Nickname);
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