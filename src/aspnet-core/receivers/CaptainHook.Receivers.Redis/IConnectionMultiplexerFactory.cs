using StackExchange.Redis;
using System.Threading.Tasks;

namespace CaptainHook.Receivers.Redis
{
    public interface IConnectionMultiplexerFactory
    {
        /// <summary>
        /// Creates a new <see cref="IConnectionMultiplexer"/>.
        /// Avoid to create too many connections since they are not disposed until end of the application.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        Task<IConnectionMultiplexer> CreateAsync(string configuration);
    }
}