using System.Collections.Generic;

namespace API.Services
{
    public interface ILocationServices
    {
        IEnumerable<string> GetRegisteredPorts();
        IEnumerable<string> GetRegisteredYards();
    }
}
