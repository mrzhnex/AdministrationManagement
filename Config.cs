using Exiled.API.Interfaces;

namespace AdministrationManagement
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
    }
}