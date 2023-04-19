using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoeyRcgTryOut.Services.Encoding.Tests.Stubs
{
    internal class StubIHubClient : IHubClients
    {
        public IClientProxy All => throw new NotImplementedException();

        public IClientProxy AllExcept(IReadOnlyList<string> excludedConnectionIds)
        {
            throw new NotImplementedException();
        }

        public IClientProxy Client(string connectionId)
        {
            return new StubIClientProxy();
        }

        public IClientProxy Clients(IReadOnlyList<string> connectionIds)
        {
            throw new NotImplementedException();
        }

        public IClientProxy Group(string groupName)
        {
            throw new NotImplementedException();
        }

        public IClientProxy GroupExcept(string groupName, IReadOnlyList<string> excludedConnectionIds)
        {
            throw new NotImplementedException();
        }

        public IClientProxy Groups(IReadOnlyList<string> groupNames)
        {
            throw new NotImplementedException();
        }

        public IClientProxy User(string userId)
        {
            throw new NotImplementedException();
        }

        public IClientProxy Users(IReadOnlyList<string> userIds)
        {
            throw new NotImplementedException();
        }
    }
}
