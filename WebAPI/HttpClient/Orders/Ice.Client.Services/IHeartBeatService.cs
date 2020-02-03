using System.Threading.Tasks;

namespace Ice.Client.Services
{
    public interface IHeartBeatService
    {
        Task<HeartBeatResponse> IsAlive(HeartBeartRequest heartBeatRequest);
    }
}