using EXILED;

namespace AdministrationManagement
{
    public class MainSettings : Plugin
    {
        public override string getName => nameof(AdministrationManagement);
        public SetEvents SetEvents { get; set; }
        public override void OnEnable()
        {
            SetEvents = new SetEvents();
            Events.PlayerJoinEvent += SetEvents.OnPlayerJoin;
            Events.WaitingForPlayersEvent += SetEvents.OnWaitingForPlayers;
            Events.SetGroupEvent += SetEvents.OnSetGroup;
            Log.Info(getName + " on");
        }

        public override void OnDisable()
        {
            Events.PlayerJoinEvent -= SetEvents.OnPlayerJoin;
            Events.WaitingForPlayersEvent -= SetEvents.OnWaitingForPlayers;
            Events.SetGroupEvent -= SetEvents.OnSetGroup;
            Log.Info(getName + " off");
        }

        public override void OnReload() { }
    }
}