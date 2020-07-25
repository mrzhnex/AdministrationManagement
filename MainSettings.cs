using Exiled.API.Features;

namespace AdministrationManagement
{
    public class MainSettings : Plugin<Config>
    {
        public override string Name => nameof(AdministrationManagement);
        public SetEvents SetEvents { get; set; }
        public override void OnEnabled()
        {
            SetEvents = new SetEvents();
            Exiled.Events.Handlers.Player.Joined += SetEvents.OnJoined;
            Exiled.Events.Handlers.Server.WaitingForPlayers += SetEvents.OnWaitingForPlayers;
            Exiled.Events.Handlers.Player.ChangingGroup += SetEvents.OnChangingGroup;
            Log.Info(Name + " on");
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.Joined -= SetEvents.OnJoined;
            Exiled.Events.Handlers.Server.WaitingForPlayers -= SetEvents.OnWaitingForPlayers;
            Exiled.Events.Handlers.Player.ChangingGroup -= SetEvents.OnChangingGroup;
            Log.Info(Name + " off");
        }
    }
}