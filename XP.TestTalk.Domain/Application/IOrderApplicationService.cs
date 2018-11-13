using System.Threading.Tasks;

namespace XP.TestTalk.Domain.Application
{
    public interface IOrderApplicationService
    {
        Task PlaceOrder(int customerCode, string ticker, int amount);
    }
}