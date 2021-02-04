using Atom.Client.Models;
using System.Threading.Tasks;

namespace Atom.Client.IService
{
    public interface IAtomTransactionClientService
    {
        Task<ViewModel> Balance(long id);
        Task<ViewModel> Deposit(ViewModel model);
        Task<ViewModel> Widthdraw(ViewModel model);
    }
}
