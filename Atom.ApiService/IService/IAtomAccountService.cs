using Atom.ApiService.Models;
using System.Threading.Tasks;
namespace Atom.ApiService.IService
{
    public interface IAtomAccountService
    {
        /// <summary>
        /// returns available balance of the given account
        /// </summary>
        /// <param name="id">long id</param>
        /// <returns>account response details</returns>
        Task<AccountResponseDto> Balance(long id);
        /// <summary>
        /// add amount to the given account and returns account with updated information
        /// </summary>
        /// <param name="accountDto">account dto</param>
        /// <returns>account response details</returns>
        Task<AccountResponseDto> Deposit(AccountDto accountDto);
        /// <summary>
        /// withdraw specified amount if is available.
        /// </summary>
        /// <param name="accountDto">account dto</param>
        /// <returns>account response details</returns>
        Task<AccountResponseDto> Widthdraw(AccountDto accountDto);
    }
}
